namespace excelpluginfirst
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openfile = new System.Windows.Forms.Button();
            this.openfileedit = new System.Windows.Forms.TextBox();
            this.checkexcel = new System.Windows.Forms.Button();
            this.setdata = new System.Windows.Forms.Button();
            this.gendata = new System.Windows.Forms.Button();
            this.addmenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openfile
            // 
            this.openfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openfile.Location = new System.Drawing.Point(27, 45);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(89, 35);
            this.openfile.TabIndex = 0;
            this.openfile.Text = "openfile";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // openfileedit
            // 
            this.openfileedit.Location = new System.Drawing.Point(15, 18);
            this.openfileedit.Name = "openfileedit";
            this.openfileedit.Size = new System.Drawing.Size(112, 21);
            this.openfileedit.TabIndex = 1;
            // 
            // checkexcel
            // 
            this.checkexcel.Location = new System.Drawing.Point(27, 111);
            this.checkexcel.Name = "checkexcel";
            this.checkexcel.Size = new System.Drawing.Size(89, 37);
            this.checkexcel.TabIndex = 2;
            this.checkexcel.Text = "checkexcel";
            this.checkexcel.UseVisualStyleBackColor = true;
            this.checkexcel.Click += new System.EventHandler(this.checkexcel_Click);
            // 
            // setdata
            // 
            this.setdata.Location = new System.Drawing.Point(27, 179);
            this.setdata.Name = "setdata";
            this.setdata.Size = new System.Drawing.Size(89, 34);
            this.setdata.TabIndex = 3;
            this.setdata.Text = "setdata";
            this.setdata.UseVisualStyleBackColor = true;
            this.setdata.Click += new System.EventHandler(this.setdata_Click);
            // 
            // gendata
            // 
            this.gendata.Location = new System.Drawing.Point(27, 255);
            this.gendata.Name = "gendata";
            this.gendata.Size = new System.Drawing.Size(89, 38);
            this.gendata.TabIndex = 4;
            this.gendata.Text = "gendata";
            this.gendata.UseVisualStyleBackColor = true;
            this.gendata.Click += new System.EventHandler(this.gendata_Click);
            // 
            // addmenu
            // 
            this.addmenu.Location = new System.Drawing.Point(27, 320);
            this.addmenu.Name = "addmenu";
            this.addmenu.Size = new System.Drawing.Size(89, 34);
            this.addmenu.TabIndex = 5;
            this.addmenu.Text = "addmenu";
            this.addmenu.UseVisualStyleBackColor = true;
            this.addmenu.Click += new System.EventHandler(this.addmenu_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.Controls.Add(this.addmenu);
            this.Controls.Add(this.gendata);
            this.Controls.Add(this.setdata);
            this.Controls.Add(this.checkexcel);
            this.Controls.Add(this.openfileedit);
            this.Controls.Add(this.openfile);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(139, 412);
            this.Resize += new System.EventHandler(this.UserControl1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.TextBox openfileedit;
        private System.Windows.Forms.Button checkexcel;
        private System.Windows.Forms.Button setdata;
        private System.Windows.Forms.Button gendata;
        private System.Windows.Forms.Button addmenu;
    }
}
