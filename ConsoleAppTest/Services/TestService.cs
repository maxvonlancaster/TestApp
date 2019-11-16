using ConsoleAppTest.DebugAndSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Services
{
    public class TestService
    {
        public void TestMethod()
        {
            var переменная = "Cyrillic variable";
            Console.WriteLine(переменная);

            for (var i = 0; i < 10; i++) { }

            MusicTrack t = new MusicTrack() { Artist = "A"};
            PassByValue(t);
            Console.WriteLine(t.Artist);
            PassByRef(ref t);
            Console.WriteLine(t.Artist);
        }

        private void PassByValue(MusicTrack track)
        {
            track.Artist = "B";
        }

        private void PassByRef(ref MusicTrack track)
        {
            track.Artist = "C";
        }
    }
}
