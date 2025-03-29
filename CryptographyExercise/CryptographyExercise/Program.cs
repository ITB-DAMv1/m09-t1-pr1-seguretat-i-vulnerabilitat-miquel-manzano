using System.Security.Cryptography;
using System.Text;

internal class Program
{
    // Variables per emmagatzemar dades en memòria
    private static string storedUsername = "";
    private static string storedHashedPassword = "";
    private static RSAParameters publicKey;
    private static RSAParameters privateKey;
    private static void Main(string[] args)
    {
        // Generar claus RSA al iniciar el programa
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMENÚ PRINCIPAL");
            Console.WriteLine("1. Registre d'usuari");
            Console.WriteLine("2. Verificació de dades");
            Console.WriteLine("3. Encriptació/Desencriptació RSA");
            Console.WriteLine("4. Sortir");
            Console.Write("Selecciona una opció: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    VerifyUser();
                    break;
                case "3":
                    EncryptDecryptWithRSA();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opció no vàlida. Torna a intentar.");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        Console.Write("Introdueix el nom d'usuari: ");
        string username = Console.ReadLine();

        Console.Write("Introdueix la contrasenya: ");
        string password = Console.ReadLine();

        // Encriptar la contrasenya amb SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            storedUsername = username;
            storedHashedPassword = hashedPassword;

            Console.WriteLine($"\nUsuari registrat correctament.");
            Console.WriteLine($"Hash SHA256 de la contrasenya: {hashedPassword}");
        }
    }

    static void VerifyUser()
    {
        if (string.IsNullOrEmpty(storedUsername))
        {
            Console.WriteLine("No hi ha cap usuari registrat. Primer fes el registre.");
            return;
        }

        Console.Write("Introdueix el nom d'usuari: ");
        string username = Console.ReadLine();

        Console.Write("Introdueix la contrasenya: ");
        string password = Console.ReadLine();

        // Calcular hash de la contrasenya introduïda
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            if (username == storedUsername && hashedPassword == storedHashedPassword)
            {
                Console.WriteLine("\nLes dades són correctes. Accés permès.");
            }
            else
            {
                Console.WriteLine("\nLes dades no coincideixen. Accés denegat.");
            }
        }
    }

    static void EncryptDecryptWithRSA()
    {
        Console.Write("Introdueix el text a encriptar: ");
        string originalText = Console.ReadLine();

        if (string.IsNullOrEmpty(originalText))
        {
            Console.WriteLine("El text no pot estar buit.");
            return;
        }

        try
        {
            // Encriptar amb la clau pública
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(originalText);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            Console.WriteLine($"\nText encriptat: {Convert.ToBase64String(encryptedData)}");

            // Desencriptar amb la clau privada
            string decryptedText;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                byte[] decryptedData = rsa.Decrypt(encryptedData, false);
                decryptedText = Encoding.UTF8.GetString(decryptedData);
            }

            Console.WriteLine($"Text desencriptat: {decryptedText}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}