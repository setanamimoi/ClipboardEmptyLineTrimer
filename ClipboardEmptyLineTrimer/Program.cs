using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ClipboardEmptyLineTrimer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using(StringWriter writer = new StringWriter())
            using(StringReader reader = new StringReader(Clipboard.GetText()))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    if (line.Any() == false)
                    {
                        continue;
                    }

                    writer.WriteLine(line);
                }

                Clipboard.SetText(writer.ToString());
            }
        }
    }
}
