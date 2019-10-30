using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.DebugAndSecurity
{
    // The	first	step	in	creating	a	secure	application	is	ensuring	that	incoming	data	is valid.	Data	in	your	applications	
    // must	come	from	somewhere;	whether	it	is	items entered	into	the	application	user	interface,	or	packets	of	formatted	values received
    // from	another	application.	In	every	case	you	need	to	make	sure	that	your application	is	resilient	in	its	response
    // to	invalid	data.	You	also	need	to	keep	in mind	that	invalid	data	may	have	been	entered	with	malicious	intent.	
    // It	is important	that	a	poorly	thought	out	response	to	invalid	data	doesn’t	expose	your systems	to	attack. 
    // A	JSON	document	contains	a	number	of	name/value	pairs	that	represent	the	data in	an	application.	A	JSON	document	
    // can	also	contain	arrays	of	JSON	objects. JSON	documents	map	very	well	onto	objects	in	an	object-oriented	language, although	
    // JSON	itself	is	not	tied	to	any	one	programming	language.	JSON	is therefore	very	useful	if	you	want	to	share	data	
    // between	programs	written	in different	languages. 
    public class ValidateInput
    {
        // When you start to use JSON in your programs there are a few things that you need to be aware of from a security and class design point of view:
        // If you want to save and load private properties in a class you need to mark these items with the [JsonProperty] attribute.
        // If you want to serialize a class using JSON you don’t have to add the  [Serializable] attribute to the class
        // When loading a class back using JSON you need to provide the type into which the result is to be stored.No type information is stored in the file that is stored.
        public void CreatingJson()
        {
            MusicTrack track = new MusicTrack("Kanye West", "Selah", 300);
            string json = JsonConvert.SerializeObject(track);
            Console.WriteLine("JSON: {0}", json);

            MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(json);
            Console.WriteLine("Read back: {0}", trackRead);

            List<MusicTrack> album = new List<MusicTrack>();
            string[] trackNames = new[] { "Lift your skinny fists", "Mladic", "Dead flag blues", "Sleep" };
            foreach (string trackName in trackNames)
            {
                MusicTrack newTrack = new MusicTrack("GY!BE", trackName, 200);
                album.Add(newTrack);
            }
            string jsonArray = JsonConvert.SerializeObject(album);
            Console.WriteLine("JSON array: {0}", jsonArray);
            List<MusicTrack> albumRead = JsonConvert.DeserializeObject<List<MusicTrack>>(jsonArray);
            Console.WriteLine("Read back: ");
            foreach (MusicTrack musicTrack in albumRead)
            {
                Console.WriteLine(musicTrack);
            }
        }

        // 
        public void CreatingXml()
        {

        }

        // 
        public void ValidatingJson()
        {

        }


    }

    public class MusicTrack
    {
        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }

        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        //	ToString	that	overrides	the	behavior	in	the	base	class				
        public	override	string	ToString()
        {
            return	Artist + " " + Title + " " + Length.ToString() + " seconds long" ;
        }
    }
}
