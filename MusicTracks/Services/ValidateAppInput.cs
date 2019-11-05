using MusicTracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicTracks.Services
{
    // 
    public class ValidateAppInput
    {
        // Naughty PrintTrack method that changes the Artist property of the track being printed.
        private void PrintTrack(MusicTrack track)
        {
            track.Artist = "Invalid artist";
        }

        // Note	that the use of copies of objects is also a good idea when creating multithreaded applications. If you are concerned about other threads 
        // making changes to a MusicTrack while it is being printed; creating a copy of the MusicTrack to be printed removes this possibility. Remember, 
        // however,	that you don’t need to do this if the parameter being supplied to the method is a value type. In other words, if the MusicTrack parameter 
        // in the previous example was a structure rather than a class, the method would automatically receive a copy of the value, not a reference to a 
        // MusicTrack object. Note that this does not mean that you should use structures in preference to classes to improve security. 
        public void CopyConstructor()
        {
            MusicTrack track = new MusicTrack("Queen", "Rapsody", 400);
            // Use the copy constructor to send a copy of the track to be printed. Changes made by the PrintTrack method will have no effect
            PrintTrack(new MusicTrack(track));
            Console.WriteLine(track.Artist);
        }

        // C# contains an implementation of regular expressions that can be used to perform data validation. A regular expression is a means of expressing a 
        // string of characters that need to be matched in a target string.	
        // A regular expression can be as simple as just a single character to match.
        //  System.Text.RegularExpressions namespace
        public void SimpleRegularExpression()
        {
            string input = "Rob Alex John David Erich Kevin Joseph";

            string regularExpressionToMatch = " ";
            string patternToReplace = ",";

            string replaced = Regex.Replace(input: input, pattern: regularExpressionToMatch, replacement: patternToReplace);
            Console.WriteLine(replaced);
        }

        // how to modify an expression to match one or more spaces in a string of names.The + character after an element is used as a quantifier in
        // the regular expression.It creates an expression that matches that element one ormore times.The regular expression can be used to replace any number of spaces
        // in an element with a single comma.
        public void MatchMultipleSpaces()
        {
            string input = "Rob     Alex John  David Erich  Kevin       Joseph";

            string regularExpressionToMatch = " +";
            string patternToReplace = ",";

            string replaced = Regex.Replace(input: input, pattern: regularExpressionToMatch, replacement: patternToReplace);
            Console.WriteLine(replaced);
        }

        // . -> match any character
        // .+ -> match one or more of any characters
        // IsMatch -> returns true if matches
        public void ValidateMusicTrack()
        {
            string input = "Ernst Busch:Der heimliche Aufsmarsch:140";

            string regexToMatch = ".+:.+:.+";
            if (Regex.IsMatch(input, regexToMatch))
            {
                Console.WriteLine("Music track is valid");
            }
        }

        // [ch-ch] -> any character in range; [0-9] -> any digit; [0-9] -> one or more digits
        // $ -> another character at the end of the string; @ -> to be processed by compiler as verbatim string -> no attempt to process escape characters
        public void ValidateTrackLength()
        {
            string input = "Ernst Busch:Der heimliche Aufsmarsch:140";

            string regexToMatch = @".+:.+:[0-9]+$";
            if (Regex.IsMatch(input, regexToMatch))
            {
                Console.WriteLine("Music track is valid");
            }
        }

        // ^-> the start of the line; | -> or 
        public void PerfectValidation()
        {
            string input = "Ernst Busch:Der heimliche Aufsmarsch:140";

            string regexToMatch = @"^([a-z]|[A-Z])+:([a-z]|[A-Z])+:[0-9]+$";
            if (Regex.IsMatch(input, regexToMatch))
            {
                Console.WriteLine("Music track is valid");
            }
        }

        // TODO: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions


        // The simplest form of conversion is that of a string of digits into a numeric value.The C# numeric types all provide a Parse method that will convert a string into
        // a number.The Parse method will not allow invalid strings to be converted into numbers, but it rejects invalid values by throwing an exception, which seems a
        // little extreme.I reserve exceptions for events, which are more unexpected than auser typing ‘o’ instead of ‘0’. All numeric types also provide a TryParse
        // method that will attempt to parse a string and return False if the parse fails.
        public void UsingTryParse()
        {
            int result;

            if (int.TryParse("99", out result))
            {
                Console.WriteLine("This is a valid number");
            }
            else
            {
                Console.WriteLine("This is not a valid number");
            }
        }

        // The C# library also contains a Convert class that can be used to convert between various types.
        // The Convert method will throw an exception if the conversion fails, but not if the input value is null.
        public void UsingConvert()
        {
            string stringValue = "99";

            int intValue = Convert.ToInt32(stringValue);
            Console.WriteLine("intValue: {0}", intValue);

            stringValue = "True";
            bool boolValue = Convert.ToBoolean(stringValue);
            Console.WriteLine("boolValue: {0}", boolValue);
        }

        // goto MusicTrack model
        public void AspValidation()
        {

        }
    }
}
