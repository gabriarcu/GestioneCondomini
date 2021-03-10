using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestioneCondomini
{
    public partial class Form2 : Form
    {


        int num = 0;
        public int prog = 0;
        public int us;
        public MyF.ute[] uten = new MyF.ute[1];
        public MyF.condomino[] co = new MyF.condomino[100];
        public MyF.riunione[] riu = new MyF.riunione[100];

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
            lst_condomini.Items.Clear();
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

        private void btn_salvaRiunioni_Click(object sender, EventArgs e)
        {
            riu[prog].numero = prog+1;
            riu[prog].tipo = cbo_tipo.SelectedItem.ToString();
            riu[prog].dat = dateTimePickerRiunione.Value;
            riu[prog].ora.ore = numericUpDownOre.Value;
            riu[prog].ora.minuti = numericUpDownMinuti.Value;
            riu[prog].luogo = txt_luofoRiunione.Text;
            riu[prog].oggetto = txt_oggetto.Text;
            riu[prog].odg = txt_odg.Text;
            prog = prog + 1;

        }

        private void btn_salvaCondomini_Click(object sender, EventArgs e)
        {
            string ma;
            ma = txt_email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Console.WriteLine($"The email is {ma}");
            bool isValidEmail = regex.IsMatch(ma);


            if (!isValidEmail)
            {
                lbl_avviso.Text="Email non valida";
            }
            
        }

        private void btn_GestioneRiunioni_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            txt_progressivo.Text = (prog + 1).ToString();
        }

        private void btn_ElencoRiunioni_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
            int x = 0;

            ListViewItem Riga;
            listView3.Items.Clear();

            while (x < prog)
            {
                Riga = new ListViewItem(new string[]
                {
                    riu[x].numero.ToString(),
                    riu[x].tipo,
                    riu[x].dat.ToString("d"),
                    $"{riu[x].ora.ore.ToString("00")}:{riu[x].ora.minuti.ToString("00")}",
                    riu[x].luogo,
                    riu[x].oggetto
                }

                );

                listView3.Items.Add(Riga);


                x++;
            }
        }
    }
}
