using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;

namespace ConsoleAppTest.DataAccess
{
    // Serialization does not store any of the active elements in an object. The behaviors (methods) in a class are not stored when it is serialized. This means 
    // that the application deserializing the data must have implementations of the classes that can be used to manipulate the data after it has been read. 
    // Serialization is a complex process. If a data structure contains a graph of objects that have a large number of associations between them, the serialization 
    // process will have to persist each of these associations in the stored file. Serialization is	best used for transporting data between	applications. You can 
    // think of it as transferring the “value” of an object from one place to another. Serialization can be for persisting data, and a serialized stream can be 
    // directed	into a file, but this is not normally how applications store their state. Using	serialization can lead to problems if the structure	or behavior	of	
    // the classes implementing the data storage changes during the lifetime of	the application. In	this situation developers may find that previously serialized	
    // data is not compatible with the new design. 
    public class SerializationDeserialization
    {
        // There are essentially two kinds of serialization that a program can use: binary  serialization and text serialization.
        // Binary serialization imposes its own format on the data that is being serialized, mapping
        // the data onto a stream of 8-bit values.The data in a stream created by a binaryserializer can only be read by a corresponding binary de-serializer.Binary
        // serialization can provide a complete “snapshot” of the source data. Both publicand private data in an object will be serialized, and the type of each data item is preserved
        public void BinarySerialization()
        {
            MusicDataStore data = MusicDataStore.TestData();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream outputStream =
                new FileStream("MusicTracks.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, data);
            }

            MusicDataStore inputData;

            using (FileStream inputStream =
                new FileStream("MusicTracks.bin", FileMode.Open, FileAccess.Read))
            {
                inputData = (MusicDataStore)formatter.Deserialize(inputStream);
            }

            foreach (var item in inputData.Artists)
            {
                Console.WriteLine(item.Name);
            }

            // Binary serialization is the only serialization technique that serializes private data members by default(i.e.without the developer asking). A file created by a
            // binary serializer can contain private data members from the object being serialized.Note, however, that once an object has serialized there is nothing to
            // stop a devious programmer from working with serialized data, perhaps viewing and tampering with the values inside it.This means that a program should treat
            // deserialized inputs with suspicion.Furthermore, any security sensitive information in a class should be explicitly marked NonSerialized.One way
            // to improve security of a binary serialized file is to encrypt the stream before it is stored, and decrypt it before deserialization.
        }

        // Sometimes it might be necessary for code in a class to get control during the serialization process.You might want to add checking information or encryption
        // to data elements, or you might want to perform some custom compression of the data. There are two ways that to do this. The first way is to create our own
        // implementation of the serialization process by making a data class implement the ISerializable interface.
        // A class that implements the ISerializable interface must contain a GetObjectData method.This method will be called when an object is
        // serialized.It must take data out of the object and place it in the output stream.The class must also contain a constructor that will initialize an instance of the
        // class from the serialized data source.
        [Serializable]
        public class ArtistSer : ISerializable
        {
            public ArtistSer()
            {
            }

            public ArtistSer(SerializationInfo info, StreamingContext context)
            {
                Name = info.GetString("name");
            }

            public string Name { get; set; }

            [SecurityPermissionAttribute(SecurityAction.Demand)]
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("name", Name);
            }

            // The constructor for the Artist type accepts info and context parameters and uses the GetString method on the info parameter to obtain
            // the name information from the serialization stream and use it to set the value of the Name property of the new instance.
        }

        // he second way of customizing the serialization process is to add methods that will be called during serialization.These are identified by attributes
        [Serializable]
        public class ArtistCustom
        {
            [OnSerializing()]
            internal void OnSerializingMethod(StreamingContext context)
            {
                Console.WriteLine("Called before the artist is serialized");
            }

            [OnSerialized()]
            internal void OnSerializedMethod(StreamingContext context)
            {
                Console.WriteLine("Called after the artist is serialized");
            }

            [OnDeserializing()]
            internal void OnDeserializingMethod(StreamingContext context)
            {
                Console.WriteLine("Called before the artist is deserialized");
            }

            [OnDeserialized()]
            internal void OnDeserializedMethod(StreamingContext context)
            {
                Console.WriteLine("Called after the artist is deserialized");
            }
        }

        // 
        public void BinaryVersions()
        {

        }

        // 
        public void XmlSerialization()
        {

        }

        // 
        public void XmlReferences()
        {

        }

        // 
        public void DataContractSerializer()
        {

        }
    }


    // Classes to be serialized by the binary serializer must be marked with the [Serializable] attribute
    [Serializable]
    class ArtistSerializable
    {
        public string Name { get; set; }

        [NonSerialized]
        int tempData;
    }

    [Serializable]
    class MusicTrackSerializable
    {
        public ArtistSerializable Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }

    [Serializable]
    class MusicDataStore
    {
        public List<ArtistSerializable> Artists = new List<ArtistSerializable>();
        public List<MusicTrackSerializable> MusicTracks = new List<MusicTrackSerializable>();
        public static MusicDataStore TestData()
        {
            MusicDataStore result = new MusicDataStore();
            result.Artists = new List<ArtistSerializable>
            {
                new ArtistSerializable() { Name = "Art1"},
                new ArtistSerializable() { Name = "Art2"},
                new ArtistSerializable() { Name = "Art3"},
                new ArtistSerializable() { Name = "Art4"},
                new ArtistSerializable() { Name = "Art5"}
            };
            result.MusicTracks = new List<MusicTrackSerializable>
            {
                new MusicTrackSerializable() { Artist = result.Artists[0], Title = "Title1", Length = 100 },
                new MusicTrackSerializable() { Artist = result.Artists[0], Title = "Title2", Length = 200 },
                new MusicTrackSerializable() { Artist = result.Artists[1], Title = "Title3", Length = 100 },
                new MusicTrackSerializable() { Artist = result.Artists[1], Title = "Title4", Length = 300 },
                new MusicTrackSerializable() { Artist = result.Artists[1], Title = "Title5", Length = 200 },
            };
            // create the same test data set as	used for the LINQ examples								
            return result;
        }
    }
}
