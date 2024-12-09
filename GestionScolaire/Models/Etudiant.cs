namespace GestionScolaire.Models
{
    public class Etudiant : AbstractEntity
    {

        public int Id { get; set; }

        public string Matricule { get; set; }

        public string Nom { get; set; }

        public string addresse { get; set; }

        public Classe classe { get; set; }



    }
}
