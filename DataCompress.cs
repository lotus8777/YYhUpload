using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace YYhUpload
{
   public static class DataCompress
    {
        /// <summary>
        /// 压缩数据转base64
        /// </summary>
        /// <param name="inParam">入参</param>
        /// <returns></returns>
        public static string CompressDataToBase64(string inParam)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(inParam);
                var ms = new MemoryStream();
                var zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(bytes, 0, bytes.Length);
                zip.Close();
                var buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return Convert.ToBase64String(buffer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Base64解码装为普通字符串
        /// </summary>
        /// <param name="result">待解码的密文</param>
        /// <param name="encoding">解码采用的编码方式，注意和加密时采用的方式一致</param>
        /// <returns>解码后的字符串</returns>
        public static string DecodeBase64(string result, Encoding encoding)
        {
            string decodeStr;
            var bytes = Convert.FromBase64String(result);
            try
            {
                decodeStr = encoding.GetString(bytes);
            }
            catch
            {
                decodeStr = result;
            }
            return decodeStr;
        }

        public static string GetDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
            {
                return "";
            }

            var zippedData = Convert.FromBase64String(zippedString.ToString());
            return Encoding.UTF8.GetString(Decompress(zippedData));
        }

        private static byte[] Decompress(byte[] zippedData)
        {
            var ms = new MemoryStream(zippedData);
            var compressedStream = new GZipStream(ms, CompressionMode.Decompress);
            var outBuffer = new MemoryStream();
            var block = new byte[1024];
            while (true)
            {
                var bytesRead = compressedStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                {
                    break;
                }
                outBuffer.Write(block, 0, bytesRead);
            }
            compressedStream.Close();
            return outBuffer.ToArray();
        }
    }
}
