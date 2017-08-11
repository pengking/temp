using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace excelpluginfirst
{
    public partial class ThisAddIn
    {
        public Microsoft.Office.Tools.CustomTaskPane customPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ShowShanuControl();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            MessageBox.Show("close the file");
        }
        public void ShowShanuControl()
        {
            var txtObject = new UserControl1();
            customPane = this.CustomTaskPanes.Add(txtObject, "Enter Text");
            customPane.Width = txtObject.Width;
            customPane.Visible = true;
        }
        

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
