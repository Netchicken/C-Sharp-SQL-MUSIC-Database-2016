namespace C_Sharp_SQL_Movies_Database_2016 {
    partial class FrmIMVDB {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbxIMVDB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxIMVDB
            // 
            this.lbxIMVDB.FormattingEnabled = true;
            this.lbxIMVDB.ItemHeight = 16;
            this.lbxIMVDB.Location = new System.Drawing.Point(29, 22);
            this.lbxIMVDB.Name = "lbxIMVDB";
            this.lbxIMVDB.Size = new System.Drawing.Size(572, 404);
            this.lbxIMVDB.TabIndex = 0;
            // 
            // FrmIMVDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 485);
            this.Controls.Add(this.lbxIMVDB);
            this.Name = "FrmIMVDB";
            this.Text = "FrmIMVDB";
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.ListBox lbxIMVDB;
        }
    }