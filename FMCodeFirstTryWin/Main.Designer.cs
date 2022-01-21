namespace FMCodeFirstTryWin
{
    partial class frmMain
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
            this.listDrivers = new System.Windows.Forms.DataGridView();
            this.lblDriverList = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // listDrivers
            // 
            this.listDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDrivers.Location = new System.Drawing.Point(4, 48);
            this.listDrivers.Name = "listDrivers";
            this.listDrivers.Size = new System.Drawing.Size(762, 404);
            this.listDrivers.TabIndex = 0;
            // 
            // lblDriverList
            // 
            this.lblDriverList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDriverList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDriverList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverList.Location = new System.Drawing.Point(0, 0);
            this.lblDriverList.Name = "lblDriverList";
            this.lblDriverList.Size = new System.Drawing.Size(770, 45);
            this.lblDriverList.TabIndex = 1;
            this.lblDriverList.Text = "List of registered drivers:";
            this.lblDriverList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(4, 458);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(197, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New Driver";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 504);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDriverList);
            this.Controls.Add(this.listDrivers);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "FM Code Exe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listDrivers;
        private System.Windows.Forms.Label lblDriverList;
        private System.Windows.Forms.Button btnAdd;
    }
}

