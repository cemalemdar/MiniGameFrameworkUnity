using System;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly string key = "nT8v6WxRmU24FqJDzYeB3AKpQXHgC5Ls";

    public static string Encrypt(string plainText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        using var aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = new byte[16]; // Zero IV (consider randomizing in real apps)

        using var encryptor = aes.CreateEncryptor();
        byte[] buffer = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = encryptor.TransformFinalBlock(buffer, 0, buffer.Length);

        return Convert.ToBase64String(encrypted);
    }

    public static string Decrypt(string encryptedText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        using var aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = new byte[16];

        using var decryptor = aes.CreateDecryptor();
        byte[] buffer = Convert.FromBase64String(encryptedText);
        byte[] decrypted = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);

        return Encoding.UTF8.GetString(decrypted);
    }
}
