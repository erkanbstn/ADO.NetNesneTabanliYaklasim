using AdoNesneTabanli.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNesneTabanli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArkadasIslemleri arkadas = new ArkadasIslemleri();

        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = arkadas.ArkadasListe();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            arkadas.ArkadasEkle(txtAd.Text, txtSoyad.Text, txtTelefon.Text, txtCinsiyet.Text, txtDogum.Text, txtAdres.Text);
            gridControl1.DataSource = arkadas.ArkadasListe();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            arkadas.ArkadasSil(txtID.Text);
            gridControl1.DataSource = arkadas.ArkadasListe();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            arkadas.ArkadasGuncelle(txtAd.Text, txtSoyad.Text, txtTelefon.Text, txtCinsiyet.Text, txtDogum.Text, txtID.Text, txtAdres.Text);
            gridControl1.DataSource = arkadas.ArkadasListe();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = arkadas.ArkadasListe();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = arkadas.ArkadasBul(txtAd.Text);
        }
    }
}
