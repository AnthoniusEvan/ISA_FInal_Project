    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
using System.Windows.Forms;

namespace FlightReservationProject
{
    [XmlRoot("AES")]
    public class AES
    {
        [XmlElement]
        public string id;
        [XmlElement]
        public string key;
        [XmlElement]
        public string iv;
        public AES()
        {
        }
        public AES(string id, string key, string iv)
        {
            this.id = id;
            this.key = key;
            this.iv = iv;
        }
        public static byte[] GenerateKey(out byte[] iv)
        {
            byte[] key = GenerateRandomBytes(32); // 256-bit key
            iv = GenerateRandomBytes(16); // 128-bit IV
            return key;
        }
        public string Encrypt(string text)
        {
            try
            {
                byte[] encrypted = EncryptStringToBytes(text, Convert.FromBase64String(key), Convert.FromBase64String(iv));
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
        public string Decrypt(string encrypted)
        {
            try
            {
                string decrypted = DecryptStringFromBytes(Convert.FromBase64String(encrypted), Convert.FromBase64String(key), Convert.FromBase64String(iv));
                return decrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return null;
            }
        }
        static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }


        static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        static byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        public static void Save(AES aes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AES));
            using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\keys\" + aes.id + ".xml"))
            {
                serializer.Serialize(writer, aes);
            }
        }

        public static AES Retrieve(string id)
        {
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(AES));

                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\keys\" + id + ".xml", FileMode.Open))
                {
                    return (AES)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your encryption key is missing!");
                return null;
            }
        }
    }
}
