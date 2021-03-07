using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GestioneCondomini
{
    public partial class Form2 : Form
    {
        public int us;
        int num = 0;
        public MyF.ute[] uten = new MyF.ute[100];
        public MyF.condomino[] co = new MyF.condomino[100];

        public Form2()
        {
            String line;

            try
            {

                StreamReader sr = new StreamReader("condomini");

                line = sr.ReadLine();

                while (line != null)
                {

                    string[] i = line.Split(';');
                    co[num].id_c = int.Parse(i[0].ToString());
                    co[num].fiscale = i[1].ToString();
                    co[num].cognome = i[2].ToString();
                    co[num].nome = i[3].ToString();
                    co[num].nascita = DateTime.Parse(i[4]);
                    co[num].luogoNascita = i[5].ToString();
                    co[num].telefono = i[6].ToString();
                    co[num].email = i[7].ToString();
                    co[num].millesimi = float.Parse(i[8]);
                    co[num].user = i[9].ToString();
                    co[num].password = i[10].ToString();



                    num = num + 1;
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
            lbl_utente.Text = co[us].id_c.ToString();

        }

        

        private void btn_chiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
