using System;
using System.IO;
using System.Windows.Forms;


namespace GestioneCondomini
{
    public partial class Form1 : Form
    {
        public MyF.ute[] utent = new MyF.ute[100];
        int x = 0;
        public Form1()
        {
            String line;

            try
            {

                StreamReader sr = new StreamReader("utenti");

                line = sr.ReadLine();

                while (line != null)
                {

                    string[] i = line.Split(';');
                    utent[x].id = int.Parse(i[0].ToString());
                    utent[x].nomeutente = i[1].ToString();
                    utent[x].password = i[2].ToString();
                    x = x + 1;
                    line = sr.ReadLine();
                }
                //close the file

                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            InitializeComponent();
        }

        private void btn_esci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            int y = 0;
            while (y < x)
            {
                if (txt_utente.Text == utent[y].nomeutente && txt_password.Text == utent[y].password)
                {
                    this.Hide();
                    var form2 = new Form2();
                    form2.us = utent[y].id;
                    form2.uten[0] = utent[y];
                    form2.Closed += (s, args) => this.Close();
                    
                    form2.Show();
                    break;
                }

                y = y + 1;
            }



        }
    }
}
