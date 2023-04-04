using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_Solution
{
    internal class bd
    {
        private static string connString = "Server=127.0.0.1;Database=gsbcsharp;Uid=root;Password=;";
        private static int nbDemande = 0;

        public int NbDemande { get { return nbDemande; } }
        /// <summary>
        /// Retourne le type de personnel en fonction de l'id
        /// </summary>
        /// <param name="id">Identifiant de connexion</param>
        /// <param name="mdp">Mot de passe de connexion</param>
        /// <returns></returns>
        public static string VerifConn (string id, string mdp)
        {
            MySqlConnection conn = new MySqlConnection (connString);
            conn.Open();
            string retour="";

            MySqlCommand command1 = conn.CreateCommand ();
            command1.CommandText = "SELECT mdp FROM personnel WHERE identite ="+id;
            MySqlCommand command2 = conn.CreateCommand();
            command2.CommandText = "SELECT mdp FROM technicien WHERE id ="+id;
            MySqlCommand command3 = conn.CreateCommand();
            command3.CommandText = "SELECT type_personnel FROM personnel WHERE identite ="+id;
            

            string mdpBD = Convert.ToString (command1.ExecuteScalar());
            string mdpBD2 = Convert.ToString (command2.ExecuteScalar());
            string typePers = Convert.ToString(command3.ExecuteScalar());

            if (mdpBD.Equals(mdp))
            {
                if (typePers.Equals("responsable"))
                {
                    retour= "responsable";
                }
                else
                {
                    retour = "utilisateur";
                }
            }
            else if (mdpBD2.Equals(mdp))
            {
                retour= "technicien";
            }
            return retour;
        }
        /// <summary>
        /// Ajoute un incident à la BD
        /// </summary>
        /// <param name="unIncident">un objet Incident permettant d'incerer un incident dans la BD</param>
        public static void AddIncendent (Incident unIncident)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO demande (objet, niveau_urgence, identite, id_mat) VALUES ('" + unIncident.Objet + "', '" + unIncident.Niveau_urgence +"', '" +unIncident.Signalant+"', '"+ unIncident.IdPoste + "')";
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Ajoute un technicien à la BD
        /// </summary>
        /// <param name="unTechnicien">un objet Technicien permettant d'incerer un technicien dans la BD</param>
        public static void AddTechnicien(Technicien unTechnicien)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO technicien (niveau_intervention, competence, formation, mdp) VALUES ('" + unTechnicien.Niveau_Intervention + "', '" + unTechnicien.Competence + "', '" + unTechnicien.Formation + "', '" + unTechnicien.Mdp + "')";
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Ajoute un Utilisateur à la BD
        /// </summary>
        /// <param name="unUtilisateur">un objet Utilisateur permettant d'incerer un utilisateur dans la BD</param>
        public static void AddUtilisateur(Utilisateur unUtilisateur)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO personnel (identite, matricule, date_embauche, region, type_personel, mdp) VALUES ('" + unUtilisateur.Id + "', '" + unUtilisateur.Matricule + "', '" + unUtilisateur.Date_emboche + "', '" + unUtilisateur.Region + "', '" + unUtilisateur.Type_personnel + "', '" + unUtilisateur.Mdp + "')";
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Ajoute un Chercheur à la BD
        /// </summary>
        /// <param name="unChercheur">un objet Chercheur permettant d'incerer un chercheur dans la BD</param>
        public static void AddChercheur(Chercheur unChercheur)/*zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz*/
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO chercheur (nom, prenom, spe_rech, an_these) VALUES ('" + unChercheur.Nom + "', '" + unChercheur.Prenom + "', '" + unChercheur.Specialite + "', '" + unChercheur.An_these + "')";
            command1.ExecuteNonQuery();
        }
        /*
        public static List<Incident> selectIncidents()
        {
            Incident unIncident;
            List<Incident> lesIncidents = new List<Incident>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM demande";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                if (numPost == Convert.ToInt16(dataReader["id_1"]))
                {
                    unIncident = new Incident(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["Objet"]), Convert.ToInt16(dataReader["Niveau_urgence"]), Convert.ToString(dataReader["Etat"]), Convert.ToString(dataReader["Type_de_prise_en_charge"]), Convert.ToString(dataReader["id_1"]));
                    lesIncidents.Add(unIncident);
                }
               
            }
            return lesIncidents;
        }
        */
        /// <summary>
        /// Vérifie si il existe une demande correspondant au numéro de post
        /// </summary>
        /// <param name="numPost">l'id unique d'un matériel</param>
        /// <returns></returns>
        public static bool verifNumPost(int numPost)
        {
            bool verif = false;
            
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM demande WHERE id_mat =" + numPost;
            
            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Vérifie si il existe un incident correspondant a l'id recu
        /// </summary>
        /// <param name="idIncid">l'id recu d'un incident</param>
        /// <returns></returns>
        public static bool verifIdIncident(int idIncid)
        {
            bool verif = false;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM demande WHERE id =" + idIncid;

            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Vérifie si il existe un technicien correspondant a l'id recu
        /// </summary>
        /// <param name="idTech">l'id recu d'un technicien</param>
        /// <returns></returns>
        public static bool verifIdTechnicien(int idTech)
        {
            bool verif = false;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM technicien WHERE id =" + idTech;

            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Vérifie si il existe un utilisateur correspondant a l'id recu
        /// </summary>
        /// <param name="idUser">l'id recu d'un utilisateur</param>
        /// <returns></returns>
        public static bool verifIdUtilisateur(int idUser)
        {
            bool verif = false;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM personnel WHERE identite =" + idUser;

            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Vérifie si il existe un chercheur correspondant a l'id recu
        /// </summary>
        /// <param name="unIdCherch">l'id recu d'un chercheur</param>
        /// <returns></returns>
        public static bool verifChercheur(int unIdCherch)
        {
            bool verif = false;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM chercheur WHERE id =" + unIdCherch;

            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Renvoi un objet incident en fonction de l'id en paramètre
        /// </summary>
        /// <param name="idIncident">l'id unique d'un incident</param>
        /// <returns></returns>
        public static Incident selectUnIncidentById(int idIncident)
        {
                Incident unIncident;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT * FROM demande WHERE id =" + idIncident;
                MySqlDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                unIncident = new Incident(Convert.ToString(dataReader["Objet"]), Convert.ToInt16(dataReader["Niveau_urgence"]), Convert.ToString(dataReader["Etat"]), Convert.ToString(dataReader["Identite"]), Convert.ToString(dataReader["id_1"]));
            return unIncident;

        }
        /// <summary>
        /// Renvoi un objet technicien en fonction de l'id en paramètre
        /// </summary>
        /// <param name="idTechnicien">l'id unique d'un technicien</param>
        /// <returns></returns>
        public static Technicien selectUnTechnicienById(int idTechnicien)
        {
            Technicien unTechnicien;
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM technicien WHERE id =" + idTechnicien;
            MySqlDataReader dataReader = command1.ExecuteReader();
            dataReader.Read();
            unTechnicien = new Technicien(Convert.ToString(dataReader["id"]), Convert.ToString(dataReader["Niveau_intervention"]), Convert.ToString(dataReader["Competence"]), Convert.ToString(dataReader["Formation"]), Convert.ToString(dataReader["mdp"]));
            return unTechnicien;

        }
        /// <summary>
        /// Renvoi un objet incident en fonction de l'id en paramètre
        /// </summary>
        /// <param name="numPost">l'id unique d'un incident</param>
        /// <returns></returns>
        public static Incident selectUnIncident(int numPost)
        {
            if(verifNumPost(numPost) == false)
            {
                return null;
            }
            else
            {
                Incident unIncident;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT * FROM demande WHERE id_mat =" + numPost;
                MySqlDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                unIncident = new Incident(Convert.ToString(dataReader["Objet"]), Convert.ToInt16(dataReader["Niveau_urgence"]), Convert.ToString(dataReader["Etat"]), Convert.ToString(dataReader["Identite"]), Convert.ToString(dataReader["id_1"]));
                return unIncident;
            }
            
        }
        /// <summary>
        /// Renvoi un objet chercheur en fonction de l'id en paramètre
        /// </summary>
        /// <param name="unId">l'id unique d'un chercheur</param>
        /// <returns></returns>
        public static Chercheur selectUnChercheur(int unId)
        {
            if (verifChercheur(unId) == false)
            {
                return null;
            }
            else
            {
                Chercheur unChercheur;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "SELECT * FROM chercheur WHERE id =" + unId;
                MySqlDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                unChercheur = new Chercheur(Convert.ToString(dataReader["nom"]), Convert.ToString(dataReader["prenom"]), Convert.ToString(dataReader["spe_rech"]), Convert.ToString(dataReader["an_these"]));
                return unChercheur;
            }

        }
        /// <summary>
        /// Met a jour l'heure de fin de traitement et le travail effectué en fonction de l'id de l'incident traité
        /// </summary>
        /// <param name="uneHeure">l'heure de fin de traitement</param>
        /// <param name="unTravail">le travail éffectué par le technicien</param>
        /// <param name="idIncid">l'id unique de l'incident traité</param>
        public static void MajTraitement(string uneHeure, string unTravail, int idIncid)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE traitement SET heures_fin = '" + uneHeure + "', travail_realise = '"+unTravail+"' WHERE id = " + idIncid;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Renvoie le nombre de problème résolut par un technicien en fonction de son id
        /// </summary>
        /// <param name="idTech">l'id unique du technicien </param>
        /// <returns></returns>
        public static int MajNbTraitement(string idTech)
        {
            int nb;
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT nbPbResolv FROM technicien WHERE id = " + idTech;
            nb = Convert.ToInt16(command1.ExecuteScalar());
            return nb;
        }
        /// <summary>
        /// Met à jour l'état de la demande en fonction de l'id d'un incident
        /// </summary>
        /// <param name="idIncid">l'id unique de la demande/incident</param>
        public static void ModifEtatIncident(int idIncid)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE demande SET etat = 'résolut' WHERE id = " + idIncid;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Modifie les donnée d'un technicien avec les paramètres fournie en fonction de l'id
        /// </summary>
        /// <param name="unId">l'id unique d'un technicien</param>
        /// <param name="unNiveau_Interv">le nouveau niveau d'intervention du technicien</param>
        /// <param name="uneCompetence">la nouvelle compétence d'un technicien</param>
        /// <param name="uneFormation">la nouvelle formation d'un technicien</param>
        /// <param name="unMdp">le nouveau mot de passe d'un technicien</param>
        public static void ModifTechnicien(string unId, string unNiveau_Interv, string uneCompetence, string uneFormation, string unMdp)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE technicien SET niveau_intervention = '" + unNiveau_Interv + "', competence = '" + uneCompetence + "', formation = '" + uneFormation + "', mdp = '" + unMdp + "'  WHERE id = " + unId;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Modifie les donnée d'un utilisateur avec les paramètres fournie en fonction de l'id
        /// </summary>
        /// <param name="unId">l'id unique d'un utilisateur</param>
        /// <param name="unMatricule">le nouveau niveau matricule d'un utilisateur</param>
        /// <param name="uneDate_embauche">la nouvelle date d'embauch d'un utilisateur</param>
        /// <param name="uneRegion">la nouvelle région d'un utilisateur</param>
        /// <param name="unMdp">le nouveau niveau not de passe d'un utilisateur</param>
        public static void ModifUtilisateur(string unId, string unMatricule, string uneDate_embauche, string uneRegion, string unMdp)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE personnel SET matricule = '" + unMatricule + "', date_embauche = '" + uneDate_embauche + "', region = '" + uneRegion + "', mdp = '" + unMdp + "'  WHERE Identite = " + unId;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Modifie les donnée d'un chercheur avec les paramètres fournie en fonction de l'id
        /// </summary>
        /// <param name="unId">l'id unique d'un chercheur</param>
        /// <param name="unNom">>le nouveau nom d'un chercheur</param>
        /// <param name="unPrenom">le nouveau prenom d'un chercheur</param>
        /// <param name="uneSpeRech">la nouvelle spécialité d'un chercheur</param>
        /// <param name="uneAnThese">la nouvelle année de thèse d'un chercheur</param>
        public static void ModifChercheur(int unId, string unNom, string unPrenom, string uneSpeRech, string uneAnThese)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "UPDATE chercheur SET nom = '" + unNom + "', prenom = '" + unPrenom + "', spe_rech = '" + uneSpeRech + "', uneAnThese = '" + uneAnThese + "'  WHERE id = " + unId;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Met à jour le nombre de pb résolut pas un technicien après incrémentation dans le main
        /// </summary>
        /// <param name="id">l'id unique d'un technicien</param>
        /// <param name="unTechnicien">un objet technicien possédent le nombre de problème résolut incrémenté</param>
        public static void IncrementPbResolvTehcnicien(string id,Technicien unTechnicien)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = " UPDATE technicien SET nbPbResolv = '"+ unTechnicien.NombrePbResolut+ "' WHERE id = '" + id+"'";
            command1.ExecuteNonQuery();
        }

       /// <summary>
       /// Ajoute un matériel à la base de donnée en fonction des attributs de l'objet recu
       /// </summary>
       /// <param name="unMateriel">l'objet matériel devat être ajouté à la BD</param>
        public static void AddMateriel(Materiel unMateriel)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO matériel (processeur, memoire, disque, logiciels, date_achat, garantie, fournisseur, identite) VALUES ('" + unMateriel.Processeur + "', '" + unMateriel.Memoire + "', '" + unMateriel.Disque + "', '" + unMateriel.Logiciels + "', '" + unMateriel.Date_achat + "', '" + unMateriel.Garantie + "', '" + unMateriel.Fournisseur + "', '" + unMateriel.PersonelAsign + "')";
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Ajoute un Traitement à la base de donnée en fonction des attributs des l'objets recus
        /// </summary>
        /// <param name="unTraitement">un objet traitement</param>
        /// <param name="unIncident">un objet incident</param>
        /// <param name="unTechnicien">un objet technicien</param>
        public static void AddTraitement(Traitement unTraitement, Incident unIncident, Technicien unTechnicien)/*zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz*/
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO traitement (date_traitement, heure_debut, heures_fin, travail_realise, id_tech ,id_demande) VALUES ('" + unTraitement.Date_traitement + "', '" + unTraitement.Heure_debut + "', '" + unTraitement.Heure_fin + "', '" + unTraitement.Travail_Realise + "', '" + unTechnicien.Id + "', '" + unIncident.Id + "')";
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Renvoie la liste des incidents dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Incident> selectIncidents()
        {
            Incident unIncident;
            List<Incident> lesIncidents = new List<Incident>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM demande";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unIncident = new Incident(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["objet"]), Convert.ToInt16(dataReader["niveau_urgence"]), Convert.ToString(dataReader["etat"]), Convert.ToString(dataReader["type_de_prise_en_charge"]), Convert.ToString(dataReader["identite"]), Convert.ToString(dataReader["id_mat"]));
                lesIncidents.Add(unIncident);
            }
            return lesIncidents;
        }
        /// <summary>
        /// Renvoie la liste des traitements dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Traitement> selectTraitements()
        {
            Traitement unTraitement;
            List<Traitement> lesTraitements = new List<Traitement>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM traitement";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unTraitement = new Traitement(Convert.ToString(dataReader["date_traitement"]), Convert.ToString(dataReader["heure_debut"]), Convert.ToString(dataReader["heures_fin"]), Convert.ToString(dataReader["travail_realise"]), Convert.ToString(dataReader["id_tech"]), Convert.ToString(dataReader["id_demande"]));
                lesTraitements.Add(unTraitement);
            }
            return lesTraitements;
        }
        /// <summary>
        /// Renvoie la liste des techniciens dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Technicien> selectTechniciens()
        {
            Technicien unTechnicien;
            List<Technicien> lesTechniciens = new List<Technicien>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM technicien";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unTechnicien = new Technicien(Convert.ToString(dataReader["id"]), Convert.ToString(dataReader["niveau_intervention"]), Convert.ToString(dataReader["competence"]), Convert.ToString(dataReader["formation"]), Convert.ToString(dataReader["mdp"]));
                lesTechniciens.Add(unTechnicien);
            }
            return lesTechniciens;
        }
        /// <summary>
        /// Renvoie la liste des utilisateurs dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Utilisateur> selectUtilisateurs()
        {
            Utilisateur unUtilisateur;
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM personnel WHERE type_personnel = 'utilisateur'";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unUtilisateur = new Utilisateur(Convert.ToString(dataReader["identite"]), Convert.ToString(dataReader["matricule"]), Convert.ToString(dataReader["region"]), Convert.ToString(dataReader["mdp"]), Convert.ToString(dataReader["date_embauche"]));
                lesUtilisateurs.Add(unUtilisateur);
            }
            return lesUtilisateurs;
        }
        /// <summary>
        /// Renvoie la liste des matériels dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Materiel> selectMateriels()
        {
            Materiel unMateriel;
            List<Materiel> lesMateriels = new List<Materiel>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM materiel";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unMateriel = new Materiel(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["processeur"]), Convert.ToString(dataReader["memoire"]), Convert.ToString(dataReader["disque"]), Convert.ToString(dataReader["logiciels"]), Convert.ToString(dataReader["date_achat"]), Convert.ToString(dataReader["garantie"]), Convert.ToString(dataReader["fournisseur"]), Convert.ToInt16(dataReader["identite"]));
                lesMateriels.Add(unMateriel);
            }
            return lesMateriels;
        }
        /// <summary>
        /// renvoie la liste des chercheurs dans la bd
        /// </summary>
        /// <returns></returns>
        public static List<Chercheur> selectChercheurs()
        {
            Chercheur unChercheur;
            List<Chercheur> lesChercheurs = new List<Chercheur>();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT * FROM chercheur";
            MySqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                unChercheur = new Chercheur(Convert.ToInt16(dataReader["id"]), Convert.ToString(dataReader["nom"]), Convert.ToString(dataReader["prenom"]), Convert.ToString(dataReader["spe_rech"]), Convert.ToString(dataReader["an_these"]));
                lesChercheurs.Add(unChercheur);
            }
            return lesChercheurs;
        }
        /// <summary>
        /// Vérifie que le matériel existe dans la bd en fonction de l'id 
        /// </summary>
        /// <param name="idMat">l'id unique d'un matériel</param>
        /// <returns></returns>
        public static bool verifIdMat(int idMat)
        {
            bool verif = false;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM matériel WHERE id =" + idMat;

            int verifNb = Convert.ToInt16(command1.ExecuteScalar());
            if (verifNb == 1)
            {
                verif = true;
            }
            return verif;
        }
        /// <summary>
        /// Supprime un matériel en fonction de son id
        /// </summary>
        /// <param name="idMat">l'id unique d'un matériel </param>
        public static void supprMateriel(int idMat)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM matériel WHERE id ="+idMat;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Supprime un technicien en fonction de son id
        /// </summary>
        /// <param name="idTech">l'id unique d'un technicien</param>
        public static void supprTechnicien(int idTech)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM technicien WHERE id =" + idTech;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Supprime un utilisateur en fonction de son id
        /// </summary>
        /// <param name="idUtil">l'id unique d'un utilisateur</param>
        public static void supprUtil(int idUtil)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM personel WHERE identite =" + idUtil;
            command1.ExecuteNonQuery();
        }
        /// <summary>
        /// Supprime un chercheur en fonction de son id
        /// </summary>
        /// <param name="idCherch">l'id unique d'un chercheur</param>
        public static void supprCherch(int idCherch)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "DELETE FROM chercheur WHERE id =" + idCherch;
            command1.ExecuteNonQuery();
        }
    }
}
