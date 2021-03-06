﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleAppTest.DebugAndSecurity
{
    // Cryptography involves taking the original message and encrypting it to generate a version that can be safely transferred over an open network.The
    // recipient will perform decryption of the message to recover the original contents.
    public class PerformEncryption
    {
        private void DumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);
            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }
            Console.WriteLine();
        }

        // Computers can also use symmetric keys to encrypt and decrypt data. The sender uses a key(which in this case is a package of numbers) to encrypt the
        // data, and the recipient uses the same key to decrypt it.However, the computer has the same problem with its digital key that we have with a book key.Before
        // you can send any messages, you need to make sure that both ends of the conversation have the same key.

        // It turns out that by the use of clever mathematics you can perform encryption and decryption using two different keys.Messages encrypted by one key can be
        // decrypted using the other one.They are called asymmetric keys because the keys at each end of the conversation are different.

        // The Advanced Encryption Standard (AES) is used worldwide to encrypt data. It supersedes the Data Encryption Standard(DES). It is a symmetric encryption
        // system.You use the same key to encrypt and decrypt the data. using the Aes class in the
        // System.Security.Cryptography namespace.The encryption process is implemented as a stream
        public void AesEncryption()
        {
            string text = "Some very secret data";

            // byte array to hold the encrypted message
            byte[] cipherText;

            // byte array to hold the key that was used for encryption
            byte[] key;

            // byte array to hold the initialization vector that was used for encry
            byte[] initializationVector;

            // Create an Aes instance. This creates a random key and initialization vector
            using (Aes aes = Aes.Create())
            {
                // copy the key and the initialization vector
                key = aes.Key;
                initializationVector = aes.IV;

                // create an encryptor to encrypt some data should be wrapped in using for production code
                ICryptoTransform encryptor = aes.CreateEncryptor();

                // Create a new memory stream to receive the encrypted data.
                using (MemoryStream encryptMemoryStream = new MemoryStream())
                {
                    // create a CryptoStream, tell it the stream to write to and the encryptor to use. Also set the mode
                    using (CryptoStream encryptCryptoStream =
                        new CryptoStream(encryptMemoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        // make a stream writer from the cryptostream
                        using (StreamWriter swEncrypt =
                            new StreamWriter(encryptCryptoStream))
                        {
                            //Write the secret message to the stream.
                            swEncrypt.Write(text);
                        }

                        // get the encrypted message from the stream
                        cipherText = encryptMemoryStream.ToArray();
                    }
                }

            }

            // Dump out our data
            Console.WriteLine("String to encrypt: {0}", text);
            DumpBytes("Key: ", key);
            DumpBytes("Initialization Vector: ", initializationVector);
            DumpBytes("Encrypted: ", cipherText);

            // The initialization vector adds security to a particular key value by specifying a random start point in the stream of encryption values that will be produced to
            // encrypt the input.If every encryption stars at the beginning of the encryption stream, there is a chance that the repeated use of a particular encryption key
            // provides a large enough set of encrypted messages for an eavesdropper to break the code. By using a different initialization vector for each message, you can
            // remove this possibility.The receiver of the message will need both the key and the initialization vector value to decrypt the code.

            _key = key;
            _initializationVector = initializationVector;
            _cipherText = cipherText;
        }

        private byte[] _key;
        private byte[] _initializationVector;
        private byte[] _cipherText;


        // how to use an Aes instance to decrypt an array of bytes. It is the reverse of the process
        public void AesDecryption()
        {
            AesEncryption();

            string decryptedText;

            using (Aes aes = Aes.Create())
            {
                // Configure the aes instances with the key and initialization vector to use for the decryption
                aes.Key = _key;
                aes.IV = _initializationVector;

                // Create a decryptor from aes. Should be wrapped in using for production code
                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (MemoryStream decryptStream = new MemoryStream(_cipherText))
                {
                    using (CryptoStream decryptCryptoStream = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(decryptCryptoStream))
                        {
                            // Read the decrypted bytes from the decrypting stream and place them in a string.
                            decryptedText = srDecrypt.ReadToEnd();
                        }                    }
                }
            }

            Console.WriteLine("Decrypted text: ", decryptedText);
        }

        // The encryption process in .NET is an example of good class design. All of the encryption classes, including Aes, are extensions of the base class
        // SymmetricAlgorithm, which is in the  System.Security.Cryptography namespace.

        // RSA (Rivest–Shamir–Adleman) is a very popular asymmetric encryption standard.The RSACryptoServiceProvider class in the
        // System.Security.Cryptography namespace will perform encryption and decryption of data using this standard.
        public void RsaEncryption()
        {
            string plainText = "This is my super secret data";
            Console.WriteLine("Plain text: {0}", plainText);
            // RSA works on byte arrays, not strings of text
            // This will convert our input string into bytes and back
            ASCIIEncoding converter = new ASCIIEncoding();
            // Convert the plain text into a byte array
            byte[] plainBytes = converter.GetBytes(plainText);
            DumpBytes("Plain bytes: ", plainBytes);
            byte[] encryptedBytes;
            byte[] decryptedBytes;
            // Create a new RSA to encrypt the data
            // should be wrapped in using for production code
            RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider();
            // get the keys out of the encryptor
            string publicKey = rsaEncrypt.ToXmlString(includePrivateParameters: false);
            Console.WriteLine("Public key: {0}", publicKey);
            string privateKey = rsaEncrypt.ToXmlString(includePrivateParameters: true);
            Console.WriteLine("Private key: {0}", privateKey);
            // Now tell the encyryptor to use the public key to encrypt the data
            rsaEncrypt.FromXmlString(privateKey);
            // Use the encryptor to encrypt the data. The fOAEP parameter
            // specifies how the output is "padded" with extra bytes
            // For maximum compatibility with receiving systems, set this as
            // false
            encryptedBytes = rsaEncrypt.Encrypt(plainBytes, fOAEP: false);
            DumpBytes("Encrypted bytes: ", encryptedBytes);
            // Now do the decode - use the private key for this
            // We have sent someone our public key and they
            // have used this to encrypt data that they are sending to us
            // Create a new RSA to decrypt the data
            // should be wrapped in using for production code
            RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider();
            // Configure the decryptor from the XML in the private key
            rsaDecrypt.FromXmlString(privateKey);
            decryptedBytes = rsaDecrypt.Decrypt(encryptedBytes, fOAEP: false);
            DumpBytes("Decrypted bytes: ", decryptedBytes);
            Console.WriteLine("Decrypted string: {0}",
            converter.GetString(decryptedBytes));
        }

        // 
        public void RsaKeyManagement()
        {

        }

        // 
        public void RsaStoredKeyClear()
        {

        }

        // 
        public void MachineLevelKeys()
        {

        }

        // 
        public void SigningData()
        {

        }

        // 
        public void Checksums()
        {

        }

        // 
        public void Hashing()
        {

        }

        // 
        public void Sha2()
        {

        }

        // 
        public void EncryptStream()
        {

        }
    }
}
