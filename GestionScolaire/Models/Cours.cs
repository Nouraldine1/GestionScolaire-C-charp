
using GestionScolaire.Enum;

namespace GestionScolaire.Models
{
    public class Cours : AbstractEntity
    {
        public int Id { get; set; }
        public DateTime? datedebut { get; set; }

        public DateTime? datefin { get; set; }


        public DateTime? NbreHoraire { get; set; }

        public Semestre semestre { get; set; }

        public Professeur Professeur { get; set; }

        public Classe Classe { get; set; }

        public Module module { get; set; }


        public List<DetailCours>? detailCours { get; set; } = new List<DetailCours>();


    }

}
