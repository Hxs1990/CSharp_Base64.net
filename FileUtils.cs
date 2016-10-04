using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    class FileUtils
    {
        private const string encryptExtension = ".b64";
        private const string decryptExtension = "_b64.dec";
        private const int cols = 76;
        
        // this method reads text file and returns in as a array of bytes
        public static byte[] readFile(string fileName) {

            // an array of bytes to be returned from the method
            byte[] fileData = null; 
            // a temporary string for reading textfile
            string inputString = string.Empty; 

            // make shure that the file we are going to read does exist
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            else
            {
                using (StreamReader sReader = File.OpenText(fileName))
                {
                    // Reading the file line by line
                    string input = null;
                    while((input = sReader.ReadLine()) != null)
                    { inputString += input; }
                }
                // Tnasform the file text contents in string to byte array (ASCII encoding)
                fileData = Encoding.ASCII.GetBytes(inputString);
                
                //fileData = File.ReadAllBytes(fileName);
            }

            return fileData; 
        }

        // This method writes Base64 encrypted file
        public static void writeEncoded(string fileName, string strOut)
        {
            fileName = getNewFilenameEncrypted(fileName);

            using (StreamWriter sWriter = File.CreateText(fileName)) 
            {   int i = 0;
                foreach (char c in strOut.ToCharArray())
                {
                    i++;
                    sWriter.Write(c);
                    if (i % cols == 0) sWriter.WriteLine();
                }
            }            
        }


        //======================
        // This method writes decrypted file from Base64 encoding 
        public static void writeDecoded(string fileName, byte[] outputData)
        {
            fileName = getNewFilenameDecrypted(fileName);

            using (FileStream fs = File.Open(fileName, FileMode.Create))
            {
                fs.Write(outputData, 0, outputData.Length);
            }
        }

        /* This method returns new name for Base64 encrypted file. For encrypted file we change extension of 
         * the file to what is saved in encryptExtension constant variable
         */
        private static string getNewFilenameEncrypted(string fileName) { 

            string newPath = Path.Combine(
                new FileInfo(fileName).Directory.ToString(),
                fileName.Substring(0, fileName.IndexOf('.'))
                ) + encryptExtension;

            return newPath;
        }

        /* This method returns new name for decrypted file from Base64 encryption. For decrypted file we change extension 
         * of the file to what is saved in decryptExtension constant variable
         */
        private static string getNewFilenameDecrypted(string fileName)
        {

            string newPath = Path.Combine(
                new FileInfo(fileName).Directory.ToString(),
                fileName.Substring(0, fileName.IndexOf('.'))
                ) + decryptExtension;

            return newPath;
        }

    }
}
