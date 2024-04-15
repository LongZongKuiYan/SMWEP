using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace SuperMarioWorkerEditorPro
{
    class Class_Gzip
    {
        /// <summary>
        /// 实现文件的解压
        /// </summary>
        /// <param name="strPath">当前文件的路径</param>
        /// <param name="newFileName">返回值，返回解压后得到的文件的路径</param>
        public static void Decompress(string strPath, out string newFileName)
        {
            // 读取被压缩的文件的信息
            FileInfo fileToDecompress = new FileInfo(strPath);

            // 创建并读取读取压缩文件的文件流
            FileStream originalFileStream = fileToDecompress.OpenRead();

            // 创建解压后的文件
            string currentFileName = fileToDecompress.FullName;
            newFileName = currentFileName + "x";

            // 创建解压后文件的文件流
            FileStream decompressedFileStream = File.Create(newFileName);

            // 对被压缩文件的文件流执行解压操作
            GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);

            // 将解压结果写入之前创建好的文件中
            decompressionStream.CopyTo(decompressedFileStream);

            // 关闭文件流
            decompressionStream.Close();
            decompressedFileStream.Close();
            originalFileStream.Close();
        }

        /// <summary>
        /// 检验文件的真实格式
        /// </summary>
        /// <param name="path">文件的路径</param>
        /// <returns></returns>
        public static string CheckTrueFileName(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            string bx = " ";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            fs.Close();
            return bx;
        }
    }
}
