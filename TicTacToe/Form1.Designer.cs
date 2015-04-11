namespace TicTacToe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.f0 = new System.Windows.Forms.Button();
            this.f1 = new System.Windows.Forms.Button();
            this.f2 = new System.Windows.Forms.Button();
            this.f5 = new System.Windows.Forms.Button();
            this.f4 = new System.Windows.Forms.Button();
            this.f3 = new System.Windows.Forms.Button();
            this.f8 = new System.Windows.Forms.Button();
            this.f7 = new System.Windows.Forms.Button();
            this.f6 = new System.Windows.Forms.Button();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.PlayingField = new System.Windows.Forms.FlowLayoutPanel();
            this.player1Score = new System.Windows.Forms.TextBox();
            this.player2Score = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drawScore = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlayingField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // f0
            // 
            this.f0.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f0.ForeColor = System.Drawing.Color.Black;
            this.f0.Location = new System.Drawing.Point(3, 3);
            this.f0.Name = "f0";
            this.f0.Size = new System.Drawing.Size(136, 119);
            this.f0.TabIndex = 0;
            this.f0.UseVisualStyleBackColor = true;
            this.f0.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f1
            // 
            this.f1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f1.ForeColor = System.Drawing.Color.Black;
            this.f1.Location = new System.Drawing.Point(145, 3);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(136, 119);
            this.f1.TabIndex = 1;
            this.f1.UseVisualStyleBackColor = true;
            this.f1.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f2
            // 
            this.f2.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f2.ForeColor = System.Drawing.Color.Black;
            this.f2.Location = new System.Drawing.Point(287, 3);
            this.f2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(136, 119);
            this.f2.TabIndex = 2;
            this.f2.UseVisualStyleBackColor = true;
            this.f2.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f5
            // 
            this.f5.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f5.ForeColor = System.Drawing.Color.Black;
            this.f5.Location = new System.Drawing.Point(287, 128);
            this.f5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f5.Name = "f5";
            this.f5.Size = new System.Drawing.Size(136, 119);
            this.f5.TabIndex = 5;
            this.f5.UseVisualStyleBackColor = true;
            this.f5.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f4
            // 
            this.f4.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f4.ForeColor = System.Drawing.Color.Black;
            this.f4.Location = new System.Drawing.Point(145, 128);
            this.f4.Name = "f4";
            this.f4.Size = new System.Drawing.Size(136, 119);
            this.f4.TabIndex = 4;
            this.f4.UseVisualStyleBackColor = true;
            this.f4.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f3
            // 
            this.f3.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f3.ForeColor = System.Drawing.Color.Black;
            this.f3.Location = new System.Drawing.Point(3, 128);
            this.f3.Name = "f3";
            this.f3.Size = new System.Drawing.Size(136, 119);
            this.f3.TabIndex = 3;
            this.f3.UseVisualStyleBackColor = true;
            this.f3.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f8
            // 
            this.f8.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f8.ForeColor = System.Drawing.Color.Black;
            this.f8.Location = new System.Drawing.Point(287, 253);
            this.f8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f8.Name = "f8";
            this.f8.Size = new System.Drawing.Size(136, 119);
            this.f8.TabIndex = 8;
            this.f8.UseVisualStyleBackColor = true;
            this.f8.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f7
            // 
            this.f7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f7.ForeColor = System.Drawing.Color.Black;
            this.f7.Location = new System.Drawing.Point(145, 253);
            this.f7.Name = "f7";
            this.f7.Size = new System.Drawing.Size(136, 119);
            this.f7.TabIndex = 7;
            this.f7.UseVisualStyleBackColor = true;
            this.f7.Click += new System.EventHandler(this.FieldClicked);
            // 
            // f6
            // 
            this.f6.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.f6.ForeColor = System.Drawing.Color.Black;
            this.f6.Location = new System.Drawing.Point(3, 253);
            this.f6.Name = "f6";
            this.f6.Size = new System.Drawing.Size(136, 119);
            this.f6.TabIndex = 6;
            this.f6.UseVisualStyleBackColor = true;
            this.f6.Click += new System.EventHandler(this.FieldClicked);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.player1Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1Label.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(441, 152);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(111, 38);
            this.player1Label.TabIndex = 9;
            this.player1Label.Text = "Player 1";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.player2Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2Label.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.Location = new System.Drawing.Point(556, 152);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(111, 38);
            this.player2Label.TabIndex = 10;
            this.player2Label.Text = "Player 2";
            // 
            // PlayingField
            // 
            this.PlayingField.BackColor = System.Drawing.Color.Transparent;
            this.PlayingField.Controls.Add(this.f0);
            this.PlayingField.Controls.Add(this.f1);
            this.PlayingField.Controls.Add(this.f2);
            this.PlayingField.Controls.Add(this.f3);
            this.PlayingField.Controls.Add(this.f4);
            this.PlayingField.Controls.Add(this.f5);
            this.PlayingField.Controls.Add(this.f6);
            this.PlayingField.Controls.Add(this.f7);
            this.PlayingField.Controls.Add(this.f8);
            this.PlayingField.Location = new System.Drawing.Point(11, 7);
            this.PlayingField.Name = "PlayingField";
            this.PlayingField.Size = new System.Drawing.Size(426, 372);
            this.PlayingField.TabIndex = 11;
            // 
            // player1Score
            // 
            this.player1Score.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.player1Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1Score.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Score.Location = new System.Drawing.Point(441, 191);
            this.player1Score.Name = "player1Score";
            this.player1Score.ReadOnly = true;
            this.player1Score.ShortcutsEnabled = false;
            this.player1Score.Size = new System.Drawing.Size(111, 43);
            this.player1Score.TabIndex = 12;
            this.player1Score.TabStop = false;
            this.player1Score.Text = "0";
            this.player1Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // player2Score
            // 
            this.player2Score.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.player2Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2Score.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Score.Location = new System.Drawing.Point(556, 191);
            this.player2Score.Name = "player2Score";
            this.player2Score.ReadOnly = true;
            this.player2Score.ShortcutsEnabled = false;
            this.player2Score.Size = new System.Drawing.Size(111, 43);
            this.player2Score.TabIndex = 13;
            this.player2Score.TabStop = false;
            this.player2Score.Text = "0";
            this.player2Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(475, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 38);
            this.label1.TabIndex = 14;
            this.label1.Text = "     Draws     ";
            // 
            // drawScore
            // 
            this.drawScore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drawScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawScore.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawScore.Location = new System.Drawing.Point(500, 290);
            this.drawScore.Name = "drawScore";
            this.drawScore.ReadOnly = true;
            this.drawScore.ShortcutsEnabled = false;
            this.drawScore.Size = new System.Drawing.Size(111, 43);
            this.drawScore.TabIndex = 15;
            this.drawScore.TabStop = false;
            this.drawScore.Text = "0";
            this.drawScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TicTacToe.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(440, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(673, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.drawScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.PlayingField);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tic Tac Boom";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PlayingField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f0;
        private System.Windows.Forms.Button f1;
        private System.Windows.Forms.Button f2;
        private System.Windows.Forms.Button f5;
        private System.Windows.Forms.Button f4;
        private System.Windows.Forms.Button f3;
        private System.Windows.Forms.Button f8;
        private System.Windows.Forms.Button f7;
        private System.Windows.Forms.Button f6;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.FlowLayoutPanel PlayingField;
        private System.Windows.Forms.TextBox player1Score;
        private System.Windows.Forms.TextBox player2Score;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox drawScore;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

