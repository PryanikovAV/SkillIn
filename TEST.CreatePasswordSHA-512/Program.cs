// Пример кода на C# для генерации SHA-512 хэша пароля:
using System.Security.Cryptography;
using System.Text;

string password = "password123"; // <-- Придумать и вставить пароль
byte[] hash = SHA512.HashData(Encoding.UTF8.GetBytes(password));
string hexPassword = BitConverter.ToString(hash).Replace("-", "");

Console.WriteLine(hexPassword); // <-- Скопировать этот хэш для SQL-запросов
