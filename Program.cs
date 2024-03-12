namespace Class_Practical;

using System.Text;
using Crypto.AES;

internal class Program
{
    private static void Main(string[] args)
    {
        //Program.GZIPExample();

        Program.Huffman();
    }

    private static void Huffman()
    {
        var huffmanCoding = new Huffman();

        var originalString = "The quick brown fox jumps over the lazy dog.";

        var root = huffmanCoding.BuildHuffmanTree(originalString);
        if (root == null)
        {
            Console.WriteLine("Failed to build Huffman Tree.");
            return;
        }

        var codes = new Dictionary<char, string>();
        huffmanCoding.GenerateCodes(root, "", codes);

        foreach (var code in codes) Console.WriteLine($"{code.Key} : {code.Value}");

        var compressedData = huffmanCoding.Compress(originalString, codes);
        Console.WriteLine($"Original Size: {Encoding.UTF8.GetByteCount(originalString) * 8} bits");
        Console.WriteLine($"Compressed Size: {compressedData.Length * 8} bits");

        var decompressedString = huffmanCoding.Decompress(compressedData, root);
        Console.WriteLine($"Decompressed String: {decompressedString}");
    }

    private static void GZIPExample()
    {
        var message = "The quick brown fox jumps over the lazy dog.";
        var key = "Password";

        Console.WriteLine("Message: " + message + "\nKey: " + key);

        var encodedMessage = Encoding.UTF8.GetBytes(message);

        var encryptedMessage = AES.EncryptBytes(key, encodedMessage);
        Console.WriteLine("Encrypted message: " + BitConverter.ToString(encryptedMessage));

        var compressedMessage = GZIP.CompressMessage(encryptedMessage);
        Console.WriteLine("Compressed message: " + BitConverter.ToString(compressedMessage));

        var decompressedMessage = GZIP.DecompressMssage(compressedMessage);
        Console.WriteLine("decompressed message: " + BitConverter.ToString(decompressedMessage));

        var decryptedMessage = AES.DecryptBytes(key, encryptedMessage);
        Console.WriteLine("Decrypted message: " + Encoding.UTF8.GetString(decryptedMessage));
    }
}