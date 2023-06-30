using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_name = Console.ReadLine();
            Console.WriteLine(DesEcb(file_name));
            Console.WriteLine(DesCbc(file_name));
            Console.WriteLine(DesCfb(file_name));
            Console.WriteLine(TripleDesEcb(file_name));
            Console.WriteLine(TripleDesCbc(file_name));
            Console.WriteLine(TripleDesCfb(file_name));
            Console.WriteLine(Rc2Ecb(file_name));
            Console.WriteLine(Rc2Cbc(file_name));
            //Console.WriteLine(Rc2Cfb(file_name));
            Console.WriteLine(RijndaelEcb(file_name));
            Console.WriteLine(RijndaelCbc(file_name));
        }

        public static String DesEcb(string file_name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = DES.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();

            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch.Stop();
            return "DES, " + sa.Mode + " " + stopwatch.ElapsedMilliseconds + "мс";
        }

        public static String DesCbc(string file_name)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = DES.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.CBC;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();

            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();
            stopwatch1.Stop();
            return "DES, " + sa.Mode + " " + stopwatch1.ElapsedMilliseconds + " мс";
        }

        public static String DesCfb(string file_name)
         {
             Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();
             byte[] cipherbytes;
             byte[] Key;
             byte[] IV;


             SymmetricAlgorithm sa = DES.Create();

             sa.GenerateKey();
             sa.GenerateIV();

             Key = sa.Key;
             IV = sa.IV;

             sa.Mode = CipherMode.CFB;
             sa.FeedbackSize = 8;
             sa.Padding = PaddingMode.PKCS7;

             MemoryStream ms = new MemoryStream();
             CryptoStream cs = new CryptoStream(
                             ms,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Write);

             byte[] plainbytes =
             Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
             cs.Write(plainbytes, 0, plainbytes.Length);

             cs.Close();

             cipherbytes = ms.ToArray();

             ms.Close();


             MemoryStream ms2 = new MemoryStream(cipherbytes);
             CryptoStream cs2 = new CryptoStream(
                             ms2,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Read);

             byte[] plainbytes2 = new Byte[cipherbytes.Length];
             cs2.Read(plainbytes2, 0, cipherbytes.Length);
             cs2.Close();
             ms2.Close();

             stopwatch.Stop();
             return "DES, " + sa.Mode + " " + stopwatch.ElapsedMilliseconds + " мс";
         }

        public static String TripleDesEcb(string file_name)
        {
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = TripleDES.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();


            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch2.Stop();
            return "3DES, " + sa.Mode + " " + stopwatch2.ElapsedMilliseconds + " мс";
        }

        public static String TripleDesCbc(string file_name)
        {
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = TripleDES.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.CBC;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();


            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch3.Stop();
            return "3DES, " + sa.Mode + " " + stopwatch3.ElapsedMilliseconds + " мс";
        }

         public static String TripleDesCfb(string file_name)
         {
             Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();
             byte[] cipherbytes;
             byte[] Key;
             byte[] IV;


             SymmetricAlgorithm sa = TripleDES.Create();

             sa.GenerateKey();
             sa.GenerateIV();

             Key = sa.Key;
             IV = sa.IV;

             sa.Mode = CipherMode.CFB;
             sa.FeedbackSize = 8;
             sa.Padding = PaddingMode.PKCS7;

             MemoryStream ms = new MemoryStream();
             CryptoStream cs = new CryptoStream(
                             ms,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Write);

             byte[] plainbytes =
             Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
             cs.Write(plainbytes, 0, plainbytes.Length);

             cs.Close();

             cipherbytes = ms.ToArray();

             ms.Close();


             MemoryStream ms2 = new MemoryStream(cipherbytes);
             CryptoStream cs2 = new CryptoStream(
                             ms2,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Read);

             byte[] plainbytes2 = new Byte[cipherbytes.Length];
             cs2.Read(plainbytes2, 0, cipherbytes.Length);
             cs2.Close();
             ms2.Close();

             stopwatch.Stop();
             return "3DES, " + sa.Mode + " " + stopwatch.ElapsedMilliseconds + " мс";
         }

        public static String Rc2Ecb(string file_name)
        {
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = RC2.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();


            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch4.Stop();
            return "RC2, " + sa.Mode + " " + stopwatch4.ElapsedMilliseconds + " мс";
        }

        public static String Rc2Cbc(string file_name)
        {
            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = RC2.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.CBC;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();


            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch5.Stop();
            return "RC2, " + sa.Mode + " " + stopwatch5.ElapsedMilliseconds + " мс";
        }

         /*public static String Rc2Cfb(string file_name)
         {
             Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();
             byte[] cipherbytes;
             byte[] Key;
             byte[] IV;


             SymmetricAlgorithm sa = RC2.Create();

             sa.GenerateKey();
             sa.GenerateIV();

             Key = sa.Key;
             IV = sa.IV;

             sa.Mode = CipherMode.CFB;
            sa.FeedbackSize = 8;
            sa.Padding = PaddingMode.PKCS7;

             MemoryStream ms = new MemoryStream();
             CryptoStream cs = new CryptoStream(
                             ms,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Write);

             byte[] plainbytes =
             Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
             cs.Write(plainbytes, 0, plainbytes.Length);

             cs.Close();

             cipherbytes = ms.ToArray();

             ms.Close();


             MemoryStream ms2 = new MemoryStream(cipherbytes);
             CryptoStream cs2 = new CryptoStream(
                             ms2,
                             sa.CreateEncryptor(),
                             CryptoStreamMode.Read);

             byte[] plainbytes2 = new Byte[cipherbytes.Length];
             cs2.Read(plainbytes2, 0, cipherbytes.Length);
             cs2.Close();
             ms2.Close();

             stopwatch.Stop();
             return "RC2, " + sa.Mode + " " + stopwatch.ElapsedMilliseconds + " мс";
         }*/

        public static String RijndaelEcb(string file_name)
        {
            Stopwatch stopwatch6 = new Stopwatch();
            stopwatch6.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = Rijndael.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();


            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch6.Stop();
            return "Rijndael, " + sa.Mode + " " + stopwatch6.ElapsedMilliseconds + " мс";
        }

        public static String RijndaelCbc(string file_name)
        {
            Stopwatch stopwatch7 = new Stopwatch();
            stopwatch7.Start();
            byte[] cipherbytes;
            byte[] Key;
            byte[] IV;


            SymmetricAlgorithm sa = Rijndael.Create();

            sa.GenerateKey();
            sa.GenerateIV();

            Key = sa.Key;
            IV = sa.IV;

            sa.Mode = CipherMode.CBC;
            sa.Padding = PaddingMode.PKCS7;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
                            ms,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Write);

            byte[] plainbytes =
            Encoding.UTF8.GetBytes(File.ReadAllText(file_name));
            cs.Write(plainbytes, 0, plainbytes.Length);

            cs.Close();

            cipherbytes = ms.ToArray();

            ms.Close();

            MemoryStream ms2 = new MemoryStream(cipherbytes);
            CryptoStream cs2 = new CryptoStream(
                            ms2,
                            sa.CreateEncryptor(),
                            CryptoStreamMode.Read);

            byte[] plainbytes2 = new Byte[cipherbytes.Length];
            cs2.Read(plainbytes2, 0, cipherbytes.Length);
            cs2.Close();
            ms2.Close();

            stopwatch7.Stop();

            return "Rijndael, " + sa.Mode + " " + stopwatch7.ElapsedMilliseconds + " мс";
        }
    }
}
