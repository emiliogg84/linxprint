namespace LinxPrint
{
    partial class PrintProgressForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintPause = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbCurrentCode = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalCodes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(30, 134);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgress.Location = new System.Drawing.Point(26, 111);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(357, 20);
            this.lbProgress.TabIndex = 1;
            this.lbProgress.Text = "Imprimiendo pincode 1 de 100, por favor espere...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pincode actual:";
            // 
            // btnPrintPause
            // 
            this.btnPrintPause.Location = new System.Drawing.Point(241, 198);
            this.btnPrintPause.Name = "btnPrintPause";
            this.btnPrintPause.Size = new System.Drawing.Size(85, 25);
            this.btnPrintPause.TabIndex = 1;
            this.btnPrintPause.Text = "Pausar";
            this.btnPrintPause.UseVisualStyleBackColor = true;
            this.btnPrintPause.Click += new System.EventHandler(this.btnPrintPause_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(332, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbCurrentCode
            // 
            this.lbCurrentCode.AutoSize = true;
            this.lbCurrentCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCurrentCode.Location = new System.Drawing.Point(128, 160);
            this.lbCurrentCode.Name = "lbCurrentCode";
            this.lbCurrentCode.Size = new System.Drawing.Size(46, 17);
            this.lbCurrentCode.TabIndex = 5;
            this.lbCurrentCode.Text = "label3";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(30, 60);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pincodes listos para impirmir:";
            // 
            // lbTotalCodes
            // 
            this.lbTotalCodes.AutoSize = true;
            this.lbTotalCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCodes.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbTotalCodes.Location = new System.Drawing.Point(276, 21);
            this.lbTotalCodes.Name = "lbTotalCodes";
            this.lbTotalCodes.Size = new System.Drawing.Size(20, 24);
            this.lbTotalCodes.TabIndex = 8;
            this.lbTotalCodes.Text = "0";
            // 
            // PrintProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(449, 239);
            this.Controls.Add(this.lbTotalCodes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lbCurrentCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrintPause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Imprimir...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintProgressForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbCurrentCode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalCodes;
    }
}