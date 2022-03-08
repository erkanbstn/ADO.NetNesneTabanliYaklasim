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
    public class VeriTabaniIslemleri
    {
        // BAĞLANTI CÜMLECİĞİ 
        public SqlConnection baglanti = new SqlConnection("Data Source=GEOPC\\SQLEXPRESS;Database=DBArkadas;Integrated Security=True;");

        // NORMAL SORGU LİSTE METHODU
        public DataTable Sorgula(SqlCommand komut)
        {
            DataTable tablo = new DataTable();
            komut.Connection = baglanti;
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                    adaptor.Fill(tablo);
                }
            }
            catch (Exception istisna)
            {
                MessageBox.Show(istisna.Message, istisna.Source);
            }
            finally { baglanti.Close(); }
            baglanti.Close();
            return tablo;
        }


        // DATAREADER İLE SORGULAMA METHODU
        public DataTable SorgulaDR(string sqlsorgu)
        {
            DataTable dt = new DataTable();
            if (sqlsorgu.IndexOf("SELECT") < 0) sqlsorgu = "SELECT * FROM TblArkadas";
            SqlCommand komut = new SqlCommand(sqlsorgu, baglanti);
            SqlDataReader okur;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    okur = komut.ExecuteReader();
                    dt.Load(okur);
                    okur.Close();
                    baglanti.Close();
                }
            }
            catch (Exception istisna)
            {
                MessageBox.Show(istisna.Message);
            }
            return dt;
        }

        // SQL İŞLEMLERİNİ TAMAMLAYAN METHOD
        public int SqlDml(SqlCommand komut)
        {
            int ess = 0;
            komut.Connection = baglanti;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                ess = komut.ExecuteNonQuery();

            }
            catch (Exception istisna)
            {
                MessageBox.Show(istisna.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return ess;
        }


        // SKALER SONUÇ DÖNDÜREN SORGULAR
        public object SqlScaler(SqlCommand komut)
        {
            object sonuc = null; // Sorgu Skaler Bir Değer Döndüreceğinden OBJECT Dönmesi Gerekir Bu Sebeple Methodun Object Döndürmesi İçin Tanımlanan Variable
            komut.Connection = baglanti;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                sonuc = komut.ExecuteScalar();
            }
            catch (Exception istisna)
            {
                MessageBox.Show(istisna.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return sonuc;
        }
        public object SqlScaler(string ifade)
        {
            object sonuc = null;
            SqlCommand komut = new SqlCommand(ifade, baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                sonuc = komut.ExecuteScalar();
            }
            catch (Exception istisna)
            {
                MessageBox.Show(istisna.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return sonuc;
        }
    }
}
