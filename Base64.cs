using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{   
    class Base64
    {
        private static string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="; // This is MIME64 ABC

        private static ushort buffer; // While encryption/decryption is processing i hold here symbols and split blocks by 6 bits
        private static int BufferBitCounter = 0; // a buffer bit counter
        private static int numOfBits = 0; // a number of bits in a string that is passed in for encryption

        /* This list is nesessary in MIME (Base64) text decryption method into the natural and comprehensible text. 
         * I add bytes (a small parts by 8 bits) one by one into this list inside of Mime64Decode method */ 
        private static List<byte> bytesList = new List<byte>();

        // Here we start to endode to Base64 inside this method
        public static string startEncode(byte[] inputByteArray)
        {
            // this string is used for resulting string with encoded text
            string strOutputData = string.Empty;

            // Checking for input array is not null
            if (inputByteArray != null) 
            {
                // Calculating length in bits of the input array by multiplying number 
                // of bytes (length of array) by 8 (since one byte is 8 bit)
                numOfBits = inputByteArray.Length * 8;

                // The length in bits of every text message to be encoded must be devidable by 6 
                if (numOfBits % 6 == 0) // length is devidable with no remaider
                {
                    //calling out the method to encode our bytes
                    strOutputData = Mime64Encode(inputByteArray);
                }
                else if (numOfBits % 6 == 2) { // the length is devides with remider 2
                    // then calling out the method to encode our bytes and add '==' to the end of our message
                    strOutputData = Mime64Encode(inputByteArray) + "=="; 
                }
                else if (numOfBits % 6 == 4) // the length is devides with remider 4
                {
                    // then calling out the method to encode our bytes and add '=' to the end of our message
                    strOutputData = Mime64Encode(inputByteArray) + "="; 
                }                
            }
            return strOutputData;
        }

        // Here we start to decode the Base64 text into a ordynary bytes of text(data)        
        public static byte[] startDecode(byte[] inputByteArray)
        {
            // At the begining we inicialize all variables by zeros
            buffer = 0; // here i hold symbols (bytes) and split blocks by 6 bits
            BufferBitCounter = 0; // a bit counter in the buffer

            bytesList.Clear();
            byte mimeAbcPosition; // We should define the position of the symbol in the Base64 (MIME) ABC
            char mimeLetter; // a letter in the Base64 (MIME) ABC
                       

            // enumerating byte array in a cycle byte by byte
            for (int i = 0; i < inputByteArray.Length; i++) 
            {
                // Here we need to transform (cast) a byte into a symbol (char) 
                mimeLetter = Convert.ToChar(inputByteArray[i]);
                if (mimeLetter == '=') break; //the "=" sign means finish here
                // and define the position in the BASE64 ABC
                mimeAbcPosition = (byte)abc.IndexOf(mimeLetter);

                /* and now we call out the method for decrypting Base64 sending a position 
                of a letter in Base64 ABC into it */                                
                Mime64Decode(mimeAbcPosition);
            }

            return bytesList.ToArray();            
        }

             
        /* Here a byte array is passed into this method and the method does
         * Base64 encoding of all the bytes in the array that was passed in.
         */
        private static string Mime64Encode(byte[] InputByteArray)
        {
            // At the begining we inicialize all variables by zeros 
            buffer = 0; // here i hold symbols (bytes) and split blocks by 6 bits
            BufferBitCounter = 0; // a bit counter in the buffer
            

            int temp6Bit = 0; // Temporary varible - here we hold 6bit from the buffer, by right shifting
            string result = string.Empty; // the result of Base64 encoding 

            // Here we process all bytes in the array
            for (int i = 0; i < InputByteArray.Length; ++i)
            { 
                //foreach (byte symbol in InputByteArray)
                byte symbol = InputByteArray[i];

                buffer = (ushort)(buffer << 8); // Here we do left shifting 8 times in order to make space for adding a byte of the symbol
                buffer = (ushort)(buffer | symbol); // Adding a symbol (byte) into the buffer

                BufferBitCounter += 8; // Increase the buffer bit counter by 8 bit (since we just added a symbol - it takes 8 bit in memory)

                /* Если количество бит в передаваеваемом сообщнии не кратно 6-ти (мы кодируем сообщение по 6 бит) тогда 
                    * нам нужно добавить в самый конец цепочки байтов поэтому мы здесь проверяем что i == byteArr.length -1)
                    * необходимые пустые биты, чтобы длина была кратной 6-ти */
                if (i == InputByteArray.Length - 1 && numOfBits % 6 == 2)
                {
                    buffer = (ushort)(buffer << 4);
                    BufferBitCounter += 4;
                }
                else if (i == InputByteArray.Length - 1 && numOfBits % 6 == 4)
                {
                    buffer = (ushort)(buffer << 2);
                    BufferBitCounter += 2;
                }

                // Now we check if our buffer bit counter is more or equal 6 - if so split the buffer by blocks of 6 bits
                // We do this in a cycle untile the condition is true
                while (BufferBitCounter >= 6)
                {
                    /* In a cycle we recieve a 6 bits block by shifting right (How far do we need to shift? 
                        * We define it with help of buffer bit counter. We shift to a value that equals BufferBitCounter minus 6, 
                        * since we should keep 6 bit and code them into the MIME64 ABC*/
                    temp6Bit = buffer >> (BufferBitCounter - 6);
                    BufferBitCounter -= 6; // After we got a 6 bit block - we decrease buffer bit counter by 6

                    // Here we have to clear buffer if buffer bit counter is zero
                    if (BufferBitCounter == 0)
                    {
                        buffer = 0;
                    }
                    else
                    {
                        // Here we clear the buffer form the bits that were just taken - the ushort takes 16 bit in memory
                        buffer = (ushort)(buffer << (16 - BufferBitCounter));
                        buffer = (ushort)(buffer >> (16 - BufferBitCounter));
                    }

                    /* Afrer we got a 6 bit block here we define a symbol (a letter) in MIME64 ABC by putting the number 
                        * that makes 6 bit that we got, into the array of BASE64 ABC as an index */
                    result += abc[temp6Bit]; // Adding a letter into result string
                }
            }
        return result;
        }
        
        /* 
        * Метод принимает параметр - byte Symbol, который определяет положение символа в массиве-алфавите MIME64
        * В процессе работы метода - в буфере накапливаются биты
        */
        public static void Mime64Decode(byte Symbol)
        {
            byte temp8bit = 0; // a temporary varible, for taking out a block of 8 bit from the buffer

            /* Shifting the buffer to the left 6 times. Doing so we create space for adding bits of new symbol 
             * (which we get as a method argument) Each symbol in method argument that is passed in takes 6 bit in memory */
            buffer = (ushort)(buffer << 6);
            buffer = (ushort)(buffer | Symbol); // adding new bits (6 bits from method argument) into the buffer
            BufferBitCounter += 6; // And now increase the buffer bit counter by 6

            /* If our buffer bit counter is more then 8 or equal - then split the buffer by 
             * 8 bits blocks in a cycle while condition is true */
            while (BufferBitCounter >= 8)
            {
                /* Here we are getting an 8 bit block by shifting buffer to the right
                 * (How far do we need to shift? We define that with help of buffer bit counter, -
                 * we shift to a number of times that BufferBitCounter viriable holds minus 8, 
                 * since we keep 8 bit, for decryption it into ordinary byte of (text or data) */
                temp8bit = (byte)(buffer >> (BufferBitCounter - 8));
                BufferBitCounter -= 8; // And now decrease the buffer bit counter by 8

                /* Here we are cleaning the buffer from bits that were just taken out 
                 * -- the buffer is ushort - that takes 16 in memory */
                buffer = (ushort)(buffer << (16 - BufferBitCounter)); 
                buffer = (ushort)(buffer >> (16 - BufferBitCounter));

                // here we add decrypted 8 bit block into a list of bytes
                bytesList.Add(temp8bit);
            }
        } 
    }
}
