using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace lrc_convert
{
    class Program
    {
        static void Main()
        {
            string pathText = "1.txt";
            string pathTextTo = "1.lrc";
            int bytesRead = 0;
            int m_sekonds = 5;
            int ogr = 60*(60/m_sekonds);
            bool nr = false;
            //Console.ReadLine();
            //string line, line1;
            int i = 1, kol = 0, j, k = 0;
            string str1 = "[ti:Unknown]\r\n[la:ru]\r\n";
            //string str2 = "[la:ru]\r\n";
            using (FileStream inStream = File.Open(pathText, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream outStream = File.Open(pathTextTo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] sbuffer = Encoding.GetEncoding(1251).GetBytes(str1);
                outStream.Write(sbuffer, 0, str1.Length);
                using (StreamReader sr = new StreamReader(inStream, Encoding.GetEncoding(1251)))
                {
                    StringBuilder result = new StringBuilder();
                    char[] buffer = new char[56];
                    nr = !String.IsNullOrWhiteSpace(ChArToStr(buffer).Trim());
                    while ((sr.Read(buffer, 0, buffer.Length) != 0) & (k < ogr) & nr)
                    {
                        result.Append(Encoding.GetEncoding(1251).GetBytes(buffer)); //  добавляем прочитанные данные в результат
                        sbuffer = Encoding.GetEncoding(1251).GetBytes(tstr(k * m_sekonds));
                        outStream.Write(sbuffer, 0, sbuffer.Length);
                        sbuffer = Encoding.GetEncoding(1251).GetBytes(RemoveEnterSpace(ChArToStr(buffer).Trim()));
                        outStream.Write(sbuffer, 0, sbuffer.Length);
                        //sbuffer = Encoding.GetEncoding(1251).GetBytes(Enviroment.NewLine);
                        sbuffer = Encoding.GetEncoding(1251).GetBytes("\r\n");
                        outStream.Write(sbuffer, 0, sbuffer.Length);
                        Array.Clear(buffer, 0, buffer.Length); //  очищаем буфер
                        k++;
                    }
                    //Encoding.GetEncoding(1251)
                    
                }
                }
        }
        public static string tstr(int seconds)
        {
            int s_, m_, h_;
            s_ = seconds % 60;
            h_ = seconds / 3600;
            m_ = seconds / 60 - h_ * 60;
            return "[" + (m_ < 10 ? "0" : "") + m_.ToString() + ":" + (s_ < 10 ? "0" : "") + s_.ToString() + "]";
        }

        private static string RemoveEnterSpace(string txt)
        {
            string text_ = txt.Replace("\r\n", " ");
            //Console.WriteLine(text_);
            //Console.ReadLine();
            //string text_1 = txt.Replace("\r", " ");
            //text_ = txt.Replace("\n", " ");
            //if (String.IsNullOrWhiteSpace(txt))
            //    text_=null;
            return text_;
        }

        private static string ChArToStr(char[] ar)
        {
            string result_ = "";
            for (int i = 0; i < ar.Length; i++)
                result_ += ar[i];
            return result_;
        } //CharArrayToString

    }
}
