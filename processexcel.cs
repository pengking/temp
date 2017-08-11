using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace excelpluginfirst
{
    class processexcel
    {
        public void CheckExcel()
        {
            object o = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            Globals.ThisAddIn.Application.ActiveSheet.Cells.ClearContents();
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            MessageBox.Show("currrent count is " + count);
        }

        public void AddActiveData()
        {
            Globals.ThisAddIn.Application.ActiveSheet.Cells[1, 1].Value2 = "Item Code";
            Globals.ThisAddIn.Application.ActiveSheet.Cells[1, 2].Value2 = "Item Name";
        }

        public void CopyColumData()
        {
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            MessageBox.Show("nothing test1");
           // Workbook book = Globals.ThisAddIn.Application.ThisWorkbook; 
            for(int i=0;i<count;i++)
            {
                //MessageBox.Show(book.Worksheets[i].Name);
            }
            MessageBox.Show("nothing test");
        }

        public void worksheet()
        {
             int count = Globals.ThisAddIn.Application.Sheets.Count;
            //for (int i = 0; i < workbookcount; i++)
            //{
            //    int count = Globals.ThisAddIn.Application.Workbooks[1].Worksheets.Count;
            //    for (int j = 0; j < count; j++)
            //    {
            //        Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Workbooks[i+i].Worksheets[j + 1];
            //        MessageBox.Show("the work sheet count is " + ws.Name);
            //    }
                
            //}

             for (int i = 0; i < count; i++)
             {

                 Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Sheets[i+1];
                 MessageBox.Show("the work sheet count is " + ws.Name);
             }
        }

        public void addworksheet()
        {
            //Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets.Add(Globals.ThisAddIn.Application.ActiveSheet);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            ws.Name = "hello wrold" + ran.Next(100);

        }

        public void DeleteSheet()
        {
            int count = Globals.ThisAddIn.Application.Sheets.Count;
            for (int i = 0; i < count; i++)
            {
                Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Sheets[i+1];
                string name = ws.Name;
                if (name == "hello wrold84")
                {
                    MessageBox.Show("get item");

                    Globals.ThisAddIn.Application.Worksheets[i+1].Delete();
                }
            }
        }
        public void gendata()
        {
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets["Sheet1"];
            int count = 20;
            for(int i=0;i<count;i++)
            {
                 for(int j=0;j<count;j++)
                 {
                     ws.Cells[i + 1, j + 1].Value2 = ran.Next(100);
                 }
                
            }
            int rowscount = ws.Rows.Count;
            int columncount = ws.Columns.Count;
            MessageBox.Show("current rows is " + rowscount + "current columns is " + columncount);
            
        }

        public void setdata()
        {
            Excel.Worksheet ws = (Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets["Sheet1"];
            if (ws != null)
            {
                Excel.Range data = ws.get_Range("A1", "B3");
            }
        }
       


    }
}
