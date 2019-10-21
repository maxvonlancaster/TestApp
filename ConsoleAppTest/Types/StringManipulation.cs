using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    // The c# type string (lower case s) is mapped onto the .net type String (upper case S). Can hold very large amount of text.
    // Theoretical limit - 2gb, practical lower.
    public class StringManipulation
    {
        // Strings in C# are managed by reference, but string values are immutable, which
        // means that the contents of a string can’t be changed once the string has been
        // created.If you want to change the contents of a string you have to make a new
        // string. All string editing functions return a new string with the edited content.
        //  The string being edited is never changed.This ensures that strings are thread
        // safe. There is no need to worry about code on another thread changing the
        // contents of a string that a given thread is using.
        // The downside of this approach is that if you perform a lot of string editing you
        // will end up creating a lot of string objects. 
        public void StringIntern()
        {
            string s1 = "Hello";
            string s2 = "Hello";

        }

        // 
        //
        //
        public void StringBuilderUsage()
        {

        }

        // 
        // 
        // 
        public void StringWriterUsage()
        {

        }

        // 
        // 
        //
        public void StringReaderUsage()
        {

        }

        // 
        // 
        // 
        public void EnumerateStrings()
        {

        }

        //
        // 
        // 
        public void FormatStrings()
        {

        }

        // 
        // 
        // 
        class MusicTrackFormatter
        {

        }

        // 
        // 
        // 
        public void FormatProvider()
        {

        }

        // 
        // 
        // 
        public void StringInterpolation()
        {

        }



    }
}
