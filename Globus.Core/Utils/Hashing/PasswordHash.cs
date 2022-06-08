using Secure.Hash.Algorithm.SDK.Controllers;

namespace Globus.Core.Utils.Hashing
{
    public static class PasswordHash
    {
        static readonly SecureData SecureData = new();
        /// <summary>
        /// Use this static utility class to encrypt any data.
        /// </summary>
        /// <param name="key">This should be a unique id or property.</param>
        /// <param name="plainText">This is the data or plain text to be encrypted.</param>
        /// <returns>Encrypted Data.</returns>
        public static string EncryptData(string key, string plainText)
            => SecureData.Encrypt(key, plainText);

        /// <summary>
        /// Use this static utility class to decrypt encrypted data.
        /// </summary>
        /// <param name="key">The unique id or property that was used during encryption.</param>
        /// <param name="encData">The encrypted data to be decrypted.</param>
        /// <returns>Decrypted Data.</returns>
        public static string DecryptData(string key, string encData)
            => SecureData.Decrypt(key, encData);
    }
}
