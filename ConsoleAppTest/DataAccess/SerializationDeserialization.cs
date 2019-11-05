using System;
using System.Collections.Generic;
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
        // 
        public void BinarySerialization()
        {

        }

        // 
        public void CustomSerialization()
        {

        }

        public void CustomizationMethods()
        {

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


    class ArtistSerializable
    {
        public string Name { get; set; }
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
        List<ArtistSerializable> Artists = new List<ArtistSerializable>();
        List<MusicTrackSerializable> MusicTracks = new List<MusicTrackSerializable>();
        public static MusicDataStore TestData()
        {
            MusicDataStore result = new MusicDataStore();
            // create the same test data set as	used for the LINQ examples								
            return result;
        }
    } 
}
