using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using CheckTD.Properties;

namespace CheckTD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TNVED_Codes.Initialize();

            dropLabel.DragEnter += DropLabel_DragEnter;
            dropLabel.DragDrop += DropLabel_DragDrop;

            SizeChanged += MainForm_SizeChanged;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ChangeDropLabelSize();
            ChangeResultLabelSize();
        }

        private void DropLabel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void DropLabel_DragDrop(object sender, DragEventArgs e)
        {
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

            //Console.WriteLine("file: " + file);
            if(!IsXML(file))
            {
                MessageBox.Show("Файл не является файлом XML!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CheckResult res = Check.CheckFile(file, out string result);
            ShowResultPicture(res);
            ResultLabel.Text = "Проверен файл " + GetFileName(file) + Environment.NewLine;
            ResultLabel.Text += result;

            //Console.WriteLine($"Result: {res} \n {result}");




        }

        private bool IsXML(string file)
        {
            return file.Substring(file.Length - 3).ToLower() == "xml";
        }



        private void ShowResultPicture(CheckResult result)
        {
            switch(result)
            {
                case CheckResult.Contained:
                    pictureResult.Image = Resources.checkMarkBad;
                    break;
                case CheckResult.Contained_but_excluded:
                    pictureResult.Image = Resources.checkMarkAttention;
                    break;
                case CheckResult.NOT_Contained:
                    pictureResult.Image = Resources.checkMarkGood_picture;
                    break;
                default:
                    pictureResult.Image = null;
                    break;
            }
        }



        private void ChangeDropLabelSize()
        {
            dropLabel.Width = this.Width - 142;
        }

        private void ChangeResultLabelSize()
        {
            ResultLabel.Width = this.Width - 36;
            ResultLabel.Height = this.Height - 180;
            //Console.WriteLine($"width: {width},  ResultLabel.Width: {ResultLabel.Width}, mainform width: {this.Width}");

        }


        private string GetFileName(string fullFileName)
        {
            return fullFileName.Split('\\').Last();
        }

    }
}
