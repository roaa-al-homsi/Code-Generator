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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbTables = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvColumns = new Guna.UI2.WinForms.Guna2DataGridView();
            this.labCountColumns = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnViewDataAccessLayer = new Guna.UI2.WinForms.Guna2Button();
            this.richTxtContantLayers = new System.Windows.Forms.RichTextBox();
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
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvColumns.ColumnHeadersHeight = 4;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumns.DefaultCellStyle = dataGridViewCellStyle15;
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
            this.btnViewDataAccessLayer.Location = new System.Drawing.Point(307, 599);
            this.btnViewDataAccessLayer.Name = "btnViewDataAccessLayer";
            this.btnViewDataAccessLayer.Size = new System.Drawing.Size(180, 45);
            this.btnViewDataAccessLayer.TabIndex = 6;
            this.btnViewDataAccessLayer.Text = "guna2Button1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 726);
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
    }
}

