
namespace Cafe_otomasyon_Projesi.formlar
{
    partial class Masa_Form
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
            this.Masalar_Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.Masa_Ekle_Button = new System.Windows.Forms.Button();
            this.Masalar_Flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // Masalar_Flow
            // 
            this.Masalar_Flow.Controls.Add(this.Masa_Ekle_Button);
            this.Masalar_Flow.Location = new System.Drawing.Point(12, 12);
            this.Masalar_Flow.Name = "Masalar_Flow";
            this.Masalar_Flow.Size = new System.Drawing.Size(1696, 969);
            this.Masalar_Flow.TabIndex = 0;
            // 
            // Masa_Ekle_Button
            // 
            this.Masa_Ekle_Button.BackColor = System.Drawing.Color.White;
            this.Masa_Ekle_Button.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Masa_Ekle_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Masa_Ekle_Button.Image = global::Cafe_otomasyon_Projesi.Properties.Resources.c442f3e03868a85c344f4d5f9a6887ca;
            this.Masa_Ekle_Button.Location = new System.Drawing.Point(3, 3);
            this.Masa_Ekle_Button.Name = "Masa_Ekle_Button";
            this.Masa_Ekle_Button.Size = new System.Drawing.Size(200, 200);
            this.Masa_Ekle_Button.TabIndex = 1;
            this.Masa_Ekle_Button.Text = "Masa Ekle";
            this.Masa_Ekle_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Masa_Ekle_Button.UseVisualStyleBackColor = false;
            this.Masa_Ekle_Button.Click += new System.EventHandler(this.Masa_Ekle_Button_Click);
            // 
            // Masa_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1720, 993);
            this.Controls.Add(this.Masalar_Flow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Masa_Form";
            this.Text = "Masa_Form";
            this.Load += new System.EventHandler(this.Masa_Form_Load);
            this.Masalar_Flow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel Masalar_Flow;
        public System.Windows.Forms.Button Masa_Ekle_Button;
    }
}