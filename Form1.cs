using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        private string fileName = string.Empty;
               
        //public static string inputStr = "Проверка_Тест_Mime64_123"; // Текст для конвертирования в MIME64 ( можно сделать запрос ввода от ползователя)
               
        public Form1()
        {
            InitializeComponent();
            tsLabel.Text = "Please select a File";
        } 

        private void cmdMIMEcode_Click(object sender, EventArgs e)
        {
            if (fileName != string.Empty)
            {                
                string s = Base64.startEncode(FileUtils.readFile(fileName));
                FileUtils.writeEncoded(fileName, s);
            }
            tsLabel.Text = fileName + " is MIME encoded";
        }

        private void cmdMIMEdecode_Click(object sender, EventArgs e)
        {
            if (fileName != string.Empty)
            {
                byte[] bytes = Base64.startDecode(FileUtils.readFile(fileName));
                FileUtils.writeDecoded(fileName, bytes);
            }

            tsLabel.Text = fileName + " is MIME decoded";
        }

        private void cmdFileChose_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();            

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                fileName = OFD.FileName;
                tsLabel.Text = OFD.FileName;
            }            
        }
                
    }
}
