using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSM204
{
    public partial class KitapYonetimForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C8TPFK;Initial Catalog=DijitalKutuphaneveAlinti;Integrated Security=True";

        public KitapYonetimForm()
        {
            InitializeComponent();
            LoadKitaplar(); // Form yüklendiğinde kitapları listele
        }

        private void LoadKitaplar()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT KitapID, KitapAdi, Yazar, YayinYili, SayfaSayisi FROM Kitaplar";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvKitaplar.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            string kitapAdi = txtKitapAdi.Text;
            string yazar = txtYazar.Text;
            int yayinYili, sayfaSayisi;

            if (string.IsNullOrWhiteSpace(kitapAdi) || string.IsNullOrWhiteSpace(yazar) ||
                !int.TryParse(txtYayinYili.Text, out yayinYili) || !int.TryParse(txtSayfaSayisi.Text, out sayfaSayisi))
            {
                MessageBox.Show("Lütfen tüm alanları doğru ve eksiksiz doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Kitaplar (KitapAdi, Yazar, YayinYili, SayfaSayisi) VALUES (@KitapAdi, @Yazar, @YayinYili, @SayfaSayisi)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KitapAdi", kitapAdi);
                        command.Parameters.AddWithValue("@Yazar", yazar);
                        command.Parameters.AddWithValue("@YayinYili", yayinYili);
                        command.Parameters.AddWithValue("@SayfaSayisi", sayfaSayisi);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kitap başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadKitaplar(); // Listeyi güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir kitap seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kitapID = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["KitapID"].Value);
            string kitapAdi = txtKitapAdi.Text;
            string yazar = txtYazar.Text;
            int yayinYili, sayfaSayisi;

            if (string.IsNullOrWhiteSpace(kitapAdi) || string.IsNullOrWhiteSpace(yazar) ||
                !int.TryParse(txtYayinYili.Text, out yayinYili) || !int.TryParse(txtSayfaSayisi.Text, out sayfaSayisi))
            {
                MessageBox.Show("Lütfen tüm alanları doğru ve eksiksiz doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Kitaplar SET KitapAdi = @KitapAdi, Yazar = @Yazar, YayinYili = @YayinYili, SayfaSayisi = @SayfaSayisi WHERE KitapID = @KitapID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KitapAdi", kitapAdi);
                        command.Parameters.AddWithValue("@Yazar", yazar);
                        command.Parameters.AddWithValue("@YayinYili", yayinYili);
                        command.Parameters.AddWithValue("@SayfaSayisi", sayfaSayisi);
                        command.Parameters.AddWithValue("@KitapID", kitapID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kitap başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadKitaplar(); // Listeyi güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (dgvKitaplar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek bir kitap seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kitapID = Convert.ToInt32(dgvKitaplar.CurrentRow.Cells["KitapID"].Value);

            DialogResult result = MessageBox.Show("Seçilen kitabı silmek istediğinizden emin misiniz? Bu işlem, ilgili alıntıları da etkileyebilir.", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // İlgili alıntıları silmeden önce, eğer kitap tablosu ile alıntılar tablosu arasında cascade delete ilişkisi kurulmadıysa,
                        // önce ilgili alıntıları silmemiz gerekir. SQL scriptinde FOREIGN KEY tanımında ON DELETE CASCADE eklemediğimiz için manuel olarak siliyoruz.
                        string deleteAlintilarQuery = "DELETE FROM Alintilar WHERE KitapID = @KitapID";
                        using (SqlCommand commandAlintilar = new SqlCommand(deleteAlintilarQuery, connection))
                        {
                            commandAlintilar.Parameters.AddWithValue("@KitapID", kitapID);
                            commandAlintilar.ExecuteNonQuery();
                        }

                        string deleteKitapQuery = "DELETE FROM Kitaplar WHERE KitapID = @KitapID";
                        using (SqlCommand commandKitap = new SqlCommand(deleteKitapQuery, connection))
                        {
                            commandKitap.Parameters.AddWithValue("@KitapID", kitapID);
                            commandKitap.ExecuteNonQuery();
                            MessageBox.Show("Kitap başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFormFields();
                            LoadKitaplar(); // Listeyi güncelle
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kitap silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Başlık satırı değilse
            {
                DataGridViewRow row = dgvKitaplar.Rows[e.RowIndex];
                txtKitapAdi.Text = row.Cells["KitapAdi"].Value.ToString();
                txtYazar.Text = row.Cells["Yazar"].Value.ToString();
                txtYayinYili.Text = row.Cells["YayinYili"].Value.ToString();
                txtSayfaSayisi.Text = row.Cells["SayfaSayisi"].Value.ToString();
            }
        }

            private void ClearFormFields()
            {
                txtKitapAdi.Clear();
                txtYazar.Clear();
                txtYayinYili.Clear();
                txtSayfaSayisi.Clear();
            }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaMenuForm anaMenu = new AnaMenuForm();
            anaMenu.Show();
            this.Close(); // Bu formu kapat
        }
    }
}
