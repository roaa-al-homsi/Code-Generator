namespace CodeGenerator
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvColumns = new Guna.UI2.WinForms.Guna2DataGridView();
            this.labCountColumns = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnViewDataAccessLayer = new Guna.UI2.WinForms.Guna2Button();
            this.richTxtContantLayers = new System.Windows.Forms.RichTextBox();
            this.btnViewGenericMethods = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewBuisnessLayer = new Guna.UI2.WinForms.Guna2Button();
            this.txtNameClass = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCopy = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDatabase
            // 
            this.cbDatabase.AutoRoundedCorners = true;
            this.cbDatabase.BackColor = System.Drawing.Color.Transparent;
            this.cbDatabase.BorderRadius = 17;
            this.cbDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDatabase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDatabase.Font = new System.Drawing.Font("Andalus", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDatabase.ForeColor = System.Drawing.Color.Black;
            this.cbDatabase.ItemHeight = 30;
            this.cbDatabase.Location = new System.Drawing.Point(12, 25);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(229, 36);
            this.cbDatabase.TabIndex = 0;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // cbTables
            // 
            this.cbTables.AutoRoundedCorners = true;
            this.cbTables.BackColor = System.Drawing.Color.Transparent;
            this.cbTables.BorderRadius = 17;
            this.cbTables.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTables.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTables.Font = new System.Drawing.Font("Andalus", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTables.ForeColor = System.Drawing.Color.Black;
            this.cbTables.ItemHeight = 30;
            this.cbTables.Location = new System.Drawing.Point(278, 25);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(229, 36);
            this.cbTables.TabIndex = 1;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // dgvColumns
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumns.ColumnHeadersHeight = 4;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumns.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColumns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvColumns.Location = new System.Drawing.Point(1, 144);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.RowHeadersWidth = 51;
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(659, 401);
            this.dgvColumns.TabIndex = 2;
            this.dgvColumns.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvColumns.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvColumns.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvColumns.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvColumns.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvColumns.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvColumns.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvColumns.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvColumns.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvColumns.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvColumns.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvColumns.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvColumns.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvColumns.ThemeStyle.ReadOnly = false;
            this.dgvColumns.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvColumns.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvColumns.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvColumns.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvColumns.ThemeStyle.RowsStyle.Height = 24;
            this.dgvColumns.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvColumns.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // labCountColumns
            // 
            this.labCountColumns.AutoSize = false;
            this.labCountColumns.BackColor = System.Drawing.Color.Transparent;
            this.labCountColumns.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountColumns.Location = new System.Drawing.Point(256, 91);
            this.labCountColumns.Name = "labCountColumns";
            this.labCountColumns.Size = new System.Drawing.Size(154, 35);
            this.labCountColumns.TabIndex = 3;
            this.labCountColumns.Text = "guna2HtmlLabel1";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(75, 91);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(166, 35);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Number Of Columns:";
            // 
            // btnViewDataAccessLayer
            // 
            this.btnViewDataAccessLayer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDataAccessLayer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDataAccessLayer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewDataAccessLayer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewDataAccessLayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewDataAccessLayer.ForeColor = System.Drawing.Color.White;
            this.btnViewDataAccessLayer.Location = new System.Drawing.Point(201, 560);
            this.btnViewDataAccessLayer.Name = "btnViewDataAccessLayer";
            this.btnViewDataAccessLayer.Size = new System.Drawing.Size(180, 45);
            this.btnViewDataAccessLayer.TabIndex = 6;
            this.btnViewDataAccessLayer.Text = "View Data Access Layer";
            this.btnViewDataAccessLayer.Click += new System.EventHandler(this.btnViewDataAccessLayer_Click);
            // 
            // richTxtContantLayers
            // 
            this.richTxtContantLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxtContantLayers.Location = new System.Drawing.Point(690, 12);
            this.richTxtContantLayers.Name = "richTxtContantLayers";
            this.richTxtContantLayers.ReadOnly = true;
            this.richTxtContantLayers.Size = new System.Drawing.Size(668, 702);
            this.richTxtContantLayers.TabIndex = 7;
            this.richTxtContantLayers.Text = "";
            // 
            // btnViewGenericMethods
            // 
            this.btnViewGenericMethods.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewGenericMethods.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewGenericMethods.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewGenericMethods.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewGenericMethods.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewGenericMethods.ForeColor = System.Drawing.Color.White;
            this.btnViewGenericMethods.Location = new System.Drawing.Point(1, 560);
            this.btnViewGenericMethods.Name = "btnViewGenericMethods";
            this.btnViewGenericMethods.Size = new System.Drawing.Size(180, 45);
            this.btnViewGenericMethods.TabIndex = 8;
            this.btnViewGenericMethods.Text = "View Generic Methods";
            this.btnViewGenericMethods.Click += new System.EventHandler(this.btnViewGenericMethods_Click);
            // 
            // btnViewBuisnessLayer
            // 
            this.btnViewBuisnessLayer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewBuisnessLayer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewBuisnessLayer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewBuisnessLayer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewBuisnessLayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewBuisnessLayer.ForeColor = System.Drawing.Color.White;
            this.btnViewBuisnessLayer.Location = new System.Drawing.Point(405, 560);
            this.btnViewBuisnessLayer.Name = "btnViewBuisnessLayer";
            this.btnViewBuisnessLayer.Size = new System.Drawing.Size(180, 45);
            this.btnViewBuisnessLayer.TabIndex = 9;
            this.btnViewBuisnessLayer.Text = "View Business Layer";
            this.btnViewBuisnessLayer.Click += new System.EventHandler(this.btnViewBuisnessLayer_Click);
            // 
            // txtNameClass
            // 
            this.txtNameClass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameClass.DefaultText = "";
            this.txtNameClass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameClass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNameClass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameClass.Location = new System.Drawing.Point(278, 639);
            this.txtNameClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameClass.Name = "txtNameClass";
            this.txtNameClass.PasswordChar = '\0';
            this.txtNameClass.PlaceholderText = "";
            this.txtNameClass.SelectedText = "";
            this.txtNameClass.Size = new System.Drawing.Size(180, 32);
            this.txtNameClass.TabIndex = 10;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(132, 636);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(138, 35);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "Enter name class :";
            // 
            // btnCopy
            // 
            this.btnCopy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCopy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCopy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCopy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(278, 688);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(180, 45);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 726);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.txtNameClass);
            this.Controls.Add(this.btnViewBuisnessLayer);
            this.Controls.Add(this.btnViewGenericMethods);
            this.Controls.Add(this.richTxtContantLayers);
            this.Controls.Add(this.btnViewDataAccessLayer);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.labCountColumns);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.cbDatabase);
            this.Name = "Form1";
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbDatabase;
        private Guna.UI2.WinForms.Guna2ComboBox cbTables;
        private Guna.UI2.WinForms.Guna2DataGridView dgvColumns;
        private Guna.UI2.WinForms.Guna2HtmlLabel labCountColumns;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnViewDataAccessLayer;
        private System.Windows.Forms.RichTextBox richTxtContantLayers;
        private Guna.UI2.WinForms.Guna2Button btnViewGenericMethods;
        private Guna.UI2.WinForms.Guna2Button btnViewBuisnessLayer;
        private Guna.UI2.WinForms.Guna2TextBox txtNameClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnCopy;
    }
}

