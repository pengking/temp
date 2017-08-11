using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace excelpluginfirst
{
    class addmenu
    {
        public void addtomenu()
        {
            Microsoft.Office.Core.CommandBar mzBar = Globals.ThisAddIn.Application.CommandBars["cell"];    //excel文档已有的右键菜单cell                

            Microsoft.Office.Core.CommandBarControls bars = mzBar.Controls;
            foreach (Microsoft.Office.Core.CommandBarControl temp_contrl in bars)
            {
                string t = temp_contrl.Tag;
                //如果已经存在就删除

                if (t == "Test")
                {
                    temp_contrl.Delete();
                }
            }
            Microsoft.Office.Core.CommandBarControl comControl = bars.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);   //添加自己的菜单项
            Microsoft.Office.Core.CommandBarButton comButton = comControl as Microsoft.Office.Core.CommandBarButton;
            if (comControl != null)
            {
                comButton.Tag = "Test";
                comButton.Caption = "测试";
                comButton.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonIconAndCaption;
                comButton.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(test_Click);
            }
        }
        public void addtomenu_test()
        {
            Microsoft.Office.Core.CommandBar cellBar = Globals.ThisAddIn.Application.ThisWorkbook.Application.CommandBars["cell"];
            Microsoft.Office.Core.CommandBarControls bars = cellBar.Controls;
            Microsoft.Office.Core.CommandBarControl newCtrl = bars.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);
            //newCtrl.Caption = DEL_SUB_ITEM_STR;
            Microsoft.Office.Core.CommandBarButton newBtn = newCtrl as Microsoft.Office.Core.CommandBarButton;
            newBtn.Tag = "MyTest";
            newBtn.Caption = "My Test";
            newBtn.FaceId = 0163;
            newBtn.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonCaption;
            newBtn.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(test_Click);

        }

        private void test_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Globals.ThisAddIn.customPane.Visible = true;
            MessageBox.Show("hello wrold");
        }
    }
}
