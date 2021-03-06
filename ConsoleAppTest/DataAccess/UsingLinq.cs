﻿using ConsoleAppTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

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
            {               
                // Get the track information
                var	trackList = from musicTrack in _musicTracksEntyties.Skip(pageNo*pageSize)
                                .Take(pageSize)	join artist in _artistsEntyties	on 
                                musicTrack.ArtistID equals artist.ID
                                select new
                                {
                                    ArtistName = artist.Name,
                                    musicTrack.Title
                                };
                // Quit if we reached the end of the data
                if	(trackList.Count()	==	0)
                    break;
                // Display the query result	
                foreach	(var item in trackList)
                {
                    Console.WriteLine("Artist:{0} Title:{1}",												
                        item.ArtistName, item.Title);
                }
                Console.Write("Press any key to continue");
                Console.ReadKey();
                // move on to the next page 
                pageNo++; 
            }
        }

        // In the context of LINQ commands, the word aggregate means “bring together a number of related values to create a single result.” You can use aggregate
        // operators on the results produced by group operations.You may want to get the total length of all the tracks assigned to an artist, and for that you can use
        // the Sum aggregate operator. The parameter to the Sum operator is a lambda expression that the operator
        // will use on each item in the group to obtain the value to be added to the total sum for that item. To get the sum of MusicTrack lengths, the lambda
        // expression just returns the value of the Length property for the item.
        public void LinqAggregate()
        {
            MusicTrackClasses();

            var artistSummary = from track in _musicTracksEntyties
                                join artist in _artistsEntyties on track.ArtistID equals artist.ID
                                group track by artist.Name
                                into artistTrackSummary
                                select new
                                {
                                    ID = artistTrackSummary.Key,
                                    Length = artistTrackSummary.Sum(x => x.Length)
                                };

            foreach (var item in artistSummary)
            {
                Console.WriteLine("Artist: {0}, Total Length: {1}", item.ID, item.Length);
            }

            // You can use Average, Max, and Min to generate other items of aggregate information.You can also create your own Aggregate behavior that will be
            // called on each successive item in the group and will generate a single aggregate result.
        }

        // The query statement uses query comprehension syntax, which includes the operators from, in, where, and select.The compiler uses these to generate
        // a call to the Where method on the MusicTracks collection.
        // The Where method accepts a lambda expression as a parameter.
        public void MethodBasedQuery()
        {
            MusicTrackClasses();

            // method based implementation of query from void LinqOperators()
            var selectedTracks = _musicTracks.Where(track => track.Artist.Name == "Iggy Pop");

            foreach (MusicTrackNew musicTrack in selectedTracks)
            {
                Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}",
                    musicTrack.Artist.Name, musicTrack.Title, musicTrack.Length);
            }

            // Programs can use the LINQ query methods (and execute LINQ queries) on data collections, such as lists and arrays, and also on database connections. The
            // methods that implement LINQ query behaviors are not added to the classes that use them. Instead they are implemented as extension methods.
        }

        // The phrase “query comprehension syntax” refers to the way that you can build LINQ queries for using the C# operators provided specifically for expressing
        // data queries.The intention is to make the C# statements that strongly resemblethe SQL queries that perform the same function.This makes it easier for
        // developers familiar with SQL syntax to use LINQ.
        public void ComplexQuery()
        {
            MusicTrackClasses();

            var artistSummary = from track in _musicTracksEntyties
                                join artist in _artistsEntyties on track.ArtistID equals artist.ID
                                group track by artist.Name
                                into artistTrackSummary
                                select new
                                {
                                    ID = artistTrackSummary.Key,
                                    Length = artistTrackSummary.Sum(x => x.Length)
                                };

            foreach (var item in artistSummary)
            {
                Console.WriteLine("Artist: {0}, Total Length: {1}", item.ID, item.Length);
            }
        }

        // You first saw the use of anonymous types in the “Anonymous types” section earlier in this chapter.The last few sample programs have shown the use of
        // anonymous types moving from creating values that summarize the contents of a source data object (for example extracting just the artist and title information
        // from a MusicTrack value), to creating completely new types that contain data from the database and the results of aggregate operators.
        // It is important to note that you can also create anonymous type instances in method-based SQL queries.
        public void ComplexAnonymousTypes()
        {
            MusicTrackClasses();

            var artistSummary = _musicTracksEntyties.Join(
                    _artistsEntyties,
                    track => track.ArtistID,
                    artist => artist.ID,
                    (track, artist) => new
                    {
                        track = track,
                        artist = artist
                    }
                )
                .GroupBy(
                    temp0 => temp0.artist.Name,
                    temp0 => temp0.track
                )
                .Select(
                    artistTrackSummary => 
                    new
                    {
                        ID = artistTrackSummary.Key,
                        Length = artistTrackSummary.Sum(x => x.Length)
                    }
                );

            foreach (var item in artistSummary)
            {
                Console.WriteLine("Artist: {0}, Total Length: {1}", item.ID, item.Length);
            }
        }

        // The result of a LINQ query is an item that can be iterated. We have used the foreach construction to display the results from queries. The actual evaluation 
        // of a LINQ query normally only takes place when a program starts to extract results from the query. This is called deferred execution. If you want to	
        // force the execution of a query you can use the ToArray() method
        public void ForceQueryExecution()
        {
            MusicTrackClasses();

            var selectedTracksQuery = from artist in _artistsEntyties
                                 where artist.Name == "Iggy Pop"
                                 join track in _musicTracksEntyties on artist.ID equals track.ArtistID
                                 select new
                                 {
                                     ArtistName = artist.Name,
                                     track.Title
                                 };

            var selectedTracksResult = selectedTracksQuery.ToArray();

            foreach (var item in selectedTracksResult)
            {
                Console.WriteLine("Artist: {0}, Total Length: {1}", item.ArtistName, item.Title);
            }

            // A query result also provides ToList and ToDictionary methods that will force the execution of the query and generate an immediate result of that 
            // type.	
        }

        private static string XMLText = 
            "<MusicTracks>" + 
                "<MusicTrack>" + 
                    "<Artist>Rob Miles</Artist>" + 
                    "<Title>My Way</Title>" + 
                    "<Length>150</Length>" + 
                "</MusicTrack>" +
                "<MusicTrack>" + 
                    "<Artist>Immy Brown</Artist>" + 
                    "<Title>Her	Way</Title>" + 
                    "<Length>200</Length>" + 
                "</MusicTrack>" + 
            "</MusicTracks>";

        private XDocument _musicTracksDocument = XDocument.Parse(XMLText);

        // The format of LINQ queries is slightly different when working with XML. This is because the source of the query is a filtered set of XML entries from	
        // the source document
        public void ReadXmlWithLinq()
        {
            IEnumerable<XElement> selectedTracks = from track in _musicTracksDocument.Descendants("MusicTrack")
                                 select track;

            foreach (XElement item in selectedTracks)
            {
                Console.WriteLine("Artist:{0} Title:{1}", 
                    item.Element("Artist").FirstNode, item.Element("Title").FirstNode);
            }
        }

        // A program can perform filtering in the query by adding a where operator, just as with the LINQ we have seen before.	
        public void FilterXmlWithLinq()
        {
            IEnumerable<XElement> selectedTracks = from track in _musicTracksDocument.Descendants("MusicTrack")
                                                   where (string)track.Element("Artist") == "Rob Miles"
                                                   select track;


            // The LINQ queries that we have seen so far have been expressed using query comprehension. It is possible, however, to express the same query in the	
            // form	of a method-based query. The Descendants method returns an object that provides the Where behavior.
            selectedTracks = _musicTracksDocument.Descendants("MusicTrack")
                             .Where(track => (string)track.Element("Artist") == "Rob Miles");

        }

        // The LINQ to XML features include very easy way to create XML documents
        public void CreateXmlWithLinq()
        {
            XElement musicTracks = new XElement("Music Tracks", 
                new List<XElement>
                {
                    new XElement("Music Track", 
                        new XElement("Artist","A"),
                        new XElement("Title","Track1")),
                    new XElement("Music Track",
                        new XElement("Artist","B"),
                        new XElement("Title","Track2"))
                });

        }

        // The XElement class provides methods that can be used to modify the contents of a given XML element.
        public void ModifyXmlWithLinq()
        {
            IEnumerable<XElement> selectedTracks = from track in _musicTracksDocument.Descendants("MusicTrack")
                                                   where (string)track.Element("Title") == "My Way"
                                                   select track;

            foreach (XElement item in selectedTracks)
            {
                item.Element("Title").FirstNode.ReplaceWith("stuff");
            }
        }

        // As you saw when creating a new XML document, an XElement can contain a collection of other elements to build the tree	
        // structure of an XML document. You can programmatically add and remove elements to change the structure of the XML document. 
        public void AddXmlWithLinq()
        {
            IEnumerable<XElement> selectedTracks = from track in _musicTracksDocument.Descendants("MusicTrack")
                                                   where (string)track.Element("Style") == null
                                                   select track;

            foreach (XElement item in selectedTracks)
            {
                item.Add(new XElement("Style", "Pop"));
            }
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
