using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ConsoleAppTest.DataAccess
{
    // File access is a very slow activity when compared with the speed of modern processors, so we are also going to investigate the use of
    // asynchronous i/o, which can be used to keep an application responsive even when it is reading or writing large amounts of data.
    public class IOOperations
    {
        // A stream is a software object that represents a stream of data. The .NET
        // framework provides a Stream class that serves as the parent type for a range of classes that can be used to read and write data.
        // Write, read and position the "file pointer".

        // The FileStream object provides a stream instance connected to a file. The stream object instance converts calls into the stream into commands for the
        // filesystem on the computer running the program.The file system provides the interface to the physical device performing the data storage for the computer
        // c# app <-> stream object <-> Filestream <-> storage device
        public void UsingAFileStrem()
        {
            // Writing to a file
            FileStream outputStream = new FileStream("OutputText.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string outPutMessageString = "Hello world";
            byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outPutMessageString);
            outputStream.Write(outputMessageBytes);
            outputStream.Close();

            FileStream inputStream = new FileStream("OutputText.txt", FileMode.OpenOrCreate, FileAccess.Read);
            long fileLength = inputStream.Length;
            byte[] readBytes = new byte[fileLength];
            inputStream.Read(readBytes, 0, (int)fileLength);
            string readString = Encoding.UTF8.GetString(readBytes);
            inputStream.Close();
            Console.WriteLine("Text: {0}", readString);

            // FileMode: Append, Create, CreateNew(exception thrown if already exists), Open, OpenOrCreate, Truncate(open for writing and remove any existibng content)
            // FileAccess: Read, ReadWrite, Write
        }

        // The Stream class implements the IDisposable interface This means that any objects derived from the Stream type must also implement
        // the interface. This means that we can use the C# using construction to ensure that files are closed when they are no longer required.
        public void FileStremAndIDisposable()
        {
            using (FileStream outputStream = new FileStream("OutputText.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                string outputMessageString = "Hello world";
                byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
                outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
            }
        }

        // The filesystem makes no particular distinction between text files and binary files.We have already seen how we can use the Encoding class to convert
        // Unicode text into an array of bytes that can be written into a binary file. However, the C# language provides stream classes that make it much easier to
        // work with text.The TextWriter and TextReader classes are abstractclasses that define a set of methods that can be used with text.
        // The StreamWriter class extends the TextWriter class to provide a class that we can us to write text into streams.
        public void StreamWriterAndReader()
        {
            using (StreamWriter writeStream = new StreamWriter("OutputText.txt"))
            {
                writeStream.Write("Hello there!");
            }
            using (StreamReader readStream = new StreamReader("OutputText.txt"))
            {
                string readString = readStream.ReadToEnd();
                Console.WriteLine("Text read: {0}", readString);
            }
        }

        // The Stream class has a constructor that will accept another stream as a parameter, allowing the creation of chains of streams.	
        public void StoringCompressedFiles()
        {
            using (FileStream writeFile = new FileStream("CompText.zip", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (GZipStream writeFileZip = new GZipStream(writeFile, CompressionMode.Compress))
                {
                    using (StreamWriter writeFileText = new StreamWriter(writeFileZip))
                    {
                        writeFileText.Write("Hello world");
                    }
                }
            }

            using (FileStream readFile = new FileStream("CompText.zip", FileMode.Open, FileAccess.Read))
            {
                using (GZipStream readFileZip = new GZipStream(readFile, CompressionMode.Decompress))
                {
                    using (StreamReader readFileText = new StreamReader(readFileZip))
                    {
                        string message = readFileText.ReadToEnd();
                        Console.WriteLine("Read	text: {0}", message);
                    }
                }
            }
        }

        // 
        public void UseFileClass()
        {

        }

        // 
        public void StreamExceptions()
        {

        }

        // 
        public void DriveInformation()
        {

        }

        // 
        public void UsingFileInfo()
        {

        }

        // 
        public void TheDirectoryClass()
        {

        }

        // 
        public void TheDirectoryClassInfo()
        {

        }

        // 
        public void UsingPath()
        {

        }

        // 
        public void CSharpPorgrams()
        {

        }

        // 
        public void HttpWebRequest()
        {

        }

        //
        public void WebClient()
        {

        }

        // 
        public void WebClientAsync()
        {

        }

        // 
        public void HttpClient()
        {

        }

        // 
        public void AsynchronousFileWriting()
        {

        }

        // 
        public void FileExceptions()
        {

        }
    }

    // Ich gebe mein Buch bekannt.
}
