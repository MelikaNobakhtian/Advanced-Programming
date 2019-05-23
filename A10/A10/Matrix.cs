using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> :
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            Rows = new Vector<_Type>[rowCount];
            for (int i = 0; i < rowCount; i++)
                Rows[i] = new Vector<_Type>(columnCount) { };

        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
                : this(rows.Count(), rows.First().Size)
        {
            Rows = rows.ToArray<Vector<_Type>>();
        }

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public Vector<_Type> this[int index]
        {
            get { return Rows[index]; }
            set { Rows[index] = value; }
        }

        public _Type this[int row, int col]
        {
            get { return Rows[row][col]; }
            set { Rows[row][col] = value; }

        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.RowCount != m2.RowCount || m1.ColumnCount != m2.ColumnCount)
                throw new InvalidOperationException();
            var sum = new Matrix<_Type>(m1.RowCount, m2.ColumnCount) { };
            for (int i = 0; i < m1.RowCount; i++)
            {
                dynamic v1 = m1.Rows[i];
                dynamic v2 = m2.Rows[i];
                sum.Rows[i] = v1 + v2;

            }
            return sum;

        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.ColumnCount != m2.RowCount)
                throw new InvalidOperationException();
            var result = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            for (int i = 0; i < m1.RowCount; i++)
            {
                for (int j = 0; j < m2.ColumnCount; j++)
                {
                    for (int h = 0, k = 0; h < m1.ColumnCount; h++, k++)
                    {
                        dynamic mat1 = m1[i, h];
                        dynamic mat2 = m2[h, j];
                        result[i, j] += (mat1 * mat2);

                    }
                }
            }

            return result;

        }


        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.RowCount != m2.RowCount || m1.ColumnCount != m2.ColumnCount)
                return false;
            bool equal = true;
            for (int i = 0; i < m1.RowCount; i++)
            {
                dynamic v1 = m1.Rows[i];
                dynamic v2 = m2.Rows[i];
                if (v1 != v2)
                {
                    equal = false;
                    break;
                }

            }
            return equal;


        }

        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2) => !(m1 == m2);

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            var columnvec = new Vector<_Type>(RowCount) { };
            for (int i = 0; i < RowCount; i++)
                columnvec[i] = this[i, col];

            return (IEnumerable<_Type>)columnvec;

        }

        public override string ToString()
        {
            string tostr = "[\n";
            for (int i = 0; i < RowCount; i++)
            {
                if (i == RowCount - 1)
                {
                    tostr += $"{Rows[i].ToString()}\n";
                    break;
                }
                tostr += $"{Rows[i].ToString()},\n";

            }
            tostr += "]";
            return tostr;

        }

        protected Vector<_Type> GetColumn(int col) =>
        new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            return (this == other);
        }

        public override bool Equals(object obj)
        {
            var mat = obj as Matrix<_Type>;
            return this.Equals(mat);

        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }
    }
}