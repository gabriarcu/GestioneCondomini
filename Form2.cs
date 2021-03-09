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


            InitializeComponent();

           

        }



        private void btn_chiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            String line;

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
                co[num].millesimi = float.Parse(i[8].ToString());
                co[num].user = i[9].ToString();
                co[num].password = i[10].ToString();



                num = num + 1;
                line = sr.ReadLine();
            }

            sr.Close();

            if (us!=0)
            {
                btn_gestioneCondomini.Visible = false;
                btn_GestioneRiunioni.Visible = false;
            }

            lbl_utente.Text = co[us].cognome.ToString() + " " + co[us].nome.ToString();



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl2.SelectedIndex == 1)
            //{
            //    int x = 1;

            //    ListViewItem Riga;
            //    listView1.Items.Clear();

            //    while (x < num)
            //    {
            //        Riga = new ListViewItem(new string[]
            //        {

            //        co[x].id_c.ToString(),
            //        co[x].fiscale,
            //        co[x].cognome,
            //        co[x].nome,
            //        co[x].nascita.ToString("d"),
            //        co[x].luogoNascita,
            //        co[x].telefono,
            //        co[x].email,
            //        co[x].millesimi.ToString("0.00"),
            //        co[x].user,
            //        co[x].password


            //        }

            //        );

            //        listView1.Items.Add(Riga);


            //        x++;
            //    }
            //}
            //else
            //    MessageBox.Show("a");
        }

        private void btn_gestioneCondomini_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            int x = 1;

            ListViewItem Riga;
            listView1.Items.Clear();

            while (x < num)
            {
                Riga = new ListViewItem(new string[]
                {

                    co[x].id_c.ToString(),
                    co[x].fiscale,
                    co[x].cognome,
                    co[x].nome,
                    co[x].nascita.ToString("d"),
                    co[x].luogoNascita,
                    co[x].telefono,
                    co[x].email,
                    co[x].millesimi.ToString("0.00"),
                    co[x].user,
                    co[x].password


                }

                );

                listView1.Items.Add(Riga);


                x++;
            }
        }

        private void btn_ElencoCondomini_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            int x = 1;
            while(x<num)
            {
                string riga = co[x].id_c + " - " + co[x].cognome + " - " + co[x].nome;
                lst_condomini.Items.Add(riga);
                x = x + 1;
            }
        }

        private void lst_condomini_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = lst_condomini.SelectedItem.ToString();
            string[] b = a.Split(" - ");
            int codice=int.Parse(b[0].ToString());
            listView2.Items.Clear();
            ListViewItem riga;
            riga = new ListViewItem(new string[]
                {
                    co[codice].telefono,
                    co[codice].email

                }
            );
            listView2.Items.Add(riga);
        }
    }
}
