using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A10
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(IEnumerable<Vector<_Type>> rows) : base(rows)
        {
            if (this.RowCount != this.ColumnCount)
                throw new InvalidOperationException();
        }

        public SquareMatrix(int rowCount) : base(rowCount, rowCount)
        {
        }
    }
}