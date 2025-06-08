namespace BSM204
{
    partial class AnaMenuForm
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
            this.btnKitapYonetimi = new System.Windows.Forms.Button();
            this.btnAlintiYonetimi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKitapYonetimi
            // 
            this.btnKitapYonetimi.Location = new System.Drawing.Point(124, 149);
            this.btnKitapYonetimi.Name = "btnKitapYonetimi";
            this.btnKitapYonetimi.Size = new System.Drawing.Size(223, 119);
            this.btnKitapYonetimi.TabIndex = 0;
            this.btnKitapYonetimi.Text = "Kitap";
            this.btnKitapYonetimi.UseVisualStyleBackColor = true;
            this.btnKitapYonetimi.Click += new System.EventHandler(this.btnKitapYonetimi_Click);
            // 
            // btnAlintiYonetimi
            // 
            this.btnAlintiYonetimi.Location = new System.Drawing.Point(436, 149);
            this.btnAlintiYonetimi.Name = "btnAlintiYonetimi";
            this.btnAlintiYonetimi.Size = new System.Drawing.Size(223, 119);
            this.btnAlintiYonetimi.TabIndex = 1;
            this.btnAlintiYonetimi.Text = "Alıntı";
            this.btnAlintiYonetimi.UseVisualStyleBackColor = true;
            this.btnAlintiYonetimi.Click += new System.EventHandler(this.btnAlintiYonetimi_Click);
            // 
            // AnaMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAlintiYonetimi);
            this.Controls.Add(this.btnKitapYonetimi);
            this.Name = "AnaMenuForm";
            this.Text = "AnaMenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnaMenuForm_FormClosed);
            this.Load += new System.EventHandler(this.AnaMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKitapYonetimi;
        private System.Windows.Forms.Button btnAlintiYonetimi;
    }
}