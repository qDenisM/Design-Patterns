﻿using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace Lab5Lib
{
    public class DecSHA512 : Decorator // хэширование
    {
        public DecSHA512(IWriter writer) : base(writer) { }

        public override string? Save(string? message)
        {
            using (var sha512 = SHA512.Create())
            {
                var dataBytes = Encoding.UTF8.GetBytes(message ?? string.Empty);
                var hashedData = sha512.ComputeHash(dataBytes);
                var hashedMessage = Convert.ToBase64String(hashedData);
                var decoratedMessage = $"{message}{Constant.Delimiter}{hashedMessage}";
                return writer?.Save(decoratedMessage);
            }
        }
    }
}
