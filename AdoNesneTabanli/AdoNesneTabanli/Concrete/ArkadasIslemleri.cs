using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNesneTabanli.Concrete
{
    public class ArkadasIslemleri
    {
        VeriTabaniIslemleri isle = new VeriTabaniIslemleri();

        // ÜRÜN LİSTELEME İŞLEMİ
        public DataTable ArkadasListe()
        {
            return isle.Sorgula(new SqlCommand("Select * from TblArkadas"));
        }

        // ÜRÜN SORGULAMA İŞLEMİ
        public DataTable ArkadasSorgula(SqlCommand komut)
        {
            return isle.Sorgula(komut);
        }

        // ÜRÜN BULMA İŞLEMİ
        public DataTable ArkadasBul(string hece)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TblArkadas WHERE Ad LIKE '%'+@hece+'%'");
            komut.Connection = isle.baglanti;
            komut.Parameters.AddWithValue("@hece", hece);
            return isle.Sorgula(komut);
        }


        // ÜRÜN EKLEME İŞLEMİ
        public int ArkadasEkle(string ad, string soyad, string telefon, string cinsiyet, string dogum,string adres)
        {
            int ess = 0;
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "INSERT INTO TblArkadas(Ad,Soyad,Telefon,Cinsiyet,Dogum) VALUES(@ad,@soyad,@telefon,@cinsiyet,@dogum,@adres)";
            try
            {
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@dogum", dogum);
                komut.Parameters.AddWithValue("@adres", adres);
                ess = isle.SqlDml(komut);
            }
            catch (Exception ist)
            {
                MessageBox.Show(ist.Message);
            }
            isle.baglanti.Close();
            return ess;
        }



        // ÜRÜN SİLME İŞLEMİ 
        public int ArkadasSil(string id)
        {
            int ess = 0;
            SqlCommand komut = new SqlCommand();
            komut.Connection = isle.baglanti;
            komut.CommandText = "DELETE FROM TblArkadas WHERE ID=@id";
            // bu kez parametre nesnesini tanımlayarak ekleyelim
            //SqlParameter numaraParametresi = new SqlParameter();
            //numaraParametresi.ParameterName = "@no";
            //numaraParametresi.SqlDbType = SqlDbType.Int;
            //numaraParametresi.Size = yok
            try
            {
                //numaraParametresi.Value = id;
                // parametre hazır komuta ekle
                //komut.Parameters.Add(numaraParametresi);
                komut.Parameters.AddWithValue("@id", id);
                ess = isle.SqlDml(komut);
            }
            catch (Exception istis) { MessageBox.Show(istis.Message); }
            isle.baglanti.Close();
            return ess;
        }

        // ÜRÜN GÜNCELLEME İŞLEMİ
        public int ArkadasGuncelle(string ad, string soyad, string telefon, string cinsiyet, string dogum,string id,string adres)
        {
            int ess = 0;
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "UPDATE TblArkadas SET Ad=@ad, Soyad=@soyad,Telefon=@telefon, Cinsiyet=@cinsiyet, Dogum=@dogum, Adres=@adres WHERE ID=@id";
            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@soyad", soyad);
            komut.Parameters.AddWithValue("@telefon", telefon);
            komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@dogum", dogum);
            komut.Parameters.AddWithValue("@adres", adres);
            komut.Parameters.AddWithValue("@id", id);
            ess = isle.SqlDml(komut);
            return ess;
        }
    }
}
