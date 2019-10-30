using MusicTracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Services
{
    // 
    public class ValidateAppInput
    {
        // Naughty PrintTrack method that changes the Artist property of the track being printed.
        static void PrintTrack(MusicTrack track)
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

        // 
        public void SimpleRegularExpression()
        {

        }

        // 
        public void MatchMultipleSpaces()
        {

        }

        // 
        public void ValidateMusicTrack()
        {

        }

        // 
        public void ValidateTrackLength()
        {

        }

        // 
        public void PerfectValidation()
        {

        }

        // 
        public void UsingTryParse()
        {

        }

        // 
        public void UsingConvert()
        {

        }

        // 
        public void AspValidation()
        {

        }
    }
}
