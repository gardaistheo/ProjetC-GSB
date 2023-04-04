using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Materiel
    {
        private int id;
        private string processeur;
        private string memoire;
        private string disque;
        private string logiciels;
        private string date_achat; 
        private string garantie;
        private string fournisseur;
        private int personelAsign;

        public Materiel(int unId, string unProcesseur, string uneMemoire, string unDisque, string unLogiciel, string uneDate_achat, string uneGarantie, string unFournisseur, int unPersonnel)
        {
            this.id = unId;
            this.processeur = unProcesseur;
            this.memoire = uneMemoire;
            this.disque = unDisque;
            this.logiciels = unLogiciel;
            this.date_achat = uneDate_achat;
            this.garantie = uneGarantie;
            this.fournisseur = unFournisseur;
            this.personelAsign = unPersonnel;
        }
        

        public Materiel( string unProcesseur, string uneMemoire, string unDisque, string unLogiciel, string uneDate_achat, string uneGarantie, string unFournisseur, int unPerso)
        {
            this.processeur = unProcesseur;
            this.memoire = uneMemoire;
            this.disque = unDisque;
            this.logiciels = unLogiciel;
            this.date_achat = uneDate_achat;
            this.garantie = uneGarantie;
            this.fournisseur = unFournisseur;
            this.personelAsign = unPerso;

        }
        public int Id { get { return id; } }
        public string Processeur { get { return processeur; } set { processeur = value; } }
        public string Memoire { get { return memoire; } set { memoire = value; } }
        public string Disque { get { return disque; } set { disque = value; } }
        public string Logiciels { get { return logiciels; } set { logiciels = value; } }
        public string Date_achat { get { return date_achat; } set { date_achat = value; } }
        public string Garantie { get { return garantie; } set { garantie = value; } }
        public string Fournisseur { get { return fournisseur; } set { fournisseur = value; } }
        public int PersonelAsign { get { return personelAsign; } set { personelAsign = value; } }
    }
}
