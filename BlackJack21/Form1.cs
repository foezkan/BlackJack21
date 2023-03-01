using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rastgele = new Random();
        int sayac = 0;
        int topb = 0, top = 0;
        int b3 = 0, b4 = 0;
        int kisiPuan, pcPuan;

        void kazandiniz()
        {
            MessageBox.Show("Bu turu kazandiniz.");
            kisiPuan = kisiPuan + 10;
            sifirlama();
        }

        void beraberlik()
        {
            MessageBox.Show("Berabere kaldiniz.");
            sifirlama();
        }

        void kaybettiniz()
        {
            MessageBox.Show("Malesef bu turu kaybettiniz.");
            pcPuan = pcPuan + 10;
            sifirlama();
        }

        void sifirlama()
        {
            sayac = 0;
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            label7.Text = "0";
            label8.Text = "0";
            lbltoplam1.Text = "0";
            lbltoplam2.Text = "0";
            button2.Enabled= false;
        }

        void oyunSonu ()
        {
            lblKisiPuan.Text = "0";
            lblPcPuan.Text = "0";
            kisiPuan= 0;
            pcPuan = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled= true;
            sayac++;
          
            if (sayac == 1)
            {
                int a1, a2;
                a1 = rastgele.Next(1, 11);
                a2 = rastgele.Next(1, 11);
                top = a1 + a2;
                label1.Text = a1.ToString();
                label2.Text = a2.ToString();
                lbltoplam1.Text = top.ToString();
           
                int b1, b2;
                b1 = rastgele.Next(1, 11);
                b2 = rastgele.Next(1, 11);
                topb = b1 + b2;
                label5.Text = b1.ToString();
                label6.Text = b2.ToString();
                lbltoplam2.Text = topb.ToString();
            }

            if (sayac == 2)
            {
                int a3;
                a3 = rastgele.Next(1, 11);
                label3.Text = a3.ToString();
                top = Convert.ToInt32(label1.Text) + Convert.ToInt32(label2.Text) + a3;
                lbltoplam1.Text = top.ToString();
            }

            if (sayac == 2 & topb < 15)
            {
                b3 = rastgele.Next(1, 11);
                label7.Text = b3.ToString();
                topb = topb + b3;
                lbltoplam2.Text = topb.ToString();
            }


            if (sayac == 3)
            {
                
                int a4;
                a4 = rastgele.Next(1, 11);
                label4.Text = a4.ToString();
                top = Convert.ToInt32(label1.Text) + Convert.ToInt32(label2.Text) + Convert.ToInt32(label3.Text) + a4;
                lbltoplam1.Text = top.ToString();
            }

            if (sayac == 3 & topb < 15)
            {
                b4 = rastgele.Next(1, 11);
                label8.Text = b4.ToString();
                topb = topb + b4;
                lbltoplam2.Text = topb.ToString();
            }

            if (sayac == 3)
            {

                button2_Click(sender, new EventArgs());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (topb < 15 & label7.Text == "0" )
            {
                b3 = rastgele.Next(1, 11);
                label7.Text = b3.ToString();
                topb = topb + b3;
                lbltoplam2.Text = topb.ToString();
            }
            if (topb < 15 & label8.Text == "0")
            {
                b4 = rastgele.Next(1, 11);
                label8.Text = b4.ToString();
                topb = topb + b4;
                lbltoplam2.Text = topb.ToString();
            }

            if (top>topb & top<=21 & topb<=21 )
            {
                kazandiniz();
            }

            if (top <=21 & topb > 21)
            {
                kazandiniz();
            }

            if (top == topb || (top>21 &topb>21) )
            {
                beraberlik();
            }

            if (topb > top & topb <= 21 & top <= 21)
            {
                kaybettiniz();
            }

            if (topb <= 21 & top > 21)
            {
                kaybettiniz();
            }


            lblKisiPuan.Text = kisiPuan.ToString();
            lblPcPuan.Text = pcPuan.ToString();

            if( lblKisiPuan.Text== "50")
            {
                MessageBox.Show("Tebrikler, Oyunun kazanani sizsiniz:))");
                oyunSonu();


            }

            if(lblPcPuan.Text=="50")
            {
                MessageBox.Show("Üzgünüm malesef oyunu kaybettiniz");
                oyunSonu();
            }
        }
    }
}
