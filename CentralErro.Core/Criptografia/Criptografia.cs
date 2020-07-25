using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CentralErro.Core
{
    public class Criptografia
    {
        const string strChave = "12345";

        public static string CriptografarTripleDES(string texto, string senha)
        {

            byte[] results; UTF8Encoding UTF8 = new UTF8Encoding();
            // Passo 1. Calculamos o hash da senha usando MD5
            // Usamos o gerador de hash MD5 como o resultado é um array de bytes de 128 bits
            // que é um comprimento válido para o codificador TripleDES usado abaixo
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tDESKey = hashProvider.ComputeHash(UTF8.GetBytes(senha));

            // Passo 2. Cria um objeto new TripleDESCryptoServiceProvider
            TripleDESCryptoServiceProvider tDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Passo 3. Configuração do codificador
            tDESAlgorithm.Key = tDESKey;
            tDESAlgorithm.Mode = CipherMode.ECB;
            tDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Passo 4. Converta a seqüência de entrada para um byte []
            byte[] dataToEncrypt = UTF8.GetBytes(texto);
            // Passo 5. Tentativa para criptografar a seqüência de caracteres
            try
            {
                ICryptoTransform encryptor = tDESAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                // Limpe as tripleDES e serviços hashProvider de qualquer informação sensível
                tDESAlgorithm.Clear();
                hashProvider.Clear();
            }
            // Passo 6. Volte a seqüência criptografada como uma string base64 codificada
            return Convert.ToBase64String(results);
        }

        /// <summary>
        /// Método para Descriptografia em 3Des
        /// </summary>
        public static string DescriptografarTripleDES(string texto, string senha)
        {
            byte[] results;
            UTF8Encoding UTF8 = new UTF8Encoding();

            // Passo 1. Calculamos o hash da senha usando MD5
            // Usamos o gerador de hash MD5 como o resultado é um array de bytes de 128 bits
            // que é um comprimento válido para o codificador TripleDES usado abaixo
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tDESKey = hashProvider.ComputeHash(UTF8.GetBytes(senha));

            // Passo 2. Cria um objeto new TripleDESCryptoServiceProvider 
            var tDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Passo 3. Configuração do codificador
            tDESAlgorithm.Key = tDESKey;
            tDESAlgorithm.Mode = CipherMode.ECB;
            tDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Passo 4. Converta a seqüência de entrada para um byte []
            byte[] dataToDecrypt = Convert.FromBase64String(texto);
            // Passo 5. Tentativa para criptografar a seqüência de caracteres
            try
            {
                ICryptoTransform Decryptor = tDESAlgorithm.CreateDecryptor();
                results = Decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                // Limpe as tripleDES e serviços hashProvider de qualquer informação sensível
                tDESAlgorithm.Clear();
                hashProvider.Clear();
            }

            // Passo 6. Volte a seqüência criptografada como uma string base64 codificada 
            return UTF8.GetString(results);
        }

        /// <summary>
        /// Método para Criptografia em 3Des
        /// </summary>
        public static string CriptografarTripleDES(string texto)
        {
            return CriptografarTripleDES(texto, strChave);
        }

        /// <summary>
        /// Método para Descriptografia em 3Des
        /// </summary>
        public static string DescriptografarTripleDES(string texto)
        {
            return DescriptografarTripleDES(texto, strChave);
        }

    }
}
