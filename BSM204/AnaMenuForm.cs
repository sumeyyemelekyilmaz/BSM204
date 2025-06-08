using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSM204
{
    public partial class AnaMenuForm : Form
    {
        public AnaMenuForm()
        {
            InitializeComponent();
        }

        private void btnKitapYonetimi_Click(object sender, EventArgs e)
        {
            KitapYonetimForm kitapForm = new KitapYonetimForm();
            kitapForm.Show();
            this.Hide(); // Ana menüyü gizle
        }

        private void btnAlintiYonetimi_Click(object sender, EventArgs e)
        {
            AlintiYonetimForm alintiForm = new AlintiYonetimForm();
            alintiForm.Show();
            this.Hide(); // Ana menüyü gizle
        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void AnaMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Uygulamayı tamamen kapat
        }
    }
}
