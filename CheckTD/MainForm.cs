using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            dropLabel.DragEnter += DropLabel_DragEnter;
            dropLabel.DragDrop += DropLabel_DragDrop;
        }

        private void DropLabel_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("drag enter");
            e.Effect = DragDropEffects.Copy;
        }

        private void DropLabel_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("drop completed");

            //var formats = e.Data.GetFormats();
            //foreach (var f in formats)
            //{
            //    Console.WriteLine("format: " + f);
            //    var data = e.Data.GetData(f);

            //    Console.WriteLine(data?.ToString());
            //    if (data != null && Equals(data.GetType(), typeof(string[])))
            //    {
            //        string[] s_data = (string[])data;
            //        foreach (var s in s_data) Console.WriteLine(s);
            //    }
            //}
            string file;
            try
            {
                file = (e.Data.GetData("FileDrop") as string[])[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Console.WriteLine("file: " + file);
            if(!IsXML(file))
            {
                MessageBox.Show("Файл не является файлом XML!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Check.CheckFile(file, out string result);

        }

        

        private bool IsXML(string file)
        {
            return file.Substring(file.Length - 3).ToLower() == "xml";
        }

    }
}
