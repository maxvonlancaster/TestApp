using System;
using System.Collections.Generic;
using System.IO;
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

        // 
        public void FileStremAndIDisposable()
        {

        }

        // 
        public void StreamWriterAndReader()
        {

        }

        // 
        public void StoringCompressedFiles()
        {

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
}
