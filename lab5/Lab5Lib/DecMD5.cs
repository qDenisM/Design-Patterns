using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace Lab5Lib
{
    public class DecMD5 : Decorator // хэширование
    {
        public DecMD5(IWriter writer) : base(writer) { }

        public override string? Save(string? message)
        {
            using (var md5 = MD5.Create())
            {
                var dataBytes = Encoding.UTF8.GetBytes(message ?? string.Empty);
                var encryptedData = md5.ComputeHash(dataBytes);
                var hashedMessage = Convert.ToBase64String(encryptedData);
                var decoratedMessage = $"{message}{Constant.Delimiter}{hashedMessage}";
                return writer?.Save(decoratedMessage);
            }
        }
    }
}
