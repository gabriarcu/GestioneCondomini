using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestioneCondomini
{
    public partial class Form2 : Form
    {


        int num = 0;
        public int prog = 0;
        public int u ;
        public int us;
        public int me = 0;
        public MyF.ute[] uten = new MyF.ute[100];
        public MyF.condomino[] co = new MyF.condomino[100];
        public MyF.riunione[] riu = new MyF.riunione[100];
        public MyF.messaggio[] mes = new MyF.messaggio[1000];
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
                co[num].millesimi = float.Parse(i[8]);
                co[num].user = i[9].ToString();
                co[num].password = i[10].ToString();



                num = num + 1;
                line = sr.ReadLine();
            }

            sr.Close();

            
            
            String line1;

            StreamReader sr1 = new StreamReader("riunioni");

            line1 = sr1.ReadLine();

            while (line1 != null)
            {

                string[] ix = line1.Split(';');
                riu[prog].numero= int.Parse(ix[0].ToString());
                riu[prog].tipo= ix[1].ToString();
                riu[prog].dat = DateTime.Parse(ix[2]);
                string[] tempo = ix[3].Split(":");
                riu[prog].ora.ore =int.Parse(tempo[0]);
                riu[prog].ora.minuti = int.Parse(tempo[1]);
                riu[prog].luogo = ix[4].ToString();
                riu[prog].oggetto= ix[5].ToString();
                riu[prog].odg = ix[6].ToString();
               
                prog = prog + 1;
                line1 = sr1.ReadLine();
            }

            sr1.Close();


            String line5;

            StreamReader sr5 = new StreamReader("messaggi");

            line5 = sr5.ReadLine();

            while (line5 != null)
            {

                string[] iy = line5.Split(';');
                mes[me].id = int.Parse(iy[0].ToString());
                mes[me].mittente= int.Parse(iy[1].ToString());
                mes[me].destinatario = int.Parse(iy[2].ToString());
                mes[me].testo = iy[3];
                mes[me].Dataora = DateTime.Parse(iy[4].ToString());

                me = me + 1;
                line5 = sr5.ReadLine();
            }

            sr5.Close();





            if (us!=0)
            {
                btn_gestioneCondomini.Visible = false;
                btn_GestioneRiunioni.Visible = false;
                lbl_utente.Text = co[us].cognome.ToString() + " " + co[us].nome.ToString();
            }
            else
            {
                lbl_utente.Text = co[(us)].cognome.ToString() + " " + co[(us)].nome.ToString();
            }
            

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            txt_id.Text = (num).ToString();
        }

        private void btn_ElencoCondomini_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            int x = 1;
            
            
            
            lst_condomini.Items.Clear();
            lst_condomini.Items.Add("0 - Amministratore - Admin");
            while(x<num)
            {
                string riga = co[x].id_c + " - " + co[x].cognome + " " + co[x].nome;
                lst_condomini.Items.Add(riga);
                x = x + 1;
            }
            
            int p = 0;
            int xx = 0;
            
            ListViewItem Riga;
            listView4.Items.Clear();
            
            while (xx < me)
            {
                if(us==mes[xx].destinatario)
                {
                    Riga = new ListViewItem(new string[]
                {
                    mes[xx].Dataora.ToString("d"),
                    mes[xx].Dataora.ToString("T"),
                    $"{co[mes[xx].mittente].cognome} {co[mes[xx].mittente].nome}", 
                    mes[xx].testo
                }

                ); ;

                    

                    string[] txt = mes[xx].testo.Split("*");
                    
                    int xx2 = 0;
                    string tip = default;
                    while (xx2 < mes[xx].testo.Split("*").Length)
                    {
                        tip += txt[xx2] + "\n";
                        xx2 = xx2 + 1;
                    }
                    Riga.ToolTipText = tip;
                listView4.Items.Add(Riga);
                

                }
                xx++;
            }

            int xxa = 0;
            ListViewItem Riga2;
            listView5.Items.Clear();

            while (xxa < me)
            {
                if (us == mes[xxa].mittente)
                {
                    Riga2 = new ListViewItem(new string[]
                {
                    mes[xxa].Dataora.ToString("d"),
                    mes[xxa].Dataora.ToString("T"),
                    $"{co[mes[xxa].destinatario].cognome} {co[mes[xxa].destinatario].nome}",
                    mes[xxa].testo
                }

                ); ;



                    string[] txt2 = mes[xxa].testo.Split("*");


                    int xx3 = 0;

                    string tip2 = default;
                    while (xx3 < mes[xxa].testo.Split("*").Length)
                    {
                        tip2 += txt2[xx3] + "\n";
                        xx3 = xx3 + 1;
                    }
                    Riga2.ToolTipText = tip2;
                    listView5.Items.Add(Riga2);


                }
                xxa++;
            }
        }

        private void lst_condomini_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = lst_condomini.SelectedItem.ToString();
            string[] b = a.Split(" - ");
            int codice=int.Parse(b[0].ToString());
            txt_destinatario.Text = a;
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
            //riu[prog].odg = txt_odg.Text;
            

            string[] lineaTesto = richTextBox1.Lines;
            string testo = default;
            foreach (string line in lineaTesto)
            {
                testo += line + "*";
            }
            riu[prog].odg = testo; 
            
            string tt = $"{riu[prog].ora.ore}:{riu[prog].ora.minuti}";
            StreamWriter sw = File.AppendText("riunioni");
            //Write a line of text
            string linea = $"{riu[prog].numero};{riu[prog].tipo};{riu[prog].dat.ToString("d")};{tt};{riu[prog].luogo};{riu[prog].oggetto};{riu[prog].odg}";
        
            sw.WriteLine(linea);

            //Close the file
            sw.Close();

            prog = prog + 1;


        }

        private void btn_salvaCondomini_Click(object sender, EventArgs e)
        {
            co[num].id_c = int.Parse(txt_id.Text);
            co[num].fiscale = txt_fiscale.Text;
            co[num].cognome = txt_cognome.Text;
            co[num].nome = txt_nome.Text;
            co[num].nascita = dateTimePickerNascita.Value;
            co[num].luogoNascita = Txt_luodoNascita.Text;
            co[num].telefono = txt_telefono.Text;
            co[num].email = txt_email.Text;
            co[num].millesimi = int.Parse(txt_millesimi.Text);
            co[num].user = txt_user.Text;
            co[num].password = txt_password.Text;

            StreamWriter sw2 = File.AppendText("condomini");
            //Write a line of text
            string linea2 = $"{co[num].id_c};{co[num].fiscale};{co[num].cognome};{co[num].nome};{co[num].nascita.ToString("d")};{co[num].luogoNascita};{co[num].telefono};{co[num].email};{co[num].millesimi};{co[num].user};{co[num].password}";

            sw2.WriteLine(linea2);

            //Close the file
            sw2.Close();

           
            uten[u+1].id = u+1;
            uten[u+1].nomeutente = co[num].user;
            uten[u+1].password = co[num].password;


            StreamWriter sw3 = File.AppendText("utenti");
            //Write a line of text
            string linea3 = $"{uten[u+1].id};{uten[u+1].nomeutente};{uten[u+1].password}";

            sw3.WriteLine(linea3);

            //Close the file
            sw3.Close();

            num = num + 1;
            u = u + 1;

            txt_id.Text=num.ToString();
            txt_fiscale.Clear();
            txt_cognome.Clear();
            txt_nome.Clear();
            dateTimePickerNascita.Value = DateTime.Now.AddYears(-18);
            Txt_luodoNascita.Clear();
            txt_telefono.Clear();
            txt_email.Clear();
            pictureBox1.Image = null;
            txt_millesimi.Clear();
            txt_user.Clear();
            txt_password.Clear();
            txt_fiscale.Focus();
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
                    riu[x].oggetto,
                    riu[x].odg
                }

                ) ;

                listView3.Items.Add(Riga);


                x++;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                string Rodg = default;
                ListView.SelectedListViewItemCollection r =
                this.listView3.SelectedItems;


                foreach (ListViewItem item in r)
                {
                    Rodg += item.SubItems[6].Text;
                }

                string[] txt = Rodg.Split("*");

                int xx = 0;
                richTextBox2.Clear();
                while (xx < Rodg.Split("*").Length)
                {
                    richTextBox2.AppendText(txt[xx] + "\n");
                    xx = xx + 1;
                }

            }


                

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            string ma;
            ma = txt_email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool isValidEmail = regex.IsMatch(ma);


            if (!isValidEmail)
            {
                
                pictureBox1.ImageLocation= "rosso.jpg";
            }
            else
            {
                pictureBox1.ImageLocation = "verde.jpg";

            }
        }

        private void btn_invia_Click(object sender, EventArgs e)
        {
            mes[me].id = me + 1;
            mes[me].mittente = us;
            string stringa = txt_destinatario.Text;
            string[] des = stringa.Split(" - ");
            mes[me].destinatario=int.Parse(des[0]);

            string[] lineaTesto = richTextBox3.Lines;
            string testo = default;
            foreach (string line in lineaTesto)
            {
                testo += line + "*";
            }
            mes[me].testo = testo;
            mes[me].Dataora = DateTime.Now;

       
            StreamWriter sw4 = File.AppendText("messaggi");
            //Write a line of text
            string linea4 = $"{mes[me].id};{mes[me].mittente};{mes[me].destinatario};{mes[me].testo};{mes[me].Dataora}";

            sw4.WriteLine(linea4);

            //Close the file
            sw4.Close();

            me = me + 1;
            txt_destinatario.Clear();
            richTextBox3.Clear();
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView4.SelectedItems.Count > 0)
            //{
            //    string Rodg = default;
            //    ListView.SelectedListViewItemCollection r =
            //    this.listView4.SelectedItems;


            //    foreach (ListViewItem item in r)
            //    {
            //        Rodg += item.SubItems[3].Text;
            //    }

            //    string[] txt = Rodg.Split("*");

            //    int xx = 0;
            //    richTextBox4.Clear();
            //    while (xx < Rodg.Split("*").Length)
            //    {
            //        richTextBox4.AppendText(txt[xx] + "\n");
            //        xx = xx + 1;
            //    }

            //}
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView4_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
        
        }
            
    }
}

