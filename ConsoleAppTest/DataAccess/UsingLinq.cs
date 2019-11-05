using ConsoleAppTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleAppTest.DataAccess
{
    // Language INtegrated Query, orLINQ, was created to make it very easy for C# programmers to work with data sources.
    public class UsingLinq
    {
        private List<Artist> _artists;
        private List<MusicTrackNew> _musicTracks;

        private List<ArtistEntity> _artistsEntyties = new List<ArtistEntity>();
        private List<MusicTrackEntity> _musicTracksEntyties = new List<MusicTrackEntity>();

        // set up data
        public void MusicTrackClasses()
        {
            string[] artistNames = new string[] { "Johny Cash", "Iggy Pop", "Led Zeppelin", "Ozzy Ozborn" };
            string[] titleNames = new string[] { "Hurt", "Passanger", "A", "B" };

            List<Artist> artists = new List<Artist>();
            List<MusicTrackNew> musicTracks = new List<MusicTrackNew>();

            Random random = new Random(1);

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                artists.Add(newArtist);

                foreach (string titleName in titleNames)
                {
                    MusicTrackNew newTrack = new MusicTrackNew
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = random.Next(20, 600)
                    };
                    // You don’t have to initialize all of the elements of the instance; any properties not initialized are set to their default values(zero for a numeric value and null
                    // for a string).The properties to be initialized in this way must all be public  members of the class.

                    musicTracks.Add(newTrack);
                }
            }

            foreach (MusicTrackNew musicTrack in musicTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}",
                    musicTrack.Artist.Name, musicTrack.Title, musicTrack.Length);
            }

            _artists = artists;
            _musicTracks = musicTracks;

            int i = 0;
            int j = 0;
            foreach (string artistName in artistNames)
            {
                ArtistEntity newArtist = new ArtistEntity { ID = i, Name = artistName };
                _artistsEntyties.Add(newArtist);

                foreach (string titleName in titleNames)
                {
                    MusicTrackEntity newTrack = new MusicTrackEntity
                    {
                        ArtistID = i,
                        Title = titleName,
                        Length = random.Next(20, 600),
                        ID = j
                    };
                    // You don’t have to initialize all of the elements of the instance; any properties not initialized are set to their default values(zero for a numeric value and null
                    // for a string).The properties to be initialized in this way must all be public  members of the class.

                    _musicTracksEntyties.Add(newTrack);
                    j++;
                }

                i++;
            }
        }

        // The LINQ query returns an IEnumerable result that is enumerated by a foreach construction.
        public void LinqOperators()
        {
            MusicTrackClasses();

            IEnumerable<MusicTrackNew> selectedTracks = from track in _musicTracks
                                                        where track.Artist.Name == "Iggy Pop"
                                                        select track;

            foreach (MusicTrackNew musicTrack in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}",
                    musicTrack.Artist.Name, musicTrack.Title, musicTrack.Length);
            }
        }

        // You can simplify code by using the var keyword to tell the compiler to infer the type of the variable being created from the context in which the variable is used.
        public void VarErrors()
        {
            MusicTrackClasses();

            // this code fails to compile:
            //var name = "Alex";
            //var age = 90;
            //var fail = age - name;
        }

        // The var keyword is especially useful when using LINQ. 
        public void VarAndLinq()
        {
            MusicTrackClasses();

            var selectedTracks = from track in _musicTracks
                                 where track.Artist.Name == "Iggy Pop"
                                 select track;

            foreach (MusicTrackNew musicTrack in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}",
                    musicTrack.Artist.Name, musicTrack.Title, musicTrack.Length);
            }
        }

        // The result of a select is a collection of references to objects in the source data collection.There are a couple of reasons why a program might not want to
        // work like this. First, you might not want to provide references to the actual data objects in the data source.Second, you might want the result of a query to
        // contain a subset of the original data.You can use projection to ask a query to “project” the data in the class onto
        // new instances of a class created just to hold the data returned by the query.
        public void LinqProjection()
        {
            MusicTrackClasses();

            var selectedTracks = from track in _musicTracks
                                 where track.Artist.Name == "Iggy Pop"
                                 select new TrackDetails
                                 {
                                     ArtistName = track.Artist.Name,
                                     Title = track.Title
                                 };

            foreach (TrackDetails trackDetails in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}", trackDetails.ArtistName, trackDetails.Title);
            }

            // Projection results like this are particularly useful when you are using data binding to display the results to the user. 
            // Values in the query result can be bound to items to be displayed.
        }

        // You can remove the need to create a class to hold the result of a search query by making the query return results of an anonymous type.
        public void AnonymousType()
        {
            MusicTrackClasses();

            // The item that is returned by this query is an enumerable collection of
            // instances of a type that has no name. It is an anonymous type.This means you have to use a var reference to refer to the query result

            var selectedTracks = from track in _musicTracks
                                 where track.Artist.Name == "Iggy Pop"
                                 select new // projection type name missing
                                 {
                                     ArtistName = track.Artist.Name,
                                     track.Title // the property is created with same name as the source property, in this case the property name will be Title
                                 };

            foreach (var item in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}", item.ArtistName, item.Title);
            }
        }

        // LINQ provides a join operator that can be used to join the output of one LINQ query to the input of another.
        public void LinqJoin()
        {
            MusicTrackClasses();

            var selectedTracks = from artist in _artistsEntyties
                                 where artist.Name == "Iggy Pop"
                                 join track in _musicTracksEntyties on artist.ID equals track.ArtistID
                                 select new
                                 {
                                     ArtistName = artist.Name,
                                     track.Title
                                 };

            foreach (var item in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}", item.ArtistName, item.Title);
            }
        }

        // Another useful LINQ feature is the ability to group the results of a query to create a summary output. For example, you may want to create a query to 
        // tell how many tracks there are by each artist in the music collection.
        public void LinqGroup()
        {
            MusicTrackClasses();

            var artistSummary = from track in _musicTracksEntyties
                                join artist in _artistsEntyties on track.ArtistID equals artist.ID
                                group track by artist.Name
                                into artistTrackSummary
                                select new
                                {
                                    ID = artistTrackSummary.Key,
                                    Count = artistTrackSummary.Count()
                                };

            foreach (var item in artistSummary)
            {
                Console.WriteLine("Artist: {0}, Count: {1}", item.ID, item.Count);
            }
        }

        // A LINQ query will normally return all of	the	items that if finds. However, this might be	more items that your program wants.	
        // For example, you might want to show the user the output one page at a time. You can use take to tell the query to take	
        // a particular number of items and the skip to tell a query to skip a particular number of items in the result before	
        // taking the requested number. 
        public void LinqTakeAndSkip()
        {
            MusicTrackClasses();

            int pageNo = 0;
            int pageSize = 10;

            while (true)
            {               // Get the track information	
                var	trackList = from musicTrack in _musicTracksEntyties.Skip(pageNo*pageSize)
                                .Take(pageSize)	join artist in _artistsEntyties	on musicTrack.ArtistID equals artist.ID
                                select	new
                                {
                                    ArtistName = artist.Name,
                                    musicTrack.Title
                                };
                //	Quit if	we reached the end of the data				
                if	(trackList.Count()	==	0)
                    break;
                //	Display	the	query	result				
                foreach	(var item in trackList)
                {
                    Console.WriteLine("Artist:{0} Title:{1}",												
                        item.ArtistName, item.Title);
                }
                Console.Write("Press any key to continue");
                Console.ReadKey();
                //	move on	to the	next page 
                pageNo++; 
            }
        }

        // 
        public void LinqAggregate()
        {
            MusicTrackClasses();

        }

        // 
        public void MethodBasedQuery()
        {
            MusicTrackClasses();

        }

        // 
        public void ComplexQuery()
        {
            MusicTrackClasses();

        }

        // 
        public void ComplexAnonymousTypes()
        {
            MusicTrackClasses();

        }

        // 
        public void ForceQueryExecution()
        {
            MusicTrackClasses();

        }

        // 
        public void ReadXmlWithLinq()
        {
            MusicTrackClasses();

        }

        // 
        public void FilterXmlWithLinq()
        {
            MusicTrackClasses();

        }

        // 
        public void CreateXmlWithLinq()
        {
            MusicTrackClasses();

        }

        // 
        public void ModifyXmlWithLinq()
        {
            MusicTrackClasses();

        }

        // 
        public void AddXmlWithLinq()
        {
            MusicTrackClasses();

        }
    }


    // Entyties with primary keys
    public class MusicTrackEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int ArtistID { get; set; }

    }

    public class ArtistEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    // Rollstuhl
    // 
}
