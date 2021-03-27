namespace Cafe_otomasyon_Projesi.formlar
{
    partial class Masalar_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Masalar_Form));
            this.Masalar_Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.Masa_Ekle_Btn = new System.Windows.Forms.Button();
            this.Masalar_Flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // Masalar_Flow
            // 
            this.Masalar_Flow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Masalar_Flow.AutoScroll = true;
            this.Masalar_Flow.BackColor = System.Drawing.Color.White;
            this.Masalar_Flow.Controls.Add(this.Masa_Ekle_Btn);
            this.Masalar_Flow.Location = new System.Drawing.Point(21, 12);
            this.Masalar_Flow.Name = "Masalar_Flow";
            this.Masalar_Flow.Size = new System.Drawing.Size(1668, 952);
            this.Masalar_Flow.TabIndex = 2;
            // 
            // Masa_Ekle_Btn
            // 
            this.Masa_Ekle_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(114)))), ((int)(((byte)(89)))));
            this.Masa_Ekle_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Masa_Ekle_Btn.Font = new System.Drawing.Font("Calibri", 13F);
            this.Masa_Ekle_Btn.Location = new System.Drawing.Point(3, 3);
            this.Masa_Ekle_Btn.Name = "Masa_Ekle_Btn";
            this.Masa_Ekle_Btn.Size = new System.Drawing.Size(200, 200);
            this.Masa_Ekle_Btn.TabIndex = 1;
            this.Masa_Ekle_Btn.Text = "Masa Ekle";
            this.Masa_Ekle_Btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Masa_Ekle_Btn.UseVisualStyleBackColor = false;
            this.Masa_Ekle_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Masalar_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1701, 976);
            this.Controls.Add(this.Masalar_Flow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(206, 78);
            this.Name = "Masalar_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Masalar_Form_Load);
            this.Masalar_Flow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Masa_Ekle_Btn;
        private System.Windows.Forms.FlowLayoutPanel Masalar_Flow;
    }
}