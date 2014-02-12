
namespace DbManager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeViewDatabases = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStripOpDb = new System.Windows.Forms.ToolStrip();
            this.opendb = new System.Windows.Forms.ToolStripButton();
            this.closedb = new System.Windows.Forms.ToolStripButton();
            this.refreshdb = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.sqlContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStripOpSql = new System.Windows.Forms.ToolStrip();
            this.run = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControlResult = new System.Windows.Forms.TabControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.dataResult = new System.Windows.Forms.DataGridView();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.Info = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStripOpDb.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStripOpSql.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tabControlResult.SuspendLayout();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResult)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 621);
            this.panel1.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 447);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(262, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.propertyGrid1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 447);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 174);
            this.panel4.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ControlLightLight;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(262, 174);
            this.propertyGrid1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeViewDatabases);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 415);
            this.panel3.TabIndex = 2;
            // 
            // treeViewDatabases
            // 
            this.treeViewDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDatabases.Location = new System.Drawing.Point(0, 0);
            this.treeViewDatabases.Name = "treeViewDatabases";
            this.treeViewDatabases.Size = new System.Drawing.Size(262, 415);
            this.treeViewDatabases.TabIndex = 0;
            this.treeViewDatabases.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDatabases_BeforeExpand);
            this.treeViewDatabases.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDatabases_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStripOpDb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 32);
            this.panel2.TabIndex = 1;
            // 
            // toolStripOpDb
            // 
            this.toolStripOpDb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripOpDb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpDb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opendb,
            this.closedb,
            this.refreshdb});
            this.toolStripOpDb.Location = new System.Drawing.Point(0, 7);
            this.toolStripOpDb.Name = "toolStripOpDb";
            this.toolStripOpDb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpDb.Size = new System.Drawing.Size(262, 25);
            this.toolStripOpDb.TabIndex = 3;
            this.toolStripOpDb.Text = "toolStrip1";
            // 
            // opendb
            // 
            this.opendb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.opendb.Image = ((System.Drawing.Image)(resources.GetObject("opendb.Image")));
            this.opendb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opendb.Name = "opendb";
            this.opendb.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.opendb.Size = new System.Drawing.Size(30, 22);
            this.opendb.Text = "toolStripButton1";
            this.opendb.ToolTipText = "打开数据连接";
            this.opendb.Click += new System.EventHandler(this.opendb_Click);
            // 
            // closedb
            // 
            this.closedb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closedb.Image = ((System.Drawing.Image)(resources.GetObject("closedb.Image")));
            this.closedb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closedb.Name = "closedb";
            this.closedb.Size = new System.Drawing.Size(23, 22);
            this.closedb.Text = "toolStripButton2";
            this.closedb.ToolTipText = "断开数据连接";
            this.closedb.Click += new System.EventHandler(this.closedb_Click);
            // 
            // refreshdb
            // 
            this.refreshdb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshdb.Image = ((System.Drawing.Image)(resources.GetObject("refreshdb.Image")));
            this.refreshdb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshdb.Name = "refreshdb";
            this.refreshdb.Size = new System.Drawing.Size(23, 22);
            this.refreshdb.Text = "toolStripButton3";
            this.refreshdb.ToolTipText = "刷新当前连接";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(262, 618);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(660, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "dbnew2.ico");
            this.imageList1.Images.SetKeyName(2, "Table.ico");
            this.imageList1.Images.SetKeyName(3, "col.ico");
            this.imageList1.Images.SetKeyName(4, "View1.ico");
            this.imageList1.Images.SetKeyName(5, "Proc.ico");
            this.imageList1.Images.SetKeyName(6, "paramin.ico");
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(262, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 618);
            this.splitter3.TabIndex = 5;
            this.splitter3.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelCenter);
            this.panelRight.Controls.Add(this.panelTop);
            this.panelRight.Controls.Add(this.panelBottom);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(265, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(657, 618);
            this.panelRight.TabIndex = 6;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.sqlContent);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 32);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(657, 315);
            this.panelCenter.TabIndex = 6;
            // 
            // sqlContent
            // 
            this.sqlContent.AutoSize = true;
            this.sqlContent.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.sqlContent.BackColor = System.Drawing.SystemColors.Control;
            this.sqlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sqlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlContent.Encoding = ((System.Text.Encoding)(resources.GetObject("sqlContent.Encoding")));
            this.sqlContent.ForeColor = System.Drawing.Color.Black;
            this.sqlContent.IsIconBarVisible = false;
            this.sqlContent.Location = new System.Drawing.Point(0, 0);
            this.sqlContent.Name = "sqlContent";
            this.sqlContent.ShowEOLMarkers = true;
            this.sqlContent.ShowInvalidLines = false;
            this.sqlContent.ShowSpaces = true;
            this.sqlContent.ShowTabs = true;
            this.sqlContent.ShowVRuler = true;
            this.sqlContent.Size = new System.Drawing.Size(657, 315);
            this.sqlContent.TabIndex = 1;
            this.sqlContent.UseAntiAliasFont = true;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelTop.Controls.Add(this.toolStripOpSql);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(657, 32);
            this.panelTop.TabIndex = 5;
            // 
            // toolStripOpSql
            // 
            this.toolStripOpSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripOpSql.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.run});
            this.toolStripOpSql.Location = new System.Drawing.Point(0, 7);
            this.toolStripOpSql.Name = "toolStripOpSql";
            this.toolStripOpSql.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpSql.Size = new System.Drawing.Size(657, 25);
            this.toolStripOpSql.TabIndex = 1;
            this.toolStripOpSql.Text = "toolStrip2";
            // 
            // run
            // 
            this.run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.run.Image = ((System.Drawing.Image)(resources.GetObject("run.Image")));
            this.run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(23, 22);
            this.run.Text = "toolStripButton1";
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.tabControlResult);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 347);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(657, 271);
            this.panelBottom.TabIndex = 4;
            // 
            // tabControlResult
            // 
            this.tabControlResult.Controls.Add(this.tabResult);
            this.tabControlResult.Controls.Add(this.tabInfo);
            this.tabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResult.Location = new System.Drawing.Point(0, 0);
            this.tabControlResult.Name = "tabControlResult";
            this.tabControlResult.SelectedIndex = 0;
            this.tabControlResult.Size = new System.Drawing.Size(657, 271);
            this.tabControlResult.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.dataResult);
            this.tabResult.Location = new System.Drawing.Point(4, 25);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(649, 242);
            this.tabResult.TabIndex = 0;
            this.tabResult.Text = "结果集";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // dataResult
            // 
            this.dataResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataResult.Location = new System.Drawing.Point(3, 3);
            this.dataResult.Name = "dataResult";
            this.dataResult.RowTemplate.Height = 27;
            this.dataResult.Size = new System.Drawing.Size(643, 236);
            this.dataResult.TabIndex = 0;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.Info);
            this.tabInfo.Location = new System.Drawing.Point(4, 25);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(649, 242);
            this.tabInfo.TabIndex = 1;
            this.tabInfo.Text = "信息";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.Location = new System.Drawing.Point(3, 3);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(643, 236);
            this.Info.TabIndex = 1;
            this.Info.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 621);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "DbManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStripOpDb.ResumeLayout(false);
            this.toolStripOpDb.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStripOpSql.ResumeLayout(false);
            this.toolStripOpSql.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.tabControlResult.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataResult)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeViewDatabases;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStrip toolStripOpDb;
        private System.Windows.Forms.ToolStripButton opendb;
        private System.Windows.Forms.ToolStripButton closedb;
        private System.Windows.Forms.ToolStripButton refreshdb;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenter;
        private ICSharpCode.TextEditor.TextEditorControl sqlContent;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStripOpSql;
        private System.Windows.Forms.ToolStripButton run;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TabControl tabControlResult;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.DataGridView dataResult;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.RichTextBox Info;



    }
}

