using System;

namespace Storage
{
    public class Track
    {
        public Track(string artist, string title, int length)
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
