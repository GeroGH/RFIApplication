namespace ReadRfiFromExcel
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonLoadFile = new System.Windows.Forms.Button();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TextBoxRFIColumn = new System.Windows.Forms.TextBox();
            this.TextBoxSubjectColumn = new System.Windows.Forms.TextBox();
            this.TextBoxClosedColumn = new System.Windows.Forms.TextBox();
            this.ButtonReload = new System.Windows.Forms.Button();
            this.TextBoxHeaderRow = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.ButtonUpdateSelectedParts = new System.Windows.Forms.Button();
            this.ButtonRepresentationClosedOut = new System.Windows.Forms.Button();
            this.ButtonRepresentationRfiNo = new System.Windows.Forms.Button();
            this.ButtonRepresentationPhase = new System.Windows.Forms.Button();
            this.ExcelFileLocationBox = new System.Windows.Forms.GroupBox();
            this.OpenExcelFile = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelFileColumnAndRowsBox = new System.Windows.Forms.GroupBox();
            this.checkBoxExcelNotDefault = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RepresentationBox = new System.Windows.Forms.GroupBox();
            this.ExcelPreviewBox = new System.Windows.Forms.GroupBox();
            this.buttonRemoveValue = new System.Windows.Forms.Button();
            this.buttonAssignValue = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.GroupBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.ExcelFileLocationBox.SuspendLayout();
            this.ExcelFileColumnAndRowsBox.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.RepresentationBox.SuspendLayout();
            this.ExcelPreviewBox.SuspendLayout();
            this.StatusBox.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonLoadFile
            // 
            this.ButtonLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoadFile.Location = new System.Drawing.Point(6, 19);
            this.ButtonLoadFile.Name = "ButtonLoadFile";
            this.ButtonLoadFile.Size = new System.Drawing.Size(192, 46);
            this.ButtonLoadFile.TabIndex = 0;
            this.ButtonLoadFile.Text = "Excel File Location";
            this.toolTip.SetToolTip(this.ButtonLoadFile, "Setup the initial path for the excel file");
            this.ButtonLoadFile.UseVisualStyleBackColor = true;
            this.ButtonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPath.Location = new System.Drawing.Point(18, 19);
            this.TextBoxPath.Multiline = true;
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.Size = new System.Drawing.Size(306, 46);
            this.TextBoxPath.TabIndex = 2;
            this.toolTip.SetToolTip(this.TextBoxPath, "Current location of the excel file. The text can be directly edited");
            this.TextBoxPath.TextChanged += new System.EventHandler(this.TextBoxPath_TextChanged);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(6, 21);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(639, 186);
            this.DataGridView.TabIndex = 3;
            this.toolTip.SetToolTip(this.DataGridView, "Represent the RFI’s data from the excel file");
            // 
            // TextBoxRFIColumn
            // 
            this.TextBoxRFIColumn.Enabled = false;
            this.TextBoxRFIColumn.Location = new System.Drawing.Point(216, 42);
            this.TextBoxRFIColumn.Name = "TextBoxRFIColumn";
            this.TextBoxRFIColumn.Size = new System.Drawing.Size(105, 20);
            this.TextBoxRFIColumn.TabIndex = 4;
            this.TextBoxRFIColumn.Text = "2";
            this.TextBoxRFIColumn.TextChanged += new System.EventHandler(this.TextBoxRFIColumn_TextChanged);
            // 
            // TextBoxSubjectColumn
            // 
            this.TextBoxSubjectColumn.Enabled = false;
            this.TextBoxSubjectColumn.Location = new System.Drawing.Point(339, 42);
            this.TextBoxSubjectColumn.Name = "TextBoxSubjectColumn";
            this.TextBoxSubjectColumn.Size = new System.Drawing.Size(128, 20);
            this.TextBoxSubjectColumn.TabIndex = 4;
            this.TextBoxSubjectColumn.Text = "7";
            this.TextBoxSubjectColumn.TextChanged += new System.EventHandler(this.TextBoxSubjectColumn_TextChanged);
            // 
            // TextBoxClosedColumn
            // 
            this.TextBoxClosedColumn.Enabled = false;
            this.TextBoxClosedColumn.Location = new System.Drawing.Point(485, 42);
            this.TextBoxClosedColumn.Name = "TextBoxClosedColumn";
            this.TextBoxClosedColumn.Size = new System.Drawing.Size(159, 20);
            this.TextBoxClosedColumn.TabIndex = 4;
            this.TextBoxClosedColumn.Text = "13";
            this.TextBoxClosedColumn.TextChanged += new System.EventHandler(this.TextBoxClosedColumn_TextChanged);
            // 
            // ButtonReload
            // 
            this.ButtonReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReload.Location = new System.Drawing.Point(6, 19);
            this.ButtonReload.Name = "ButtonReload";
            this.ButtonReload.Size = new System.Drawing.Size(192, 46);
            this.ButtonReload.TabIndex = 0;
            this.ButtonReload.Text = "Read Excel File ...";
            this.toolTip.SetToolTip(this.ButtonReload, "Please, reload the excel file, if the excel file has been\r\nupdated since the appl" +
        "ication has been started");
            this.ButtonReload.UseVisualStyleBackColor = true;
            this.ButtonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // TextBoxHeaderRow
            // 
            this.TextBoxHeaderRow.Enabled = false;
            this.TextBoxHeaderRow.Location = new System.Drawing.Point(78, 42);
            this.TextBoxHeaderRow.Name = "TextBoxHeaderRow";
            this.TextBoxHeaderRow.Size = new System.Drawing.Size(120, 20);
            this.TextBoxHeaderRow.TabIndex = 5;
            this.TextBoxHeaderRow.Text = "10";
            this.TextBoxHeaderRow.TextChanged += new System.EventHandler(this.TextBoxHeaderRow_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(77, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(101, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Header (default 10):";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(215, 26);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Rfi (default 2):";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(337, 26);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(96, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Subject (default 7):";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(484, 26);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(118, 13);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Closed Out (default 13):";
            // 
            // Label
            // 
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.ForeColor = System.Drawing.Color.Black;
            this.Label.Location = new System.Drawing.Point(6, 19);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(846, 33);
            this.Label.TabIndex = 8;
            this.Label.Text = "Please Select Option ...";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonUpdateSelectedParts
            // 
            this.ButtonUpdateSelectedParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUpdateSelectedParts.ForeColor = System.Drawing.Color.Black;
            this.ButtonUpdateSelectedParts.Location = new System.Drawing.Point(6, 21);
            this.ButtonUpdateSelectedParts.Name = "ButtonUpdateSelectedParts";
            this.ButtonUpdateSelectedParts.Size = new System.Drawing.Size(192, 46);
            this.ButtonUpdateSelectedParts.TabIndex = 0;
            this.ButtonUpdateSelectedParts.Text = "Update Selected Parts";
            this.toolTip.SetToolTip(this.ButtonUpdateSelectedParts, "Updates the selected parts in the model as per the loaded excel spreadsheet.\r\nDo " +
        "this if the excel file is changed since the RFI’s are assigned to the parts");
            this.ButtonUpdateSelectedParts.UseVisualStyleBackColor = true;
            this.ButtonUpdateSelectedParts.Click += new System.EventHandler(this.ButtonUpdateSelectedParts_Click);
            // 
            // ButtonRepresentationClosedOut
            // 
            this.ButtonRepresentationClosedOut.Location = new System.Drawing.Point(6, 73);
            this.ButtonRepresentationClosedOut.Name = "ButtonRepresentationClosedOut";
            this.ButtonRepresentationClosedOut.Size = new System.Drawing.Size(192, 46);
            this.ButtonRepresentationClosedOut.TabIndex = 0;
            this.ButtonRepresentationClosedOut.Text = "RFI Closed Out";
            this.toolTip.SetToolTip(this.ButtonRepresentationClosedOut, "Changes the representation in all visible view to “Color By RFI Closed Out”");
            this.ButtonRepresentationClosedOut.UseVisualStyleBackColor = true;
            this.ButtonRepresentationClosedOut.Click += new System.EventHandler(this.ButtonRepresentationClosedOut_Click);
            // 
            // ButtonRepresentationRfiNo
            // 
            this.ButtonRepresentationRfiNo.Location = new System.Drawing.Point(6, 19);
            this.ButtonRepresentationRfiNo.Name = "ButtonRepresentationRfiNo";
            this.ButtonRepresentationRfiNo.Size = new System.Drawing.Size(192, 46);
            this.ButtonRepresentationRfiNo.TabIndex = 0;
            this.ButtonRepresentationRfiNo.Text = "RFI No";
            this.toolTip.SetToolTip(this.ButtonRepresentationRfiNo, "Changes the representation in all visible view to “Color By RFI No”");
            this.ButtonRepresentationRfiNo.UseVisualStyleBackColor = true;
            this.ButtonRepresentationRfiNo.Click += new System.EventHandler(this.ButtonRepresentationRfiNo_Click);
            // 
            // ButtonRepresentationPhase
            // 
            this.ButtonRepresentationPhase.Location = new System.Drawing.Point(6, 127);
            this.ButtonRepresentationPhase.Name = "ButtonRepresentationPhase";
            this.ButtonRepresentationPhase.Size = new System.Drawing.Size(192, 46);
            this.ButtonRepresentationPhase.TabIndex = 0;
            this.ButtonRepresentationPhase.Text = "Phase";
            this.toolTip.SetToolTip(this.ButtonRepresentationPhase, "Changes the representation in all visible view to “Color By Phase”");
            this.ButtonRepresentationPhase.UseVisualStyleBackColor = true;
            this.ButtonRepresentationPhase.Click += new System.EventHandler(this.ButtonRepresentationPhase_Click);
            // 
            // ExcelFileLocationBox
            // 
            this.ExcelFileLocationBox.Controls.Add(this.OpenExcelFile);
            this.ExcelFileLocationBox.Controls.Add(this.GroupBox1);
            this.ExcelFileLocationBox.Controls.Add(this.TextBoxPath);
            this.ExcelFileLocationBox.Location = new System.Drawing.Point(12, 12);
            this.ExcelFileLocationBox.Name = "ExcelFileLocationBox";
            this.ExcelFileLocationBox.Size = new System.Drawing.Size(651, 77);
            this.ExcelFileLocationBox.TabIndex = 9;
            this.ExcelFileLocationBox.TabStop = false;
            this.ExcelFileLocationBox.Text = "Excel File Location:";
            this.toolTip.SetToolTip(this.ExcelFileLocationBox, "Current location of the excel file. The text can be directly edited");
            // 
            // OpenExcelFile
            // 
            this.OpenExcelFile.Location = new System.Drawing.Point(327, 19);
            this.OpenExcelFile.Name = "OpenExcelFile";
            this.OpenExcelFile.Size = new System.Drawing.Size(317, 46);
            this.OpenExcelFile.TabIndex = 10;
            this.OpenExcelFile.Text = "Open Excel File";
            this.OpenExcelFile.UseVisualStyleBackColor = true;
            this.OpenExcelFile.Click += new System.EventHandler(this.OpenExcelFile_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(624, 76);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(200, 100);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "groupBox1";
            // 
            // ExcelFileColumnAndRowsBox
            // 
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.checkBoxExcelNotDefault);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.Label1);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.TextBoxRFIColumn);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.TextBoxSubjectColumn);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.Label4);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.TextBoxClosedColumn);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.Label3);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.TextBoxHeaderRow);
            this.ExcelFileColumnAndRowsBox.Controls.Add(this.Label2);
            this.ExcelFileColumnAndRowsBox.Location = new System.Drawing.Point(12, 95);
            this.ExcelFileColumnAndRowsBox.Name = "ExcelFileColumnAndRowsBox";
            this.ExcelFileColumnAndRowsBox.Size = new System.Drawing.Size(651, 78);
            this.ExcelFileColumnAndRowsBox.TabIndex = 10;
            this.ExcelFileColumnAndRowsBox.TabStop = false;
            this.ExcelFileColumnAndRowsBox.Text = "Excel File Data:";
            this.toolTip.SetToolTip(this.ExcelFileColumnAndRowsBox, "Change columns and row positions if needed to read data from excel file");
            // 
            // checkBoxExcelNotDefault
            // 
            this.checkBoxExcelNotDefault.AutoSize = true;
            this.checkBoxExcelNotDefault.Location = new System.Drawing.Point(9, 43);
            this.checkBoxExcelNotDefault.Name = "checkBoxExcelNotDefault";
            this.checkBoxExcelNotDefault.Size = new System.Drawing.Size(66, 17);
            this.checkBoxExcelNotDefault.TabIndex = 8;
            this.checkBoxExcelNotDefault.Text = "Change:";
            this.checkBoxExcelNotDefault.UseVisualStyleBackColor = true;
            this.checkBoxExcelNotDefault.CheckedChanged += new System.EventHandler(this.CheckBoxExcelNotDefault_CheckedChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.ButtonUpdateSelectedParts);
            this.GroupBox2.Location = new System.Drawing.Point(669, 179);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(204, 82);
            this.GroupBox2.TabIndex = 11;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Sync Model Parts To Excel File:";
            // 
            // RepresentationBox
            // 
            this.RepresentationBox.Controls.Add(this.ButtonRepresentationRfiNo);
            this.RepresentationBox.Controls.Add(this.ButtonRepresentationClosedOut);
            this.RepresentationBox.Controls.Add(this.ButtonRepresentationPhase);
            this.RepresentationBox.Location = new System.Drawing.Point(669, 267);
            this.RepresentationBox.Name = "RepresentationBox";
            this.RepresentationBox.Size = new System.Drawing.Size(204, 180);
            this.RepresentationBox.TabIndex = 12;
            this.RepresentationBox.TabStop = false;
            this.RepresentationBox.Text = "Color Representations:";
            // 
            // ExcelPreviewBox
            // 
            this.ExcelPreviewBox.Controls.Add(this.buttonRemoveValue);
            this.ExcelPreviewBox.Controls.Add(this.buttonAssignValue);
            this.ExcelPreviewBox.Controls.Add(this.DataGridView);
            this.ExcelPreviewBox.Location = new System.Drawing.Point(12, 179);
            this.ExcelPreviewBox.Name = "ExcelPreviewBox";
            this.ExcelPreviewBox.Size = new System.Drawing.Size(651, 268);
            this.ExcelPreviewBox.TabIndex = 13;
            this.ExcelPreviewBox.TabStop = false;
            this.ExcelPreviewBox.Text = "Excel File Data Preview:";
            // 
            // buttonRemoveValue
            // 
            this.buttonRemoveValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveValue.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonRemoveValue.Location = new System.Drawing.Point(327, 215);
            this.buttonRemoveValue.Name = "buttonRemoveValue";
            this.buttonRemoveValue.Size = new System.Drawing.Size(318, 46);
            this.buttonRemoveValue.TabIndex = 5;
            this.buttonRemoveValue.Text = "Remove Selected RFI From Selected Parts";
            this.toolTip.SetToolTip(this.buttonRemoveValue, "Removes RFI’s from the parts as per the\r\nselected rows from the table above");
            this.buttonRemoveValue.UseVisualStyleBackColor = true;
            this.buttonRemoveValue.Click += new System.EventHandler(this.ButtonRemoveValue_Click);
            // 
            // buttonAssignValue
            // 
            this.buttonAssignValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAssignValue.Location = new System.Drawing.Point(6, 215);
            this.buttonAssignValue.Name = "buttonAssignValue";
            this.buttonAssignValue.Size = new System.Drawing.Size(318, 46);
            this.buttonAssignValue.TabIndex = 4;
            this.buttonAssignValue.Text = "Assign Selected RFI To Selected Parts";
            this.toolTip.SetToolTip(this.buttonAssignValue, "Assigns RFI’s to the selected parts as per the\r\nselected rows from the table abov" +
        "e");
            this.buttonAssignValue.UseVisualStyleBackColor = true;
            this.buttonAssignValue.Click += new System.EventHandler(this.ButtonAssignValue_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.labelVersion);
            this.StatusBox.Controls.Add(this.Label);
            this.StatusBox.Location = new System.Drawing.Point(12, 453);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(861, 63);
            this.StatusBox.TabIndex = 14;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Application Current Status:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(818, 39);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(37, 13);
            this.labelVersion.TabIndex = 9;
            this.labelVersion.Text = "v 2.69";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.ButtonReload);
            this.GroupBox3.Location = new System.Drawing.Point(669, 96);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(204, 78);
            this.GroupBox3.TabIndex = 15;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Load / Reload Excel File:";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.ButtonLoadFile);
            this.GroupBox4.Location = new System.Drawing.Point(669, 12);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(204, 78);
            this.GroupBox4.TabIndex = 16;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Initial Setup:";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 32000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Tooltip:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(885, 523);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ExcelPreviewBox);
            this.Controls.Add(this.RepresentationBox);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.ExcelFileColumnAndRowsBox);
            this.Controls.Add(this.ExcelFileLocationBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFI Modelling Application";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ExcelFileLocationBox.ResumeLayout(false);
            this.ExcelFileLocationBox.PerformLayout();
            this.ExcelFileColumnAndRowsBox.ResumeLayout(false);
            this.ExcelFileColumnAndRowsBox.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.RepresentationBox.ResumeLayout(false);
            this.ExcelPreviewBox.ResumeLayout(false);
            this.StatusBox.ResumeLayout(false);
            this.StatusBox.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLoadFile;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.TextBox TextBoxRFIColumn;
        private System.Windows.Forms.TextBox TextBoxSubjectColumn;
        private System.Windows.Forms.TextBox TextBoxClosedColumn;
        private System.Windows.Forms.Button ButtonReload;
        private System.Windows.Forms.TextBox TextBoxHeaderRow;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button ButtonUpdateSelectedParts;
        private System.Windows.Forms.Button ButtonRepresentationClosedOut;
        private System.Windows.Forms.Button ButtonRepresentationRfiNo;
        private System.Windows.Forms.Button ButtonRepresentationPhase;
        private System.Windows.Forms.GroupBox ExcelFileLocationBox;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox ExcelFileColumnAndRowsBox;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.GroupBox RepresentationBox;
        private System.Windows.Forms.GroupBox ExcelPreviewBox;
        private System.Windows.Forms.GroupBox StatusBox;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.Button buttonAssignValue;
        private System.Windows.Forms.Button buttonRemoveValue;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.CheckBox checkBoxExcelNotDefault;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button OpenExcelFile;
    }
}

