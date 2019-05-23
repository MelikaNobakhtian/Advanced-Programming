using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    /// <summary>
    /// A vector of numbers. Implement vector addition and multiplication.
    /// </summary>
    /// <typeparam name="_Type"></typeparam>
    public class Vector<_Type> :
        IEnumerable<_Type>, IEquatable<Vector<_Type>>
        where _Type : IEquatable<_Type>
    {
        /// <summary>
        /// Vector data
        /// </summary>
        protected readonly _Type[] Data;

        /// <summary>
        /// Add index. Only used for collection initialization.
        /// </summary>
        protected int AddIndex = 0;

        /// <summary>
        /// Vector Size
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Add method to allow collection initialization.
        /// </summary>
        /// <param name="v"></param>
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
        }

        /// <summary>
        /// Create a new Vector
        /// </summary>
        /// <param name="length">Vector length</param>
        public Vector(int length)
        {
            this.Data = new _Type[length];
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {
            this.Data = other.Data;

        }

        /// <summary>
        /// Constructor for IEnumerable
        /// </summary>
        /// <param name="list">IEnumerable of _Type</param>
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {
            this.Data = list.ToArray<_Type>();
        }

        /// <summary>
        /// Accessor for data elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _Type this[int index]
        {
            get { return this.Data[index]; }
            set { Data[index] = value; }
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Data.Length != v2.Data.Length)
                throw new InvalidCastException("Lengths are not equal");
            Vector<_Type> sum = new Vector<_Type>(v1.Size) { };
            for (int i = 0; i < v2.Size; i++)
            {
                dynamic vec1 = v1[i];
                dynamic vec2 = v2[i];
                sum[i] = vec1 + vec2;
            }

            return sum;

        }

        /// <summary>
        /// Inner product of two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Data.Length != v2.Data.Length)
                throw new InvalidCastException("Lengths are not equal");
            dynamic result = 0;
            for (int i = 0; i < v2.Size; i++)
            {
                dynamic vec1 = v1[i];
                dynamic vec2 = v2[i];
                result += (vec1 * vec2);
            }

            return result;
        }



        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>whether v1 is equal to v2</returns>
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Size != v2.Size)
                return false;
            bool equal = true;
            for (int i = 0; i < v2.Size; i++)
            {

                dynamic vec1 = v1[i];
                dynamic vec2 = v2[i];
                if (vec1 != vec2)
                {
                    equal = false;
                    break;
                }
            }
            return equal;
        }



        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>v1 not equal to v2</returns>
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
        {
            return !(v1 == v2);
        }


        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            var vector = obj as Vector<_Type>;
            return this.Equals(vector);
        }

        /// <summary>
        /// Implementing IEquatable interface
        /// </summary>
        /// <param name="other">another vector</param>
        /// <returns>whether other vector is equal to this vector</returns>
        public bool Equals(Vector<_Type> other)
        {

            return (this == other);
        }

        public override int GetHashCode()
        {
            dynamic a = this[0];

            int hash = a;
            for (int i = 1; i < this.Size; i++)
            {
                dynamic c = this[i];
                hash ^= c;
            }
            return hash;

        }

        public override string ToString()
        {
            string vector = null;
            for (int i = 0; i < this.Size; i++)
            {
                if (i == this.Size - 1)
                {
                    vector += $"{this[i]}";
                    break;
                }
                vector += $"{this[i]},";

            }

            return $"[{vector}]";
        }

        public IEnumerator<_Type> GetEnumerator()
        {
            return ((IEnumerable<_Type>)Data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
