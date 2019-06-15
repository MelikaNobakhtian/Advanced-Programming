using System;
using System.Collections.Generic;

namespace E2
{
    public class MyString
    {
        public string Mystr;
        public MyString(string s)
        {
            Mystr = s;
        }

        public override bool Equals(object obj)
        {
            string str = obj as string;
            MyString result =(MyString)str;
            return (this == result);
        }

        public static bool operator ==(MyString @string, string s) => (@string.Mystr == s);

        public static bool operator ==(MyString @string, MyString s) => (@string.Mystr == s.Mystr);

        public static bool operator !=(MyString @string, MyString s) => !(@string == s);

        public static bool operator !=(MyString @string, string s) => !(@string == s);

        public static explicit operator MyString(string v)
        {
            MyString mystring = new MyString(v);
            return mystring;
        }

        public static MyString operator ++(MyString m)
        {
            MyString plusplus = new MyString(m.Mystr.ToUpper());
            return plusplus;
        }

        public static MyString operator --(MyString m)
        {
            MyString minusminus = new MyString(m.Mystr.ToLower());
            return minusminus;
        }

        public static explicit operator string(MyString v)=> v.Mystr;

    }
}