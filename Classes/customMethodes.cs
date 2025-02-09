﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace greenEnergy.Classes
{
    public class customMethodes
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        private static Random random = new Random();
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static string RandomString(int length)
        {
              
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public  string setPriceRight (string srt)
        {
            srt = srt == null ? "0" : srt;
            string price = (Double.Parse(srt) / 1000000).ToString() + " میلیون تومان ";

            Double db = Double.Parse(srt) / 1000000000;
            if (db >= 1)
            {
                srt = db + " میلیارد تومان";
            }
            else
            {
                srt = price;
            }
            return srt;
        }

        public static string PersianToEnglish( string persianStr)
        {
            var inputstring = persianStr;
            string[] persian = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            string[] english = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (var i = 0; i < 10; i++)
            {
                inputstring = inputstring.ToString().Replace(persian[i], english[i]);
            }

            return inputstring;
        }

        public static DateTime returnFirstDayWeekTime()
        {
            DateTime nowDate = DateTime.Now;
            DateTime startDate = new DateTime();
            string dayname = nowDate.DayOfWeek.ToString();
            string persianName = "";
            switch (dayname.ToLower())
            {
                case "saturday":
                    persianName = "شنبه";
                    startDate = nowDate;
                    break;
                case "sunday":
                    persianName = "یک شنبه";
                    startDate = nowDate.AddDays(-1);
                    break;
                case "monday":
                    persianName = "دو شنبه";
                    startDate = nowDate.AddDays(-2);
                    break;
                case "tuesday":
                    persianName = "سه شنبه";
                    startDate = nowDate.AddDays(-3);
                    break;
                case "wednesday":
                    persianName = "چهار شنبه";
                    startDate = nowDate.AddDays(-4);
                    break;
                case "thursday":
                    persianName = "پنج شنبه";
                    startDate = nowDate.AddDays(-5);
                    break;
                case "friday":
                    persianName = "جمعه ";
                    startDate = nowDate.AddDays(-6);
                    break;
            }
            return startDate;
        }

        public static string returnDayName(DateTime startDate)
        {
            string dayname = startDate.DayOfWeek.ToString();
            string persianName = "";
            switch (dayname.ToLower())
            {
                case "saturday":
                    persianName = "شنبه";
                    break;
                case "sunday":
                    persianName = "یک شنبه";
                    startDate = startDate.AddDays(-1);
                    break;
                case "monday":
                    persianName = "دو شنبه";
                    startDate = startDate.AddDays(-2);
                    break;
                case "tuesday":
                    persianName = "سه شنبه";
                    startDate = startDate.AddDays(-3);
                    break;
                case "wednesday":
                    persianName = "چهار شنبه";
                    startDate = startDate.AddDays(-4);
                    break;
                case "thursday":
                    persianName = "پنج شنبه";
                    startDate = startDate.AddDays(-5);
                    break;
                case "friday":
                    persianName = "جمعه ";
                    startDate = startDate.AddDays(-6);
                    break;
            }
            return persianName;
        }


        public static DateTime returnFirstDayWeekTimeGorgian()
        {
            DateTime nowDate = DateTime.Now;
            DateTime startDate = new DateTime();
            string dayname = nowDate.DayOfWeek.ToString();
            string persianName = "";
            switch (dayname.ToLower())
            {
                case "saturday":
                    
                    startDate = nowDate.AddDays(-5);
                    break;
                case "sunday":
                    
                    startDate = nowDate.AddDays(-6);
                    break;
                case "monday":

                    startDate = nowDate;
                    break;
                case "tuesday":
                   
                    startDate = nowDate.AddDays(-1);
                    break;
                case "wednesday":
                    
                    startDate = nowDate.AddDays(-2);
                    break;
                case "thursday":
                   
                    startDate = nowDate.AddDays(-3);
                    break;
                case "friday":
                  
                    startDate = nowDate.AddDays(-4);
                    break;
            }
            return startDate;
        }
    }
}