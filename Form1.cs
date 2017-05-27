using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace ClubExcel
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }
        void openSheet()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension = ".xlsx";
            filePath += @"\responses" + extension;

            if(File.Exists(filePath))
            {
                Excel.Application xApp = new Excel.Application();
                Excel.Workbook xBook = xApp.Workbooks.Open(filePath);
                Excel.Worksheet xSheet = xApp.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                xApp.Visible = false;

                int c, add;
                string name, id, phone,email, type;

                Excel.Range userRange = xSheet.UsedRange;
                c = userRange.Rows.Count;
                add = c + 1;
                name = textname.Text;
                id = textid.Text;
                phone = textphone.Text;
                email = textmail.Text;
                type = texttype.Text;
                xSheet.Cells[add, 1] = (name);
                xSheet.Cells[add, 2] = (id);
                xSheet.Cells[add, 3] = (phone);
                xSheet.Cells[add, 4] = (email);
                xSheet.Cells[add, 5] = (type);
                textname.Text = "";
                textid.Text = "";
                textphone.Text = "";
                textmail.Text = "";
                texttype.Text = "";

                xApp.DisplayAlerts = false;
                xBook.Save();
                xBook.Close();
                xApp.Quit();
            }
            else
            {
                Excel.Application xApp = new Excel.Application();
                Excel.Workbook xBook = xApp.Workbooks.Add(true);
                Excel.Worksheet xSheet = xApp.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                xApp.Visible = false;

                //initializing the preadsheet
                xSheet.Cells[1, 1] = ("Name");
                xSheet.Cells[1, 2] = ("ID");
                xSheet.Cells[1, 3] = ("Phone");
                xSheet.Cells[1, 4] = ("E-mail");
                xSheet.Cells[1, 5] = ("Comment");

                //inporting first data
                int c, add;
                string name, id, phone, email, type;

                Excel.Range userRange = xSheet.UsedRange;
                c = userRange.Rows.Count;
                add = c + 1;
                name = textname.Text;
                id = textid.Text;
                phone = textphone.Text;
                email = textmail.Text;
                type = texttype.Text;
                xSheet.Cells[add, 1] = (name);
                xSheet.Cells[add, 2] = (id);
                xSheet.Cells[add, 3] = (phone);
                xSheet.Cells[add, 4] = (email);
                xSheet.Cells[add, 5] = (type);
                textname.Text = "";
                textid.Text = "";
                textphone.Text = "";
                textmail.Text = "";
                texttype.Text = "";

                //closing current operation
                xApp.DisplayAlerts = false;
                xBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xApp.Quit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openSheet();
            MessageBox.Show("Response has been submitted.\n", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application was created by\n\nMd. Mujtaba Asif\nDepartment of Computer Science and Engineering\nEast West University\n\nResponses will be found in \n\\Desktop\\response.xlsx file\n", "Thank You", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
