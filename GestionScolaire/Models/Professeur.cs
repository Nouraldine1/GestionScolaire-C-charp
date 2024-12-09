using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GestionScolaire.Models
{
    public class Professeur : AbstractEntity
    {

        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string specialite { get; set; }

        public string grade { get; set; }

        public List<Cours>? classes { get; set; } = new List<Cours>();

    }
}
