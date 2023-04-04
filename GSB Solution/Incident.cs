using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Incident
    {
        private int id;
        private string objet;
        private int niveau_urgence;
        private string etat;
        private string type_de_prise_en_charge;
        private string signalant;
        private string idPoste;

        public Incident(int unId, string unObjet, int unNiveau_urgence, string unEtat, string unePrise_en_charge, string signalant, string idPoste)
        {
            this.id = unId;
            this.objet = unObjet;
            this.niveau_urgence = unNiveau_urgence;
            this.etat = unEtat;
            this.type_de_prise_en_charge = unePrise_en_charge;
            this.signalant = signalant;
            this.idPoste = idPoste;
        }

        public Incident(string unObjet, int unNiveau_urgence, string unEtat, string signalant, string idPoste)
        {
            
            this.objet = unObjet;
            this.niveau_urgence = unNiveau_urgence;
            this.etat = unEtat;
            this.signalant = signalant;
            this.idPoste = idPoste;
        }
        public int Id { get { return id; } }
        public string Objet { get { return objet; } set { objet = value; } }
        public int Niveau_urgence { get { return niveau_urgence; } set { niveau_urgence = value; } }
        public string Etat { get { return etat; } set { etat = value; } }
        public string Type_de_prise_en_charge { get { return type_de_prise_en_charge; } set { type_de_prise_en_charge = value; } }
        public string Signalant { get { return signalant; } set { signalant = value; } }
        public string IdPoste { get { return idPoste; } set { idPoste = value; } }

    }
}
