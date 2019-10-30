using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Models
{
    public class MusicTrack
    {
        // Copy constructor for MusicTrack
        public MusicTrack(MusicTrack source)
        {
            Artist = source.Artist;
            Title = source.Title;
            Length = source.Length;
        }
        // If you want to be sure that a method can’t change the contents of an object that it is given a reference to, you will have to copy the object
        // and pass the method a reference to the copy. You can make it easy to do this by create a method called a copy constructor for the MusicTrack class.	

        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }

        public int ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }
}
