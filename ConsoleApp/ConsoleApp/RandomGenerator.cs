using System;
using System.Text;

namespace ConsoleApp
{
    public class RandomGenerator
    {
        private readonly Random _random = new(DateTime.Now.Second);
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly string[] _emailServices = { "@gmail.com", "@ukr.net", "@lnu.edu.ua", "@nyu.com", "yahoo.com"};

        public int RandomNumber(int max)
        {
            return _random.Next(max);
        }
        public string RandomString(int maxSize)
        {
            var size = _random.Next(4, maxSize);
            var builder = new StringBuilder();
            
            for (var i = 0; i < size; i++)
            {
                var @char = Chars[_random.Next(Chars.Length-1)]; 
                builder.Append(@char);  
            }  
  
            return builder.ToString();  
        }

        public string RandomEmailService()
        {
            return _emailServices[_random.Next(_emailServices.Length-1)];
        }

        public string RandomPassword()
        {
            var size = _random.Next(4, 16);
            var builder = new StringBuilder();
            
            for (var i = 0; i < size; i++)
            {
                var @char = Chars[_random.Next(Chars.Length-1)]; 
                builder.Append(@char);  
            }  
  
            return BCrypt.Net.BCrypt.HashPassword(builder.ToString());
        }
    }
}