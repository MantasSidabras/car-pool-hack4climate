using System;
using System.Text;

namespace CarPool.Trip.Application.Encryption
{
    public interface IEncryptor
    {
        public string EncryptData(int data);
        public int DecryptData(string token);
    }

    public class Encryptor : IEncryptor
    {
        private readonly string _appSecret;
        public Encryptor(string appSecret)
        {
            _appSecret = appSecret;
        }

        public int DecryptData(string token)
        {
            return int.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(token)).Replace(_appSecret, string.Empty));
        }

        public string EncryptData(int data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{data.ToString()}{_appSecret}"));
        }
    }
}
