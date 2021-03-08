using System;
using System.IO;
using System.Windows.Forms;

namespace GestioneCondomini
{
    public partial class Form2 : Form
    {
        
         
        int num = 0;
        public int us;
        public MyF.ute[] uten = new MyF.ute[1];
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
                

                sr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

            InitializeComponent();

           // lbl_utente.Text = co[uten[0].id].cognome.ToString();
            lbl_utente.Text = co[us].cognome.ToString();
        }



        private void btn_chiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }
    }
}
