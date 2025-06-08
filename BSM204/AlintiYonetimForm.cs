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
    public partial class AlintiYonetimForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-C8TPFK;Initial Catalog=DijitalKutuphaneveAlinti;Integrated Security=True";

        private void ClearFormFields()
        {
            rtxtAlintiIcerik.Clear();
            txtKaynak.Clear();
            cmbKitaplar.SelectedIndex = -1;
        }
        public AlintiYonetimForm()
        {
            InitializeComponent();
            LoadKitaplarToComboBox(); // Kitapları ComboBox'a yükle
            LoadAlintilar(); // Alıntıları listele
        }

        private void LoadKitaplarToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT KitapID, KitapAdi FROM Kitaplar";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbKitaplar.DisplayMember = "KitapAdi"; // Gösterilecek metin
                        cmbKitaplar.ValueMember = "KitapID";     // Arka plandaki değer
                        cmbKitaplar.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar ComboBox'a yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAlintilar()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Alıntıları ilgili kitap adıyla birlikte getirme
                    string query = @"SELECT A.AlintiID, A.AlintiIcerik, A.Kaynak, K.KitapAdi
                                     FROM Alintilar AS A
                                     LEFT JOIN Kitaplar AS K ON A.KitapID = K.KitapID";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAlintilar.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alıntılar yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            string alintiIcerik = rtxtAlintiIcerik.Text;
            string kaynak = txtKaynak.Text;
            int? kitapID = null; // null değer alabilir

            if (cmbKitaplar.SelectedValue != null)
            {
                kitapID = Convert.ToInt32(cmbKitaplar.SelectedValue);
            }

            if (string.IsNullOrWhiteSpace(alintiIcerik))
            {
                MessageBox.Show("Alıntı içeriği boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Alintilar (AlintiIcerik, Kaynak, KitapID) VALUES (@AlintiIcerik, @Kaynak, @KitapID)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AlintiIcerik", alintiIcerik);
                        command.Parameters.AddWithValue("@Kaynak", string.IsNullOrWhiteSpace(kaynak) ? (object)DBNull.Value : kaynak);
                        command.Parameters.AddWithValue("@KitapID", kitapID.HasValue ? (object)kitapID.Value : DBNull.Value);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Alıntı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadAlintilar(); // Listeyi güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alıntı eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvAlintilar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir alıntı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int alintiID = Convert.ToInt32(dgvAlintilar.CurrentRow.Cells["AlintiID"].Value);
            string alintiIcerik = rtxtAlintiIcerik.Text;
            string kaynak = txtKaynak.Text;
            int? kitapID = null;

            if (cmbKitaplar.SelectedValue != null)
            {
                kitapID = Convert.ToInt32(cmbKitaplar.SelectedValue);
            }

            if (string.IsNullOrWhiteSpace(alintiIcerik))
            {
                MessageBox.Show("Alıntı içeriği boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Alintilar SET AlintiIcerik = @AlintiIcerik, Kaynak = @Kaynak, KitapID = @KitapID WHERE AlintiID = @AlintiID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AlintiIcerik", alintiIcerik);
                        command.Parameters.AddWithValue("@Kaynak", string.IsNullOrWhiteSpace(kaynak) ? (object)DBNull.Value : kaynak);
                        command.Parameters.AddWithValue("@KitapID", kitapID.HasValue ? (object)kitapID.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@AlintiID", alintiID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Alıntı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                        LoadAlintilar(); // Listeyi güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alıntı güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAlintilar.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek bir alıntı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int alintiID = Convert.ToInt32(dgvAlintilar.CurrentRow.Cells["AlintiID"].Value);

            DialogResult result = MessageBox.Show("Seçilen alıntıyı silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Alintilar WHERE AlintiID = @AlintiID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AlintiID", alintiID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Alıntı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFormFields();
                            LoadAlintilar(); // Listeyi güncelle
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Alıntı silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAlintilar.Rows[e.RowIndex];
                rtxtAlintiIcerik.Text = row.Cells["AlintiIcerik"].Value.ToString();
                txtKaynak.Text = row.Cells["Kaynak"].Value.ToString();

                // İlgili kitabı ComboBox'ta seçili hale getir
                // Eğer KitapID null ise (yani alıntı bir kitaba bağlı değilse)
                // ComboBox'ı ilk elemana veya "Seçiniz" gibi bir seçeneğe ayarla
                if (row.Cells["KitapAdi"].Value != DBNull.Value && row.Cells["KitapAdi"].Value != null)
                {
                    cmbKitaplar.Text = row.Cells["KitapAdi"].Value.ToString();
                }
                else
                {
                    cmbKitaplar.SelectedIndex = -1; // Hiçbirini seçili yapma
                }
            }

           

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {

            AnaMenuForm anaMenu = new AnaMenuForm();
            anaMenu.Show();
            this.Close(); // Bu formu kapat
        }
    }
}
