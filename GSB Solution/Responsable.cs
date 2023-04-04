using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Solution
{
    internal class Responsable
    {
        private string id;
        private string matricule;
        private string date_emboche;
        private string region;
        private string type_personnel;
        private string mdp;

        public Responsable(string unId, string unMatricule, string uneDate_emboche, string uneRegion, string unMdp)
        {

            this.id = unId;
            this.matricule = unMatricule;
            this.date_emboche = uneDate_emboche;
            this.region = uneRegion;
            this.type_personnel ="responsable";
            this.mdp = unMdp;
        }

        public string Id { get => id;}
        public string Matricule { get => matricule;}
        public string Date_emboche { get => date_emboche;}
        public string Region { get => region; set => region = value; }
        public string Type_personnel { get => type_personnel; set => type_personnel = value; }
        public string Mdp { get => mdp; set => mdp = value; }
    }
}
