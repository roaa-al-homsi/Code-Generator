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
            this.cbDatabase.Location = new System.Drawing.Point(105, 129);
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
            this.cbTables.Location = new System.Drawing.Point(105, 230);
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
            this.dgvColumns.Location = new System.Drawing.Point(399, 119);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.RowHeadersWidth = 51;
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(894, 385);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 647);
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
    }
}

