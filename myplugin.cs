using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace excelpluginfirst
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.FileName = "*";
            openfile.DefaultExt = "bmp";
            openfile.ValidateNames = true;

            openfile.Filter = "Excel File (.xls)|*.xlsx";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openfileedit.Text = openfile.FileName;
            }
        }

        private void checkexcel_Click(object sender, EventArgs e)
        {
            processexcel getexcel = new processexcel();
            getexcel.CheckExcel();
            getexcel.AddActiveData();
            getexcel.CopyColumData();
            getexcel.worksheet();
            getexcel.addworksheet();
            getexcel.DeleteSheet();
        }

        private void setdata_Click(object sender, EventArgs e)
        {

        }

        private void gendata_Click(object sender, EventArgs e)
        {
            processexcel getexcel = new processexcel();
            getexcel.gendata();
        }

        private void addmenu_Click(object sender, EventArgs e)
        {
            addmenu test = new addmenu();
            test.addtomenu();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            openfileedit.Text = "";
            openfileedit.Text = "current width" + this.Width + "current height" + this.Height;
            //MessageBox.Show("current width" + this.Width + "current height" + this.Height);
        }
    }
}
