namespace Shooter2D
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
            this.NomeLabel = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortaLabel = new System.Windows.Forms.Label();
            this.NomeTextBox = new System.Windows.Forms.TextBox();
            this.PortaTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ConectarButton = new System.Windows.Forms.Button();
            this.PainelGeral = new System.Windows.Forms.Panel();
            this.PainelGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.Location = new System.Drawing.Point(50, 20);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(35, 13);
            this.NomeLabel.TabIndex = 14;
            this.NomeLabel.Text = "Nome";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(50, 80);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(66, 13);
            this.IPLabel.TabIndex = 13;
            this.IPLabel.Text = "Endereço IP";
            // 
            // PortaLabel
            // 
            this.PortaLabel.AutoSize = true;
            this.PortaLabel.Location = new System.Drawing.Point(50, 130);
            this.PortaLabel.Name = "PortaLabel";
            this.PortaLabel.Size = new System.Drawing.Size(32, 13);
            this.PortaLabel.TabIndex = 12;
            this.PortaLabel.Text = "Porta";
            // 
            // NomeTextBox
            // 
            this.NomeTextBox.Location = new System.Drawing.Point(53, 36);
            this.NomeTextBox.Name = "NomeTextBox";
            this.NomeTextBox.Size = new System.Drawing.Size(130, 20);
            this.NomeTextBox.TabIndex = 11;
            this.NomeTextBox.Text = "Seu Nome";
            // 
            // PortaTextBox
            // 
            this.PortaTextBox.Location = new System.Drawing.Point(53, 146);
            this.PortaTextBox.Name = "PortaTextBox";
            this.PortaTextBox.Size = new System.Drawing.Size(130, 20);
            this.PortaTextBox.TabIndex = 10;
            this.PortaTextBox.Text = "50000";
            this.PortaTextBox.TextChanged += new System.EventHandler(this.PortaTextBox_TextChanged);
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(53, 96);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(130, 20);
            this.IPTextBox.TabIndex = 9;
            this.IPTextBox.Text = "127.0.0.1";
            // 
            // ConectarButton
            // 
            this.ConectarButton.Location = new System.Drawing.Point(53, 172);
            this.ConectarButton.Name = "ConectarButton";
            this.ConectarButton.Size = new System.Drawing.Size(130, 60);
            this.ConectarButton.TabIndex = 8;
            this.ConectarButton.Text = "Conectar";
            this.ConectarButton.UseVisualStyleBackColor = true;
            this.ConectarButton.Click += new System.EventHandler(this.ConectarButton_Click_1);
            // 
            // PainelGeral
            // 
            this.PainelGeral.Controls.Add(this.NomeTextBox);
            this.PainelGeral.Controls.Add(this.NomeLabel);
            this.PainelGeral.Controls.Add(this.ConectarButton);
            this.PainelGeral.Controls.Add(this.IPLabel);
            this.PainelGeral.Controls.Add(this.IPTextBox);
            this.PainelGeral.Controls.Add(this.PortaLabel);
            this.PainelGeral.Controls.Add(this.PortaTextBox);
            this.PainelGeral.Location = new System.Drawing.Point(375, 100);
            this.PainelGeral.Name = "PainelGeral";
            this.PainelGeral.Size = new System.Drawing.Size(250, 250);
            this.PainelGeral.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 498);
            this.Controls.Add(this.PainelGeral);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PainelGeral.ResumeLayout(false);
            this.PainelGeral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label PortaLabel;
        private System.Windows.Forms.TextBox NomeTextBox;
        private System.Windows.Forms.TextBox PortaTextBox;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Button ConectarButton;
        private System.Windows.Forms.Panel PainelGeral;




    }
}

