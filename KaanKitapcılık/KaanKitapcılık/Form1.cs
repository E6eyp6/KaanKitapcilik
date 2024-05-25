using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KaanKitapcılık
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Dizin Kitap Kaydetme//////////////
        string[] kutuphane = new string[9999999];
        double[] fiyat = new double[9999999];

        //Kitap No Listelemek İçin Değişken
        int no = 0;

        public void diziyukle() {
            //Listboxların Form Yüklendiğinde Otomatik Olarak Yazılması
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            for (int i = 0; i <= 9999999; i++)
            {
                if (kutuphane[i] == null)
                {
                    break;
                }
                else
                {
                    if (kutuphane[i] == "Kiralandı")
                    {

                    }
                    else {
                        listBox1.Items.Add(i);
                        listBox2.Items.Add(kutuphane[i]);
                        listBox3.Items.Add(fiyat[i]);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dizilerin Form Yüklendiğinde Otomatik Olarak Tanımlanması
            kutuphane[0] = "Şeker Portakalı"; fiyat[0] = 93;
            kutuphane[1] = "Küçük Prens"; fiyat[1] = 47.13;
            kutuphane[2] = "1984"; fiyat[2] = 56.9;
            kutuphane[3] = "Simyacı"; fiyat[3] = 89.19;
            kutuphane[4] = "Kürk Mantolu Madonna"; fiyat[4] = 19.6;
            kutuphane[5] = "Kırmızı Pazartesi"; fiyat[5] = 66.1;
            kutuphane[6] = "Otomatik Portakal"; fiyat[6] = 26.5;

            diziyukle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kitap Ekleme

            for (int i = 0; i  < 999999; i ++)
            {
                if (kutuphane[i] == null) {
                    no = i;
                    break;
                }   
            }
  
            if (kutuphane[no] == null) {
                kutuphane[no] = textBox1.Text;
                fiyat[no] = Convert.ToDouble(textBox3.Text);
            }
            diziyukle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 999999; i++)
            {
                if (kutuphane[i] == null)
                {
                    no = i;
                    break;
                }
            }
            listBox4.Items.Clear();
            listBox4.Items.Add(no + ". " + textBox1.Text + " " + Convert.ToDouble(textBox3.Text) + "₺ ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arama(1);           
        }

        void arama(int a) {
            if (a == 1) {
                if (kutuphane[Convert.ToInt32(numericUpDown2.Value)] != null)
                {
                    label15.Text = Convert.ToString(numericUpDown2.Value);
                    label16.Text = kutuphane[Convert.ToInt32(numericUpDown2.Value)].ToString();
                    label17.Text = fiyat[Convert.ToInt32(numericUpDown2.Value)].ToString();
                }
                else
                {

                    DialogResult result = MessageBox.Show("Ne Yazık Ki Böyle Bir Kitap Bulamadık :(", "Kitap Bulunamadı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        arama(1);
                    }
                }
            }

            else if (a == 2)
            {
                int kitap = 0;

                for (int i = 0; i <= 9999999; i++)
                {
                    if (kutuphane[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (kutuphane[i] == textBox2.Text)
                        {
                            label15.Text = Convert.ToString(i);
                            label16.Text = Convert.ToString(kutuphane[i]);
                            label17.Text = Convert.ToString(fiyat[i]);
                            kitap = i;
                        }  
                    }
                    
                }
                if (kutuphane[kitap] != textBox2.Text) {
                    DialogResult result = MessageBox.Show("Ne Yazık Ki Böyle Bir Kitap Bulamadık :(", "Kitap Bulunamadı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        arama(2);
                    }
                }
            }

            else if(a == 3){
            //Kiralama İşlemi

                if (kutuphane[Convert.ToInt32(numericUpDown3.Value)] != null)
                {
                    for (int i = 0; i <= 9999999; i++)
                    {
                        if (kutuphane[i] == null)
                        {
                            break;
                        }
                        else {
                            if (kutuphane[i] == textBox5.Text)
                            {
                                kutuphane[i] = "Kiralandı";
                                fiyat[i] = 0;
                                diziyukle();
                            }
                        }
                       
                    }
                  
                }
                else
                {
                    DialogResult result = MessageBox.Show("Kitap Numarası Boş Bırakıldı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arama(2);    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arama(3);
        }


    }
}
