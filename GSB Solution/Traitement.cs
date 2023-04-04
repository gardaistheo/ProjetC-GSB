using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Traitement
    {
        private int id;
        private string date_traitement;
        private string heure_debut;
        private string heure_fin;
        private string travail_realise;
        private string idDemande;
        private string idTechnicien;

        public Traitement(int unId, string uneDate_traitement, string uneHeure_Debut, string uneHeure_Fin, string unTravail_Realise)
        {
            this.id = unId;
            this.date_traitement = uneDate_traitement;
            this.heure_debut = uneHeure_Debut;
            this.heure_fin = uneHeure_Fin;
            this.travail_realise = unTravail_Realise;
        }
        public Traitement(string uneDate_traitement, string uneHeure_Debut, string uneHeure_Fin, string unTravail_Realise, string unIdDemande, string unIdTechnicien)
        {
            this.date_traitement = uneDate_traitement;
            this.heure_debut = uneHeure_Debut;
            this.heure_fin = uneHeure_Fin;
            this.travail_realise = unTravail_Realise;
            this.idDemande = unIdDemande;
            this.idTechnicien = unIdTechnicien;
        }
        public int Id { get { return id; } }
        public string Date_traitement { get { return date_traitement; } set { date_traitement = value; } }
        public string Heure_debut { get { return heure_debut; } set { heure_debut = value; } }
        public string Heure_fin { get { return heure_fin; } set { heure_fin = value; } }
        public string Travail_Realise { get { return travail_realise; } set { travail_realise = value; } }
        public string IdDemande { get { return idDemande; }}
        public string IdTechnicien { get { return idTechnicien; }}
    }
}
