using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSB_Solution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string matConnecte;
        private void button1_Click(object sender, EventArgs e)
        {
            string verif = bd.VerifConn( textBox1.Text, textBox2.Text);
            matConnecte = textBox1.Text;
            if (verif.Equals("utilisateur"))
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            else if (verif.Equals("responsable"))
            {
                groupBox18.Enabled = true;
                groupBox19.Enabled = true;
                groupBox20.Enabled = true;
            }
            else if (verif.Equals("technicien"))
            {
                GBTechniciens.Enabled = true;
            }
            else
                labelErreurConnexion.Text = "mot de passe ou id incorrect";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Incident incidentCreat = new Incident(Convert.ToString(textBox4.Text), Convert.ToInt16(numericUpDown1.Value), "Nouveau", Convert.ToString(matConnecte), textBox3.Text);

            bd.AddIncendent(incidentCreat);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Incident incidentRech = bd.selectUnIncident(Convert.ToInt16(textBox5.Text));
            if (incidentRech == null)
            {
                label40.Text = "Le poste rechercher n’existe pas ou plus ";
            }
            else
            {
                listBox1.Items.Add("Poste :" + incidentRech.IdPoste + ", Objet : " + incidentRech.Objet + ", Etat :" + incidentRech.Etat + " .");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Materiel unMateriel = new Materiel(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, Convert.ToInt16(textBox30.Text));
            bd.AddMateriel(unMateriel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Materiel> lesMateriels = new List<Materiel>();
            lesMateriels = bd.selectMateriels();
            foreach (Materiel unMateriel in lesMateriels)
            {
                listBox3.Items.Add("Le poste :"+unMateriel.Id+", Processeur :"+unMateriel.Processeur+", Mémoire :"+unMateriel.Memoire+", Logiciels"+unMateriel.Logiciels+", Date d'achat"+unMateriel.Date_achat+", Garantie :"+unMateriel.Fournisseur+" et appartiens au personnel correspondant au code :"+unMateriel.PersonelAsign+" .");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bd.verifIdMat(Convert.ToInt32(textBox13.Text)) == false)
            {
                label42.Text = "Le matériel que vous souhaitez supprimer n’existe pas ou plus";
            }
            else
            {
                bd.supprMateriel(Convert.ToInt32(textBox13.Text));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Incident> lesIncidents = new List<Incident>();
            lesIncidents = bd.selectIncidents();
            foreach (Incident unIncident in lesIncidents)
            {
                listBox2.Items.Add("Id :"+unIncident.Id+", Objet :"+unIncident.Objet+", Niveau d'urgence :"+unIncident.Niveau_urgence+", Etat :"+unIncident.Etat+", Prise en charge :"+unIncident.Type_de_prise_en_charge+", Signalant :"+unIncident.Signalant+", ID poste :"+unIncident.IdPoste);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Incident unIncident = bd.selectUnIncidentById(Convert.ToInt16(textBox14.Text));
            if (bd.verifIdIncident(Convert.ToInt32(textBox14.Text)) == false)
            {
                label16.Text = "La demande que vous souhaitez consulter n’existe pas ou plus";
            }
            else
            {
                label16.Text = unIncident.Etat;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (bd.verifIdIncident(Convert.ToInt32(textBox15.Text)) == false)
            {
                label43.Text = "La demande que vous souhaitez consulter n’existe pas ou plus";
            }
            else
            {
                bd.ModifEtatIncident(Convert.ToInt16(textBox15.Text));
                bd.MajTraitement(DateTime.Now.ToString("H:mm"), textBox16.Text, Convert.ToInt16(textBox15.Text));
            }
            Technicien unTechnicien = bd.selectUnTechnicienById(Convert.ToInt32(matConnecte));
            unTechnicien.NombrePbResolut = bd.MajNbTraitement(unTechnicien.Id);
            unTechnicien.IncremResolut();
            bd.IncrementPbResolvTehcnicien(matConnecte, unTechnicien);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Technicien unTechnicien = new Technicien(textBox17.Text, textBox18.Text, textBox19.Text, textBoxMdpTechCreat.Text);
            bd.AddTechnicien(unTechnicien);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Utilisateur unUtilisateur = new Utilisateur(textBox22.Text, textBox32.Text, textBox31.Text, textBox20.Text, textBoxMdpUtilCreat.Text);
            bd.AddUtilisateur(unUtilisateur);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (bd.verifIdTechnicien(Convert.ToInt32(textBox23.Text)) == false)
            {
                label47.Text = "Le technicien que vous souhaitez modifier n’existe pas ou plus";
            }
            else
            {
                bd.ModifTechnicien(textBox23.Text, textBox21.Text, textBox24.Text, textBox25.Text, textBox33.Text); ;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (bd.verifIdUtilisateur(Convert.ToInt32(textBox26.Text)) == false)
            {
                label51.Text = "Le technicien que vous souhaitez modifier n’existe pas ou plus";
            }
            else
            {
                bd.ModifUtilisateur(textBox26.Text, textBox27.Text, textBox34.Text, textBox35.Text, textBox36.Text);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (bd.verifIdTechnicien(Convert.ToInt32(textBox28.Text)) == false)
            {
                label52.Text = "Le technicien que vous souhaitez supprimer n’existe pas ou plus";
            }
            else
            {
                bd.supprTechnicien(Convert.ToInt32(textBox28.Text));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (bd.verifIdUtilisateur(Convert.ToInt32(textBox29.Text)) == false)
            {
                label53.Text = "L'utilisateur que vous souhaitez supprimer n’existe pas ou plus";
            }
            else
            {
                bd.supprUtil(Convert.ToInt32(textBox29.Text));
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            int rang = listBox2.SelectedIndex;
            Incident incidSelect = bd.selectIncidents()[rang];
            incidSelect.Etat = "pris en charge";
            Traitement unTraitement = new Traitement(DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("H:mm"), null, null, Convert.ToString(incidSelect.Id), matConnecte);
            Technicien leTechnicien = bd.selectUnTechnicienById(Convert.ToInt16(matConnecte));
            bd.AddTraitement(unTraitement, incidSelect, leTechnicien);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            List<Incident> lesIncidents = new List<Incident>();
            lesIncidents = bd.selectIncidents();
            int nombreTotal = 0;
            int nombreFini = 0;
            foreach (Incident inc in lesIncidents)
            {
                if(inc.Etat == "résolut")
                {
                    nombreFini++;
                    nombreTotal++;
                }
                else
                {
                    nombreTotal++;
                }
            }
            listBox4.Items.Add("Pourcentage de résolution des problèmes : "+Convert.ToString((nombreFini * 100) / nombreTotal)+"%");

            List<Incident> lesIncidents2 = new List<Incident>();
            List<Traitement> lesTraitements = new List<Traitement>();
            lesIncidents = bd.selectIncidents();
            lesTraitements = bd.selectTraitements();
            int demandePrisEnCharge = 0;
            int nbDemande = 0;
            foreach (Incident inc in lesIncidents)
            {
                nbDemande++;
                foreach (Traitement trait in lesTraitements)
                {
                    if (inc.Id == Convert.ToInt16(trait.IdDemande))
                    {
                        demandePrisEnCharge++; 
                    }
                }
                
            }
            listBox4.Items.Add("Il y a  : " + nbDemande + " demandes, dont "+demandePrisEnCharge+" sont ou on été pris en charge.");

        }

        private void button17_Click(object sender, EventArgs e)
        {
            List<Traitement> lesTraitements = new List<Traitement>();
            lesTraitements = bd.selectTraitements();
            List<Technicien> lesTechniciens = new List<Technicien>();
            lesTechniciens = bd.selectTechniciens();
            foreach (Technicien techni in lesTechniciens)
            {
                int nbPdPrisEnCharge=  0;
                foreach(Traitement trait in lesTraitements)
                {
                    if (trait.IdTechnicien == techni.Id)
                        nbPdPrisEnCharge ++;
                }
                listBox5.Items.Add("Les technicien qui à pour id :" + techni.Id + " à pris  en charge " + nbPdPrisEnCharge + " demandes.");
                listBox5.Items.Add("Le même technicien à résolut "+techni.NombrePbResolut+" problème(s)");
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            lesUtilisateurs = bd.selectUtilisateurs();
            List<Incident> lesIncidents = new List<Incident>();
            lesIncidents = bd.selectIncidents();
            foreach (Utilisateur util in lesUtilisateurs)
            {
                int nbPdDeclare = 0;
                foreach (Incident trait in lesIncidents)
                {
                    if (util.Id == trait.Signalant)
                        nbPdDeclare++;
                }
                listBox6.Items.Add("L'utilisateur qui à pour id :" + util.Id + " à déclaré " + nbPdDeclare + " problèmes.");
            }
        }

        private void buttonEnregCherch_Click(object sender, EventArgs e)
        {
            Chercheur unChercheur = new Chercheur(textBoxNomCherch.Text, textBoxPrenomCherch.Text, textBoxSpeRecherch.Text, textBoxAnThese.Text);
            bd.AddChercheur(unChercheur);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            List<Chercheur> lesChercheurs = new List<Chercheur>();
            lesChercheurs = bd.selectChercheurs();
            foreach (Chercheur unChercheur in lesChercheurs)
            {
                listBox7.Items.Add("Nom :" + unChercheur.Nom + ", Prenom :" + unChercheur.Prenom + ", Spécialité de Recherche :" + unChercheur.Specialite + ", Année de thèse" + unChercheur.An_these + " .");;
            }
        }
    }
}
