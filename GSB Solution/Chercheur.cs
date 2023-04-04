using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Chercheur
    {
        private int id;
        private string nom;
        private string prenom;
        private string specialite;
        private string an_these;

        public Chercheur(int unId, string unNom, string unPrenom, string uneSpe, string uneAnThese)
        {

            this.id = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.specialite = uneSpe;
            this.an_these = uneAnThese;
        }
        public Chercheur(string unNom, string unPrenom, string uneSpe, string uneAnThese)
        {

            this.nom = unNom;
            this.prenom = unPrenom;
            this.specialite = uneSpe;
            this.an_these = uneAnThese;
        }

        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Specialite { get => specialite; set => specialite = value; }
        public string An_these { get => an_these; set => an_these = value; }
    }
}
