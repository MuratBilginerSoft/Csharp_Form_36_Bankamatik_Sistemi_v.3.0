using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Bankamatik_Sistemi
{
    public partial class Giriş : Form
    {
        #region Metodlar

        public void bağlan()
        {
            try
            {
                bağlantı = new OleDbConnection(yol);
            }
            catch (OleDbException ex)
            {

                MessageBox.Show(" " + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        public void verial()
        {
            sorgu = "Select Adi,Soyadi,Kart_No from Kişiler";
            komut = new OleDbCommand(sorgu,bağlantı);
            kayıt = new OleDbDataAdapter(komut);
            tablo = new DataTable();

            bağlantı.Open();
            kayıt.Fill(tablo);
            bağlantı.Close();
        
        }


        #endregion

        #region Değişkenler

        string yol="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=İşBankası.accdb";
        string sorgu;
        OleDbConnection bağlantı;
        OleDbCommand komut;
        OleDbDataAdapter kayıt;
        DataTable tablo;
        static public string kartno;
        static public string ad, soyad;

        int b = 0;
        #endregion


        public Giriş()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kartno=textBox1.Text;
            bağlan();
            verial();

            int a = tablo.Rows.Count;
            b = 0;
            for (int i = 0; i < a; i++)
            {
                if (kartno == tablo.Rows[i]["Kart_No"].ToString())
                {
                    ad = tablo.Rows[i]["Adi"].ToString();
                    soyad = tablo.Rows[i]["Soyadi"].ToString();
                    b++;
                    break;
                    
                }
            
            }

            if (b!=0)
            {
                    Form1 nfrm = new Form1();
                    this.Hide();
                    nfrm.ShowDialog();
                    this.Show();
            }

            else
            {
                MessageBox.Show("Bu kart numarası geçersizdir.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
          
        }
    }
}
