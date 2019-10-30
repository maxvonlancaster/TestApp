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
        // 
        public void CreatingJson()
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
            return	Artist + " " + Title + " " + Length.ToString() + "seconds long" ;
        }
    }
}
