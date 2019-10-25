using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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
            // When a program is compiled the compiler uses a process called string interning to improve the efficiency of string storage.
            // The compiler will save program memory by making both s1 and s2 refer to the same string object with the content “hello.”

            string s1 = "Hello";
            string s2 = "Hello";

            // String interning only happens when the program is compiled. The following statements would make a make a new string with the content “hello” when the
            // program runs, however this string would be a different object from the string created for s1 and s2 above.
            string h1 = "He";
            string h2 = "llo";
            string s3 = h1 + h2;

            // String interning doesn’t happen when a program is running because every time a new string is created the program has to search through the list of interned
            // strings to see if that string was already present. This slows the program down.However, you can force a given string to be interned at run time by using the
            // Intern method provided by the string type. The statement here makes the string s3 refer to an interned version of the string.
            s3 = String.Intern(s3);
            // You should only do this if you discover a need to speed up the program.
        }

        // The StringBuilder type is very useful when we are writing programs that
        // build up strings.It can improve the speed of a program while at the same time making less work for the garbage collector
        public void StringBuilderUsage()
        {
            // The string addition will create the value of fullName by adding the three strings together, but it will create an intermediate string as it
            // builds the result(firstName + " ").In the case of this program a negligible effect on performance, but if a program was performing a lot of string
            // addition to build up a string of text this might result in a lot of work for the garbage collector.
            string firstName = "John";
            string lastName = "Doe";
            string fullName = firstName + " " + lastName;

            // The StringBuilder type provides methods that let a program treat a string as a mutable object.A StringBuilder is implemented by a character array.
            StringBuilder fullNameBuilder = new StringBuilder();
            fullNameBuilder.Append(firstName);
            fullNameBuilder.Append(" ");
            fullNameBuilder.Append(lastName);
            Console.WriteLine(fullNameBuilder);
            // also methods to remove strings, and Capacity = to set maximum of characteres that can be placed.
        }

        // The StringWriter class is based on the StringBuilder class. It implements the TextWriter interface, so programs can send their output into a string. 
        public void StringWriterUsage()
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine("Hello");
            writer.Close();
            Console.WriteLine(writer);
        }

        // Instances of the StringReader class implement the TextReader interface.
        // It is a convenient way of getting string input into a program that would like to read its input from a stream.
        public void StringReaderUsage()
        {
            string dataString = @"John Doe
                                45";
            StringReader dataStringReader = new StringReader(dataString);
            string name = dataStringReader.ReadLine();
            int age;
            int.TryParse(dataStringReader.ReadLine(), out age);
            dataStringReader.Close();
            Console.WriteLine("Name: {0}, Age: {1}", name, age);
        }

        // The string type provides a range of methods that can be used to find the position of substrings inside a string. 
        public void SearchStrings()
        {
            // Contains can be used to test of a string contains another string. It returns true if the source string contains the search string
            string input = "   input string here";
            if (input.Contains("str"))
            {
                Console.WriteLine("Contains str");
            }

            // The methods StartsWith and EndsWith can be used to test if a string starts or ends with a particular string.If the string starts or ends with one or
            // more whitespace characters these methods will not work.A whitespace character is a space, tab, linefeed, carriage -return, formfeed, vertical - tab or newline
            // character.There are methods you can use to trim a string.TrimStart creates a new string with whitespace removed from the start, TrimEnd removes
            // whitespace from the end of the string and Trim removes whitespace from both ends
            string trimmed = input.TrimStart();
            if (trimmed.StartsWith("in"))
            {
                Console.WriteLine("Starts with in");
            }

            // The method IndexOf returns an integer which gives the position of the first occurrence of a character or string in a string.There is also a LastIndexOf
            // method that will give the position of the last occurrence of a string.There are overloads for these methods that let you specify the start position for the search.
            // You can use these position values with the SubString method to extract a particular substring from a string.
            string inputString = "   John Doe";
            int nameStart = inputString.IndexOf("John");
            string name = inputString.Substring(nameStart, 4);
            Console.WriteLine(name);

            // The Replace method can be used to perform string editing, replacing an element of a source string.
            string formalString = inputString.Replace("John", "Johnathan");
            Console.WriteLine(formalString);

            // he Split method can be used to split a string into a number of substrings. The
            // split action returns an array of strings, it is given one or more separator strings that will be used to split the string.
            string sentence = "The cat sat on the mat.";
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            // You can request that the string comparison process takes this situation into
            // account by adding an additional parameter to string comparison operations.You can use a StringComparision value to request a range of useful behaviors.

            // here default comparison fails because strings are different
            if (!"encyclopædia".Equals("encyclopaedia"))
                Console.WriteLine("Unicode encyclopaedias are not equal");
            // Set the current culture for this thread to EN-US:
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("US");
            // Using the current culture the strings are equal:
            if ("encyclopædia".Equals("encyclopaedia", StringComparison.CurrentCulture))
                Console.WriteLine("Culture comparisons encyclopaedias are equal");
            // We can use IgnoreCase option to perform comparisons that ignore the case:
            if ("encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.CurrentCultureIgnoreCase))
                Console.WriteLine("Case culture comparisons encyclopaedias are equal");
        }

        // You can regard string as an array of characters. Program can iterate that array. Also provides Length property -> number of characters in a string
        public void EnumerateStrings()
        {
            foreach (char ch in "Hello world")
            {
                Console.WriteLine(ch);
            }
        }

        // You can use format strings to request that output be formatted in a particular way when it is printed.
        // 
        // 
        public void FormatStrings()
        {
            int i = 99;
            Double pi = 3.141592654;
            Console.WriteLine("{0,-10:D}{0,-10:X}{1,5:N2}", i, pi);
            // within {} - first param - first elem in WriteLine after string, the number of characteres to occupy (negative if to be left justified), : and formatting information 
            // D - decimal string, X - hexadecimal string, N# - floating point number with # characteres after .
            // This works because the int and double types can accept formatting commands to specify the string they are to return.A
        }

        // You can add behaviors to classes that you create to allow them to be given formatting commands in the same way.Any type that
        // implements the IFormattable interface will contain a ToString method that can be used to request formatted conversion of values into a string.
        // 
        // 
        class MusicTrack : IFormattable
        {
            public MusicTrack(string artist, string title)
            {
                Artist = artist;
                Title = title;
            }

            string Artist { get; set; }
            string Title { get; set; }

            // ToString that implements the formatting behavior
            public string ToString(string format, IFormatProvider formatProvider)
            {
                // Select the default behaviour if no format specified
                if (string.IsNullOrWhiteSpace(format))
                {
                    format = "G";
                }
                switch (format)
                {
                    case "A": return Artist;
                    case "T": return Title;
                    case "G": // default format
                    case "F": return Artist + " " + Title;
                    default:
                        throw new FormatException("Format unspecified");
                }
            }

            // ToString that overrides the behavior in the base class
            public override string ToString()
            {
                return Artist + " " + Title;
            }
        }

        // This formatting behavior can now be used when the object is being printed
        public void MusicTrackFormatter()
        {
            MusicTrack musicTrack = new MusicTrack("Mozart", "Sonata");

            Console.WriteLine("Track: {0:F}", musicTrack);
            Console.WriteLine("Track: {0:A}", musicTrack);
            Console.WriteLine("Track: {0:T}", musicTrack);
        }

        // The second parameter to the ToString method in Listing 2-73 is an object that implements the IFormatter interface. This parameter can be used by the
        // ToString method to determine any culture specific behaviors that may be required in the string conversion process.For example, you might add date of
        // recording and price information to a music track, in which case the display of the date and price information could be customized for different regions.
        // By default (i.e.unless you specify otherwise) the IFormatter reference that is passed into the ToString call is the current culture.
        // You can create a culture description and explicitly pass it into a call of ToString.
        public void FormatProvider()
        {
            // The bank balance value is stored in a double precision value and then displayed twice as a currency value using the format command ‘C.’ 
            double balance = 123.45;
            CultureInfo usProvider = new CultureInfo("en-US");
            Console.WriteLine("US balance: {0}", balance.ToString("C", usProvider)); // US balance: $123.45
            CultureInfo ukProvider = new CultureInfo("en-GB");
            Console.WriteLine("UK balance: {0}", balance.ToString("C", ukProvider)); // UK balance: £123.45
        }

        // Each placeholder is enclosed in braces { and } and a placeholder relates to a
        // particular value which is identified by its position in the arguments that follow the format string. 
        public void StringInterpolation()
        {
            string name = "John";
            int age = 45;
            Console.WriteLine("Your name: {0} and age {1,-5:D}", name, age);

            // String interpolation allows you to put the values to be converted directly into
            // the string text.An interpolated string is identified by a leading dollar ($) sign at the start of the string literal
            Console.WriteLine($"Your name: {0} and age {1,-5:D}");

            // The act of assigning a string interpolation literal in a program produces a result of type FormattedString.This provides a ToString method that accepts
            // a FormatProvider.This is useful because it allows you to use interpolated strings with culture providers. 
            double bankBalance = 123.45;
            FormattableString balanceMessage = $"US balance : {bankBalance:C}";
            CultureInfo usProvider = new CultureInfo("en-US");
            Console.WriteLine(balanceMessage.ToString(usProvider));
        }
    }
}
