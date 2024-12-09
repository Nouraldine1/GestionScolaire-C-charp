using GestionScolaire.Enum;

namespace GestionScolaire.Models
{
    public class DetailCours : AbstractEntity
    {

        public int Id { get; set; }
        public Cours cours { get; set; }

        public Classe classe { get; set; }

    }
}
