namespace GestionScolaire.Models
{
    public class Absences : AbstractEntity
    {

        public Etudiant etudiant { get; set; }

        public Cours cours { get; set; }

        public DateTime date { get; set; }
    }
}
