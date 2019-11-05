using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            // chain streams!
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

        // The File class is a helper class that makes it easier to work with files. Contains set of static methods that can be used to append text to a file, copy, create,
        // delete, move, open, read a file, manage its security.
        public void UseFileClass()
        {
            File.WriteAllText(path: "TextFile.txt", contents: "Hello there!");
            File.AppendAllText(path: "TextFile.txt", contents: "Hello there again!");
            if (File.Exists("TextFile.txt"))
            {
                Console.WriteLine("File exists");
            }

            string contents = File.ReadAllText(path: "TextFile.txt");
            Console.WriteLine("File contents: {0}", contents);
            File.Copy(sourceFileName: "TextFile.txt", destFileName: "CopyTextFile.txt");
            using (TextReader reader = File.OpenText(path: "CopyTextFile.txt"))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine("Copied contents: {0}", text);
            }
        }

        // When creating applications that use streams you need to ensure that your code can deal with any exceptions that might be thrown by the stream
        // Our application may try to open a file that does not exist, or a given storage device may become full during writing.
        //  It is also possible that threads in a multi-threaded application can “fight” over files.
        // With this in mind you should ensure that production code that opens and interacts with streams is protected by try–catch constructions.
        public void StreamExceptions()
        {
            try
            {
                string contents = File.ReadAllText(path: "FileThatDoesNotExist.txt");
            }
            catch (FileNotFoundException notFoundEx)
            {
                // File not found
                Console.WriteLine(notFoundEx.Message);
            }
            catch (Exception ex)
            {
                // Any other exception
                Console.WriteLine(ex.Message);
            }
        }

        // A given storage device, perhaps a disk drive or USB portable disk, can be divided into partitions.Each partition represents an area on the storage device
        // that can be used to store data.A partition on a storage device is exposed as a drive which, on the Windows operating system, is represented by a drive letter.
        // The drive letter is assigned by the operating system and is used as the root of an absolute path to a file on the computer.
        // The Disk Management application allows administrators to re-assign drive letters, combine multiple physical drives into a single logical drive, and attach
        // virtual hard drives(VHD) created from drive images.
        // Each of the partitions on a physical storage device is formatted using a particular filing system that manages the storage of file.
        public void DriveInformation()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Name: {0}", drive.Name);
                if (drive.IsReady)
                {
                    Console.WriteLine("Type: {0}", drive.DriveType);
                    Console.WriteLine("Format: {0}", drive.DriveFormat);
                    Console.WriteLine("Free space: {0}", drive.TotalFreeSpace);
                }
                else
                {
                    Console.WriteLine("Drive not ready");
                }
            }
            // Note that some of the drive letters have been allocated to removable devices.
        }

        // A file system maintains information about each file it stores. This includes the name of the file, permissions associated with the file, 
        // dates associated with the creation, modification of the file, and the physical location of the file on the storage device.
        public void UsingFileInfo()
        {
            string filePath = "TextFile.txt";
            File.WriteAllText(path: filePath, contents: "This text goes in the file");
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine("Name: {0}", info.Name);
            Console.WriteLine("Full	Path: {0}", info.FullName);
            Console.WriteLine("Last	Access: {0}", info.LastAccessTime);
            Console.WriteLine("Length: {0}", info.Length);
            Console.WriteLine("Attributes: {0}", info.Attributes);
            Console.WriteLine("Make the file read only");
            info.Attributes |= FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);
            Console.WriteLine("Remove the read only attribute");
            info.Attributes &= ~FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);
        }

        // A file system can create files that contain collections of file information items. These are called directories or folders. Directories can	
        // contain directory information about directories, which allows a user to nest directories to create tree structures. As with files, there are two 
        // ways to work with directories: the Directory class and the DirectoryInfo class. The Directory class is like the File
        // class. It is a static class that provides methods that can enumerate the contents of directories and create and manipulate directories.
        public void TheDirectoryClass()
        {
            Directory.CreateDirectory("TestDirectory");

            if (Directory.Exists("TestDirectory"))
                Console.WriteLine("Directory created succesfully");

            Directory.Delete("TestDirectory");
            Console.WriteLine("Directory deleted succesfully");
        }

        // An instance of the DirectoryInfo class describes the contents of one directory. The class also provides methods that can be used to create and 
        // manipulate directories.
        public void TheDirectoryClassInfo()
        {
            DirectoryInfo directory = new DirectoryInfo("TestDirectory");
            directory.Create();
            if (directory.Exists)
                Console.WriteLine("Directory created");
            directory.Delete();
            Console.WriteLine("Directory deleted succesfully");
        }

        // Paths can be relative or absolute. A relative path specifies the location of a file relative to the folder in which the program is presently running.	
        // The Path class is very useful and should always be used in preference to manually working with the path strings.
        public void UsingPath()
        {
            string fullName = @"C:\Users\Василь.000\Documents\text.txt";

            string dirName = Path.GetDirectoryName(fullName);
            string fileName = Path.GetFileName(fullName);
            string fileExtension = Path.GetExtension(fullName);
            string lisName = Path.ChangeExtension(fullName, ".lis"); 
            string newText = Path.Combine(dirName, "newText.txt");

            Console.WriteLine("Full name: {0}", fullName);
            Console.WriteLine("File directory: {0}", dirName);
            Console.WriteLine("File name: {0}", fileName);
            Console.WriteLine("File extension: {0}", fileExtension);
            Console.WriteLine("File with lis extension: {0}", lisName);
            Console.WriteLine("New path: {0}", newText);
        }

        private void FindFiles(DirectoryInfo dir, string searchPattern)
        {
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                FindFiles(directory, searchPattern);
            }
            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in matchingFiles)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }

        // The DirectoryInfo class provides a method called GetFiles that can be used to get a collection of FileInfo items that describe the files in 
        // a directory. One overload of GetFiles can accept a search string. Within the search string
        // the character * can represent any number of characters and the character ? can represent a single character.
        public void CSharpPorgrams()
        {
            DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
            string searchString = "*.cs";
            FindFiles(startDir, searchString);
            // The Directory class provides a method called EnumerateFiles that can also be used to enumerate files in this way. 
        }

        // The .NET Framework provides a range of application programming interfaces that can interact with a TCP/IP (Transmission	
        // Control	Protocol/Internet Protocol)	network. C#	programs can	create	network	socket	objects	that	can communicate	over	the	network	by	
        // sending	unacknowledged	datagrams	using
        // UDP(User Datagram Protocol) or creating managed connections using	TCP (Transmission Control Protocol). In this section we  are going   
        // to focus   on the classes in the System.Net namespace that allow	a program to communicate with servers using	the	HTTP(HyperText Transport   
        // Protocol). This protocol operates on  top of  a TCP/IP connection.In  other words, TCP/IP provides the connection  between the server and  
        // client systems and HTTP defines the format of  the messages that are exchanged over that connection. An HTTP client, for	example a   
        // web browser, creates a TCP connection  to a server and makes a   request for	data by  sending the HTTP GET command.The server  will then    
        // respond with a page of information. After the response has been returned to the client the TCP connection	is	closed.The information 
        // returned by  the server	is	formatted using	HTML (HyperText Markup   Language)	and rendered    by the browser.In the case	of an  
        // ASP(Active Server  Pages)  application the HTML document may be 
        // produced dynamically by  software, rather than being loaded  from a file stored  on the server.HTTP was originally used for	the sharing 
        // of human-readable web pages.However,	now an  HTTP request may return	an XML or JSON formatted document  that describes data in	an application.
        // The REST (REpresentational State   Transfer) architecture uses the GET, PUT, POST and DELETE  operations of  HTTP to  allow a   client to  
        // request a   server to perform functions in	a client-server application.The fundamental operation   that is	used to  communicate with    these and 
        // other servers is	the sending of a “web request”	to a   server to  perform an  HTML command on the server, and now we are  going to  discover 
        // how to  do	this.	Let’s look    at three   different ways to interact with web servers and consider their   advantages and disadvantages.These 
        // are WebRequest, WebClient, and HttpClient. 



        // The	WebRequest	class	is	an	abstract	base	class	that	specifies	the	behaviors	of	a web	request.	It	exposes	a	static	
        // factory	method	called	Create,	which	is	given	a universal	resource	identifier	(URI)	string	that	specifies	the	resource	that	
        // is	to	be used.	The	Create	method	inspects	the	URI	it	is	given	and	returns	a	child	of	the WebRequest	class	that	matches	that
        // resource.	The	Create	method	can	create HttpWebRequest,	FtpWebRequest,	and	FileWebRequest	objects.	In	the	case	of	a web	site,
        // the	URI	string	will	start	with	“http”	or	“https”	and	the	Create	method
        // will	return	an HttpWebRequest  instance.The GetResponse method on  an HttpWebRequest  returns a   WebResponse instance    that describes  
        // the response    from the server.Note that	this	response	is not the web page    itself,	but an  object that    describes the response from   
        // the server.To  actually read    the text    from the webpage a   program must    use the GetResponseStream method  on the response to  get a   stream 
        // from    which the webpage text    can be  read.
        public void HttpWebRequest()
        {
            WebRequest webRequest = WebRequest.Create("https://www.microsoft.com");
            WebResponse webResponse = webRequest.GetResponse();

            using (StreamReader stream = new StreamReader(webResponse.GetResponseStream()))
            {
                string siteText = stream.ReadToEnd();
                Console.WriteLine(siteText);
            }
        }

        // The WebClient class provides a simpler and quicker way of reading the text from a web server. There is now no need to create a stream to read the page 
        // contents (although you can do this if you wish) and there is no need to deal with the response to the web request before you can obtain the reply from the server.
        public void WebClient()
        {
            WebClient client = new WebClient();
            string siteText = client.DownloadString("https://www.microsoft.com");
            Console.WriteLine(siteText);
        }

        // The WebClient class also provides methods that can be used to read from the server asynchronously.	
        public async Task WebClientAsync()
        {
            WebClient client = new WebClient();
            string siteText = await client.DownloadStringTaskAsync("https://www.microsoft.com");
            Console.WriteLine(siteText);
        }

        // The HTTPClient is important because it is the way in which a Windows Universal Application can download the contents of a website. Unlike the 
        // WebRequest and the WebClient classes, an HTTPClient only provides asynchronous methods.
        public async Task HttpClient()
        {
            HttpClient client = new HttpClient();
            string siteText = await client.GetStringAsync("https://www.microsoft.com");
            Console.WriteLine(siteText);

            // As with file handling, loading information from the Internet is prone to error. Network connections may be broken or servers may be 
            // unavailable. This means that web request code should be enclosed in appropriate exception handlers.	
        }

        // The file operations provided by the File class do not have any asynchronous versions, so the FileStream class should be used instead.
        public async Task AsynchronousFileWriting(string fileName, byte[] items)
        {
            using (FileStream outStream = 
                new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                await outStream.WriteAsync(buffer: items, offset: 0, count: items.Length);
            }
        }

        // If any exceptions are thrown by the asynchronous file write method they must be caught and a message displayed for the user. This will only happen if	
        // the WriteBytesAsync method returns a Task object that is awaited when the WriteBytesAsync method is called.	
        public async Task FileExceptions(object sender, EventArgs args)
        {
            byte[] data = new byte[100];
            try
            {
                // Filename is wrong
                await AsynchronousFileWriting("wrongcharacter:.dat", data);
            }
            catch (Exception writeException)
            {
                Console.WriteLine(writeException.Message);
            }
        }
    }

    // Ich gebe mein Buch bekannt.
}
