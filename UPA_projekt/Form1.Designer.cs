namespace UPA_projekt
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
            this.label2 = new System.Windows.Forms.Label();
            this.RozliseniX = new System.Windows.Forms.TextBox();
            this.RozliseniY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Skalovani = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OkrajVlevo = new System.Windows.Forms.ColorDialog();
            this.OkrajNahore = new System.Windows.Forms.ColorDialog();
            this.OkrajNalevoButton = new System.Windows.Forms.Button();
            this.OkrajNahoreButton = new System.Windows.Forms.Button();
            this.sjednotitOkraje = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NevyplnenePixelyButton = new System.Windows.Forms.Button();
            this.NevyplnenePixely = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Instrukce = new System.Windows.Forms.TextBox();
            this.GenerujObraz = new System.Windows.Forms.Button();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rozlišení";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            // 
            // RozliseniX
            // 
            this.RozliseniX.Location = new System.Drawing.Point(71, 6);
            this.RozliseniX.Name = "RozliseniX";
            this.RozliseniX.Size = new System.Drawing.Size(50, 23);
            this.RozliseniX.TabIndex = 2;
            this.RozliseniX.Text = "255";
            // 
            // RozliseniY
            // 
            this.RozliseniY.Location = new System.Drawing.Point(140, 6);
            this.RozliseniY.Name = "RozliseniY";
            this.RozliseniY.Size = new System.Drawing.Size(50, 23);
            this.RozliseniY.TabIndex = 3;
            this.RozliseniY.Text = "255";
            this.RozliseniY.TextChanged += new System.EventHandler(this.RozliseniY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Škálování";
            // 
            // Skalovani
            // 
            this.Skalovani.Location = new System.Drawing.Point(71, 34);
            this.Skalovani.Name = "Skalovani";
            this.Skalovani.Size = new System.Drawing.Size(30, 23);
            this.Skalovani.TabIndex = 5;
            this.Skalovani.Text = "4";
            this.Skalovani.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Okraj nalevo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Okraj nahoře";
            // 
            // OkrajVlevo
            // 
            this.OkrajVlevo.Color = System.Drawing.Color.Red;
            // 
            // OkrajNahore
            // 
            this.OkrajNahore.Color = System.Drawing.Color.Red;
            // 
            // OkrajNalevoButton
            // 
            this.OkrajNalevoButton.Location = new System.Drawing.Point(96, 63);
            this.OkrajNalevoButton.Name = "OkrajNalevoButton";
            this.OkrajNalevoButton.Size = new System.Drawing.Size(94, 23);
            this.OkrajNalevoButton.TabIndex = 10;
            this.OkrajNalevoButton.Text = "Vybrat barvu";
            this.OkrajNalevoButton.UseVisualStyleBackColor = true;
            this.OkrajNalevoButton.Click += new System.EventHandler(this.OkrajNalevoButton_Click);
            // 
            // OkrajNahoreButton
            // 
            this.OkrajNahoreButton.Location = new System.Drawing.Point(96, 92);
            this.OkrajNahoreButton.Name = "OkrajNahoreButton";
            this.OkrajNahoreButton.Size = new System.Drawing.Size(94, 23);
            this.OkrajNahoreButton.TabIndex = 11;
            this.OkrajNahoreButton.Text = "Vybrat barvu";
            this.OkrajNahoreButton.UseVisualStyleBackColor = true;
            this.OkrajNahoreButton.Click += new System.EventHandler(this.OkrajNahoreButton_Click);
            // 
            // sjednotitOkraje
            // 
            this.sjednotitOkraje.AutoSize = true;
            this.sjednotitOkraje.Location = new System.Drawing.Point(196, 95);
            this.sjednotitOkraje.Name = "sjednotitOkraje";
            this.sjednotitOkraje.Size = new System.Drawing.Size(121, 19);
            this.sjednotitOkraje.TabIndex = 12;
            this.sjednotitOkraje.Text = "Stejný jako nalevo";
            this.sjednotitOkraje.UseVisualStyleBackColor = true;
            this.sjednotitOkraje.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nevyplněné pixely počítat jako";
            // 
            // NevyplnenePixelyButton
            // 
            this.NevyplnenePixelyButton.Location = new System.Drawing.Point(196, 120);
            this.NevyplnenePixelyButton.Name = "NevyplnenePixelyButton";
            this.NevyplnenePixelyButton.Size = new System.Drawing.Size(94, 23);
            this.NevyplnenePixelyButton.TabIndex = 14;
            this.NevyplnenePixelyButton.Text = "Vybrat barvu";
            this.NevyplnenePixelyButton.UseVisualStyleBackColor = true;
            this.NevyplnenePixelyButton.Click += new System.EventHandler(this.NevyplnenePixelyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Instrukce);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 161);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrukce";
            // 
            // Instrukce
            // 
            this.Instrukce.Location = new System.Drawing.Point(6, 22);
            this.Instrukce.Multiline = true;
            this.Instrukce.Name = "Instrukce";
            this.Instrukce.Size = new System.Drawing.Size(293, 133);
            this.Instrukce.TabIndex = 1;
            // 
            // GenerujObraz
            // 
            this.GenerujObraz.Location = new System.Drawing.Point(196, 312);
            this.GenerujObraz.Name = "GenerujObraz";
            this.GenerujObraz.Size = new System.Drawing.Size(121, 23);
            this.GenerujObraz.TabIndex = 16;
            this.GenerujObraz.Text = "Generuj obraz";
            this.GenerujObraz.UseVisualStyleBackColor = true;
            this.GenerujObraz.Click += new System.EventHandler(this.GenerujObraz_Click);
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(12, 315);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(42, 15);
            this.FileNameLabel.TabIndex = 17;
            this.FileNameLabel.Text = "Název:";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(60, 312);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(130, 23);
            this.FileName.TabIndex = 18;
            this.FileName.Text = "obraz.bmp";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusLabel.Location = new System.Drawing.Point(268, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusLabel.Size = new System.Drawing.Size(57, 15);
            this.StatusLabel.TabIndex = 19;
            this.StatusLabel.Text = "Připraven";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 342);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.GenerujObraz);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NevyplnenePixelyButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sjednotitOkraje);
            this.Controls.Add(this.OkrajNahoreButton);
            this.Controls.Add(this.OkrajNalevoButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Skalovani);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RozliseniY);
            this.Controls.Add(this.RozliseniX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Vybrat barvu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RozliseniX;
        private System.Windows.Forms.TextBox RozliseniY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Skalovani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog OkrajVlevo;
        private System.Windows.Forms.ColorDialog OkrajNahore;
        private System.Windows.Forms.Button OkrajNalevoButton;
        private System.Windows.Forms.Button OkrajNahoreButton;
        private System.Windows.Forms.CheckBox sjednotitOkraje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button NevyplnenePixelyButton;
        private System.Windows.Forms.ColorDialog NevyplnenePixely;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GenerujObraz;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.TextBox Instrukce;
        private System.Windows.Forms.Label StatusLabel;
    }
}

