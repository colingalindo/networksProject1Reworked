namespace networksProject1
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
            this.runSim = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // runSim
            // 
            this.runSim.Location = new System.Drawing.Point(83, 62);
            this.runSim.Name = "runSim";
            this.runSim.Size = new System.Drawing.Size(75, 23);
            this.runSim.TabIndex = 1;
            this.runSim.Text = "Run";
            this.runSim.UseVisualStyleBackColor = true;
            this.runSim.Click += new System.EventHandler(this.runSim_Click);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(73, 36);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(100, 20);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "topology2.txt";
            // 
            // Form1
            // 
            this.AcceptButton = this.runSim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.runSim);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runSim;
        private System.Windows.Forms.TextBox fileName;
    }
}

