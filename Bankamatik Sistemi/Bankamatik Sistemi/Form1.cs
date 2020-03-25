using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bankamatik_Sistemi
{
    public partial class Form1 : Form
    {
        #region Metodlar

        public void parayıver(int x)

        {
            parasayısı[0] = x / 200;
            x = x % 200;
            parasayısı[1] = x / 100;
            x = x % 100;
            parasayısı[2] = x / 50;
            x = x % 50;
            parasayısı[3] = x / 20;
            x = x % 20;
            parasayısı[4] = x / 10;
            x = x % 10;
            parasayısı[5] = x / 5;
            x = x % 5;

            if (x!=0)
            {
                MessageBox.Show("Şu anda bankamatikte bu işleminizi gerçekleştirecek banknot bulunmamaktadır","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                groupBox1.Visible = true;
                label7.Text = parasayısı[0].ToString() + " Adet";
                label6.Text = parasayısı[1].ToString() + " Adet";
                label5.Text = parasayısı[2].ToString() + " Adet";
                label4.Text = parasayısı[3].ToString() + " Adet";
                label3.Text = parasayısı[4].ToString() + " Adet";
                label2.Text = parasayısı[5].ToString() + " Adet";
            }
        }

        #endregion

        #region Değişkenler

       

        int para;

        #endregion

        #region Tanımlamalar

        int[] parasayısı=new int[6];

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            label9.Text = Giriş.ad + " " + Giriş.soyad + " Hoşgeldiniz";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                para = Convert.ToInt32(textBox1.Text);

                parayıver(para);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Geçerli Bir Değer Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button1.Text.Substring(0, 1)));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button2.Text.Substring(0, 2)));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button3.Text.Substring(0, 2)));
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button6.Text.Substring(0, 2)));
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button5.Text.Substring(0, 3)));
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            parayıver(int.Parse(button4.Text.Substring(0, 3)));
        }

       
    }
}
