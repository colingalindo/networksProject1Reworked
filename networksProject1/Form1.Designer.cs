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
            this.components = new System.ComponentModel.Container();
            this.runSim = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.eventTypeBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.sNodeBox = new System.Windows.Forms.TextBox();
            this.dNodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.addEventButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runSim
            // 
            this.runSim.Location = new System.Drawing.Point(197, 227);
            this.runSim.Name = "runSim";
            this.runSim.Size = new System.Drawing.Size(75, 23);
            this.runSim.TabIndex = 6;
            this.runSim.Text = "Run";
            this.runSim.UseVisualStyleBackColor = true;
            this.runSim.Click += new System.EventHandler(this.runSim_Click);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(131, 115);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(100, 20);
            this.fileName.TabIndex = 4;
            this.fileName.Text = "topology2.txt";
            // 
            // eventTypeBox
            // 
            this.eventTypeBox.Location = new System.Drawing.Point(131, 11);
            this.eventTypeBox.Name = "eventTypeBox";
            this.eventTypeBox.Size = new System.Drawing.Size(100, 20);
            this.eventTypeBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.eventTypeBox, "3 = Link Down\r\n4 = Data Packet");
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(131, 37);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(100, 20);
            this.timeBox.TabIndex = 1;
            // 
            // sNodeBox
            // 
            this.sNodeBox.Location = new System.Drawing.Point(131, 63);
            this.sNodeBox.Name = "sNodeBox";
            this.sNodeBox.Size = new System.Drawing.Size(100, 20);
            this.sNodeBox.TabIndex = 2;
            // 
            // dNodeBox
            // 
            this.dNodeBox.Location = new System.Drawing.Point(131, 89);
            this.dNodeBox.Name = "dNodeBox";
            this.dNodeBox.Size = new System.Drawing.Size(100, 20);
            this.dNodeBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Event Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Source Node:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dest Node:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "File:";
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(13, 227);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(103, 161);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(75, 23);
            this.addEventButton.TabIndex = 5;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.runSim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dNodeBox);
            this.Controls.Add(this.sNodeBox);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.eventTypeBox);
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
        private System.Windows.Forms.TextBox eventTypeBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.TextBox sNodeBox;
        private System.Windows.Forms.TextBox dNodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addEventButton;
    }
}

