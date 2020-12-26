namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.buttonGenerujObraz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRozliseniX = new System.Windows.Forms.TextBox();
            this.textBoxRozliseniY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabelLong = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semínko:";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(75, 10);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(218, 23);
            this.textBoxSeed.TabIndex = 1;
            // 
            // buttonGenerujObraz
            // 
            this.buttonGenerujObraz.Location = new System.Drawing.Point(365, 299);
            this.buttonGenerujObraz.Name = "buttonGenerujObraz";
            this.buttonGenerujObraz.Size = new System.Drawing.Size(107, 42);
            this.buttonGenerujObraz.TabIndex = 2;
            this.buttonGenerujObraz.Text = "Vygeneruj obraz";
            this.buttonGenerujObraz.UseVisualStyleBackColor = true;
            this.buttonGenerujObraz.Click += new System.EventHandler(this.buttonGenerujObraz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // statusBox
            // 
            this.statusBox.AutoSize = true;
            this.statusBox.Location = new System.Drawing.Point(365, 13);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(57, 15);
            this.statusBox.TabIndex = 4;
            this.statusBox.Text = "Připraven";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rozlišení:";
            // 
            // textBoxRozliseniX
            // 
            this.textBoxRozliseniX.Location = new System.Drawing.Point(75, 39);
            this.textBoxRozliseniX.Name = "textBoxRozliseniX";
            this.textBoxRozliseniX.PlaceholderText = "1920";
            this.textBoxRozliseniX.Size = new System.Drawing.Size(92, 23);
            this.textBoxRozliseniX.TabIndex = 6;
            this.textBoxRozliseniX.Text = "1920";
            // 
            // textBoxRozliseniY
            // 
            this.textBoxRozliseniY.Location = new System.Drawing.Point(193, 39);
            this.textBoxRozliseniY.Name = "textBoxRozliseniY";
            this.textBoxRozliseniY.PlaceholderText = "1080";
            this.textBoxRozliseniY.Size = new System.Drawing.Size(100, 23);
            this.textBoxRozliseniY.TabIndex = 7;
            this.textBoxRozliseniY.Text = "1080";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "X";
            // 
            // statusLabelLong
            // 
            this.statusLabelLong.AutoSize = true;
            this.statusLabelLong.Location = new System.Drawing.Point(317, 42);
            this.statusLabelLong.Name = "statusLabelLong";
            this.statusLabelLong.Size = new System.Drawing.Size(0, 15);
            this.statusLabelLong.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Škálování:";
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(75, 68);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(92, 23);
            this.textBoxScale.TabIndex = 11;
            this.textBoxScale.Text = "4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "-násobná velikost";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 353);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxScale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusLabelLong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRozliseniY);
            this.Controls.Add(this.textBoxRozliseniX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGenerujObraz);
            this.Controls.Add(this.textBoxSeed);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Button buttonGenerujObraz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label statusBox;
        public System.Windows.Forms.TextBox textBoxRozliseniX;
        public System.Windows.Forms.TextBox textBoxRozliseniY;
        private System.Windows.Forms.Label statusLabelLong;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.Label label6;
    }
}

