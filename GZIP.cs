namespace Class_Practical;

using System.IO.Compression;

public class GZIP
{
    public static byte[] CompressMessage(byte[] buffer)
    {
        using var memStream = new MemoryStream();

        using (var gZipStream = new GZipStream(memStream, CompressionMode.Compress, true))
        {
            gZipStream.Write(buffer, 0, buffer.Length);
        }

        return memStream.ToArray();
    }

    public static byte[] DecompressMssage(byte[] compressedData)
    {
        using var memStream = new MemoryStream(compressedData);

        using var gZipStream = new GZipStream(memStream, CompressionMode.Decompress, true);

        using var resultStream = new MemoryStream();

        gZipStream.CopyTo(resultStream);

        return resultStream.ToArray();
    }
}