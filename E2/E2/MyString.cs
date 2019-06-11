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
            string r = obj as string;
            
            MyString s =(MyString)r;
            return (this == s);
        }

        public static bool operator==(MyString @string,string s)
        {
            if (@string.Mystr == s)
                return true;
            return false;
        }

        public static bool operator ==(MyString @string,MyString s)
        {
            if (@string.Mystr == s.Mystr)
                return true;
            return false;
        }

        public static bool operator !=(MyString @string, MyString s)
        {
            return !(@string == s);
        }


        public static bool operator!=(MyString @string, string s)
        {
            return !(@string == s);
        }

        public static explicit operator MyString(string v)
        {
            MyString my = new MyString(v);
            return my;
        }

        public static MyString operator ++(MyString m)
        {
            MyString v = new MyString(m.Mystr.ToUpper());
            return v;
        }

        public static MyString operator --(MyString m)
        {
            MyString v = new MyString(m.Mystr.ToLower());
            return v;
        }

        public static explicit operator string(MyString v)
        {
            return v.Mystr;
        }
    }
}