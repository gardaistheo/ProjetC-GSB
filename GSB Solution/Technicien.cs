using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Technicien
    {
        private string id;
        private string niveau_intervention;
        private string competence;
        private string formation;
        private string mdp;
        private int nombrePbResolut;

        public Technicien(string unId, string unNiveau_intervention, string uneCompetence, string uneFormation, string unMdp)
        {
            this.id = unId;
            this.niveau_intervention = unNiveau_intervention;
            this.competence = uneCompetence;
            this.formation = uneFormation;
            this.mdp = unMdp;
            this.nombrePbResolut = 0;
        }
        public Technicien(string unNiveau_intervention, string uneCompetence, string uneFormation, string unMdp)
        {
            this.niveau_intervention = unNiveau_intervention;
            this.competence = uneCompetence;
            this.formation = uneFormation;
            this.mdp = unMdp;
            this.nombrePbResolut = 0;
        }
        public string Id { get { return id; } }
        public string Niveau_Intervention { get { return niveau_intervention; } set { niveau_intervention = value; } }
        public string Competence { get { return competence; } set { competence = value; } }
        public string Formation { get { return formation; } set { formation = value; } }
        public string Mdp { get { return mdp; } set { mdp = value; } }
        public int NombrePbResolut { get { return nombrePbResolut; } set { nombrePbResolut = value; } }

        public void IncremResolut()
        {

            nombrePbResolut++;
        }
    }
}
