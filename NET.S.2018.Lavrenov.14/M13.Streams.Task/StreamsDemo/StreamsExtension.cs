using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream fsReader = File.OpenRead(sourcePath))
            {
                using (FileStream fsWriter = File.OpenWrite(destinationPath))
                {
                    int byteCounter = 0;

                    while (byteCounter != -1)
                    {
                        byteCounter = fsReader.ReadByte();
                        fsWriter.WriteByte((byte)byteCounter);
                    }

                    return (int)fsWriter.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file


            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            using (FileStream fsReader = File.OpenRead(sourcePath))
            {
                using (FileStream fsWriter = File.OpenWrite(destinationPath))
                {
                    fsReader.CopyTo(fsWriter);
                    return (int)fsWriter.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath == destinationPath)
            {
                return true;
            }

            using (FileStream fsReaderSourse = File.OpenRead(sourcePath))
            {
                using (FileStream fsReaderDestination = File.OpenRead(destinationPath))
                {
                    for (int i = 0; i < fsReaderSourse.Length; i++)
                    {
                        if (fsReaderSourse.ReadByte() != fsReaderDestination.ReadByte())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null)
            {
                throw new ArgumentNullException($"{nameof(sourcePath)} can't be null");
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException($"{nameof(destinationPath)} can't be null");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"{nameof(sourcePath)} file is not exist");
            }

            if (!File.Exists(destinationPath))
            {
                throw new FileNotFoundException($"{nameof(destinationPath)} file is not exist");
            }
        }

        #endregion

        #endregion

    }
}
