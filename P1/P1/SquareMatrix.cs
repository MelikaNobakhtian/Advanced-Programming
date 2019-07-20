using System;
using System.Collections.Generic;

namespace P1
{
    public class SquareMatrix<_Type> : Matrix<_Type>
        where _Type : IEquatable<_Type>
    {
        public SquareMatrix(IEnumerable<Vector<_Type>> rows) : base(rows)
        {
            if (RowCount != ColumnCount)
                throw new InvalidOperationException();
        }

        public SquareMatrix(int rowCount) : base(rowCount, rowCount)
        {
        }

        public SquareMatrix<_Type> CreateSmallerMatrix(SquareMatrix<_Type> matrix, int i, int j)
        {
            var order = matrix.RowCount;
            var smallerMatrix = new SquareMatrix<_Type>(order - 1);
            int x = 0, y = 0;
            for (var m = 0; m < order; m++, x++)
                if (m != i)
                {
                    y = 0;
                    for (var n = 0; n < order; n++)
                        if (n != j)
                        {
                            smallerMatrix[x, y] = matrix[m, n];
                            y++;
                        }
                }
                else
                {
                    x--;
                }

            return smallerMatrix;
        }

        public int SignOfElement(int i, int j)
        {
            return (i + j) % 2 == 0 ? 1 : -1;
        }

        public double Determinant(SquareMatrix<_Type> matrix)
        {
            var order = matrix.RowCount;
            if (order > 2)
            {
                double value = 0;
                for (var j = 0; j < order; j++)
                {
                    var Temp = CreateSmallerMatrix(matrix, 0, j);
                    value = value + (dynamic)matrix[0, j] * (SignOfElement(0, j) * Determinant(Temp));
                }

                return value;
            }

            if (order == 2)
                return (dynamic)matrix[0, 0] * (dynamic)matrix[1, 1] -
                       (dynamic)matrix[1, 0] * (dynamic)matrix[0, 1];
            return (double)(dynamic)matrix[0, 0];
        }

        public SquareMatrix<double> MatchingMatrix()
        {
            var mat = new SquareMatrix<double>(RowCount);
            for (var i = 0; i < RowCount; i++)
                for (var j = 0; j < RowCount; j++)
                    mat[i, j] = SignOfElement(i, j) * Determinant(CreateSmallerMatrix(this, i, j));

            return mat;
        }

        public SquareMatrix<_Type> TranslatedMatrix()
        {
            var mat = new SquareMatrix<_Type>(RowCount);
            for (var i = 0; i < RowCount; i++)
                for (var j = i; j < RowCount; j++)
                {
                    var tmp = this[i, j];
                    mat[i, j] = this[j, i];
                    mat[j, i] = tmp;
                }

            return mat;
        }

        public SquareMatrix<double> InverseMatrix()
        {
            var det = Determinant(this);
            var mat = TranslatedMatrix().MatchingMatrix();
            for (var i = 0; i < RowCount; i++)
                for (var j = 0; j < RowCount; j++)
                    mat[i, j] = mat[i, j] / det;

            return mat;
        }
    }
}