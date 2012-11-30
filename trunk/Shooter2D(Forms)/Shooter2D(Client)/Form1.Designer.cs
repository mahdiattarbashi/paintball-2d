namespace Shooter2D_Client_
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
            this.PainelGeral = new System.Windows.Forms.Panel();
            this.CTButton = new System.Windows.Forms.Button();
            this.TerrorButton = new System.Windows.Forms.Button();
            this.PortaTextBox = new System.Windows.Forms.TextBox();
            this.NomeTextBox = new System.Windows.Forms.TextBox();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.ConectarButton = new System.Windows.Forms.Button();
            this.IPLabel = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.PortaLabel = new System.Windows.Forms.Label();
            this.PainelGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // PainelGeral
            // 
            this.PainelGeral.Controls.Add(this.CTButton);
            this.PainelGeral.Controls.Add(this.TerrorButton);
            this.PainelGeral.Controls.Add(this.PortaTextBox);
            this.PainelGeral.Controls.Add(this.NomeTextBox);
            this.PainelGeral.Controls.Add(this.NomeLabel);
            this.PainelGeral.Controls.Add(this.ConectarButton);
            this.PainelGeral.Controls.Add(this.IPLabel);
            this.PainelGeral.Controls.Add(this.IPTextBox);
            this.PainelGeral.Controls.Add(this.PortaLabel);
            this.PainelGeral.Location = new System.Drawing.Point(543, 150);
            this.PainelGeral.Name = "PainelGeral";
            this.PainelGeral.Size = new System.Drawing.Size(250, 300);
            this.PainelGeral.TabIndex = 16;
            // 
            // CTButton
            // 
            this.CTButton.AutoSize = true;
            this.CTButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CTButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.CTButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CTButton.Location = new System.Drawing.Point(123, 172);
            this.CTButton.Name = "CTButton";
            this.CTButton.Size = new System.Drawing.Size(60, 40);
            this.CTButton.TabIndex = 17;
            this.CTButton.Text = "CT";
            this.CTButton.UseVisualStyleBackColor = false;
            this.CTButton.Click += new System.EventHandler(this.CTButton_Click);
            // 
            // TerrorButton
            // 
            this.TerrorButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.TerrorButton.Location = new System.Drawing.Point(53, 172);
            this.TerrorButton.Name = "TerrorButton";
            this.TerrorButton.Size = new System.Drawing.Size(60, 40);
            this.TerrorButton.TabIndex = 16;
            this.TerrorButton.Text = "Terror";
            this.TerrorButton.UseVisualStyleBackColor = false;
            this.TerrorButton.Click += new System.EventHandler(this.TerrorButton_Click);
            // 
            // PortaTextBox
            // 
            this.PortaTextBox.Location = new System.Drawing.Point(53, 146);
            this.PortaTextBox.Name = "PortaTextBox";
            this.PortaTextBox.Size = new System.Drawing.Size(130, 20);
            this.PortaTextBox.TabIndex = 15;
            this.PortaTextBox.Text = "5000";
            // 
            // NomeTextBox
            // 
            this.NomeTextBox.Location = new System.Drawing.Point(53, 36);
            this.NomeTextBox.Name = "NomeTextBox";
            this.NomeTextBox.Size = new System.Drawing.Size(130, 20);
            this.NomeTextBox.TabIndex = 11;
            this.NomeTextBox.Text = "Seu Nome";
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
            // ConectarButton
            // 
            this.ConectarButton.Location = new System.Drawing.Point(53, 218);
            this.ConectarButton.Name = "ConectarButton";
            this.ConectarButton.Size = new System.Drawing.Size(130, 60);
            this.ConectarButton.TabIndex = 8;
            this.ConectarButton.Text = "Conectar";
            this.ConectarButton.UseVisualStyleBackColor = true;
            this.ConectarButton.Click += new System.EventHandler(this.ConectarButton_Click);
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
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(53, 96);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(130, 20);
            this.IPTextBox.TabIndex = 9;
            this.IPTextBox.Text = "127.0.0.1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.PainelGeral);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.PainelGeral.ResumeLayout(false);
            this.PainelGeral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PainelGeral;
        private System.Windows.Forms.TextBox PortaTextBox;
        private System.Windows.Forms.TextBox NomeTextBox;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Button ConectarButton;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label PortaLabel;
        private System.Windows.Forms.Button CTButton;
        private System.Windows.Forms.Button TerrorButton;
    }
}

