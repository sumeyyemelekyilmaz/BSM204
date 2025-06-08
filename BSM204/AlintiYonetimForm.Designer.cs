namespace BSM204
{
    partial class AlintiYonetimForm
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
            this.dgvAlintilar = new System.Windows.Forms.DataGridView();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtKaynak = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtAlintiIcerik = new System.Windows.Forms.RichTextBox();
            this.cmbKitaplar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlintilar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlintilar
            // 
            this.dgvAlintilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlintilar.Location = new System.Drawing.Point(275, 320);
            this.dgvAlintilar.Name = "dgvAlintilar";
            this.dgvAlintilar.RowHeadersWidth = 70;
            this.dgvAlintilar.RowTemplate.Height = 30;
            this.dgvAlintilar.Size = new System.Drawing.Size(458, 273);
            this.dgvAlintilar.TabIndex = 25;
            this.dgvAlintilar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKitaplar_CellContentClick);
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(578, 241);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(155, 47);
            this.btnGeri.TabIndex = 24;
            this.btnGeri.Text = "Geri Çık";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(578, 187);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(155, 47);
            this.btnSil.TabIndex = 23;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(578, 134);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(155, 47);
            this.btnGuncelle.TabIndex = 22;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(578, 81);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(155, 47);
            this.btnEkle.TabIndex = 21;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtKaynak
            // 
            this.txtKaynak.Location = new System.Drawing.Point(300, 196);
            this.txtKaynak.Name = "txtKaynak";
            this.txtKaynak.Size = new System.Drawing.Size(245, 28);
            this.txtKaynak.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.92638F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(157, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 37);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kaynak:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.92638F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(117, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "İlgili Kitap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.92638F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(67, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 37);
            this.label2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.92638F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(100, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Alıntı İçeriği:";
            // 
            // rtxtAlintiIcerik
            // 
            this.rtxtAlintiIcerik.Location = new System.Drawing.Point(300, 81);
            this.rtxtAlintiIcerik.Name = "rtxtAlintiIcerik";
            this.rtxtAlintiIcerik.Size = new System.Drawing.Size(245, 90);
            this.rtxtAlintiIcerik.TabIndex = 26;
            this.rtxtAlintiIcerik.Text = "";
            // 
            // cmbKitaplar
            // 
            this.cmbKitaplar.FormattingEnabled = true;
            this.cmbKitaplar.Location = new System.Drawing.Point(300, 258);
            this.cmbKitaplar.Name = "cmbKitaplar";
            this.cmbKitaplar.Size = new System.Drawing.Size(245, 30);
            this.cmbKitaplar.TabIndex = 27;
            // 
            // AlintiYonetimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 668);
            this.Controls.Add(this.cmbKitaplar);
            this.Controls.Add(this.rtxtAlintiIcerik);
            this.Controls.Add(this.dgvAlintilar);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtKaynak);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AlintiYonetimForm";
            this.Text = "AlintiYonetimForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlintilar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlintilar;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtKaynak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtAlintiIcerik;
        private System.Windows.Forms.ComboBox cmbKitaplar;
    }
}