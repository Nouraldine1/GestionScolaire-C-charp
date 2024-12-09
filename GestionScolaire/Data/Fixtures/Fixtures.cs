using GestionScolaire.Models;
using GestionScolaire.Enum;
namespace GestionScolaire.Data.Fixtures
{
    public static class Fixtures
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {

            var enseignants = new List<Professeur>();
            var etudiants = new List<Etudiant>();
            var absences = new List<Absences>();
            var cours = new List<Cours>();
            var detailsCours = new List<DetailCours>();
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                enseignants.Add(new Professeur
                {
                    Nom = $"Nom{i + 1}",
                    Prenom = $"Prenom{i + 1}",
                    specialite = $"specialite{i + 1}",
                    grade = $"grade{i + 1}",
                });
                etudiants.Add(new Etudiant
                {
                    Nom = $"Nom{i + 1}",
                    Matricule = $"Matricule{i + 1}",
                    addresse = $"addresse{i + 1}",

                    classe = new Classe
                    {
                        niveau = Filere.GLRS,
                        libelle = $"libelle{i + 1}"
                    },
                });
                cours.Add(new Cours
                {
                    datedebut = DateTime.UtcNow.AddHours(random.Next(-2, 2)),
                    datefin = DateTime.UtcNow.AddHours(random.Next(2, 6)),
                    NbreHoraire = DateTime.UtcNow,
                    semestre = Semestre.SEMESTRE1,
                    Professeur = enseignants[i],
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Classe = new Classe
                    {
                        niveau = Filere.GLRS,
                        libelle = $"libelle{i + 1}"
                    },
                    module = Module.Chimie,
                });
                absences.Add(new Absences
                {
                    date = DateTime.UtcNow,
                    cours = cours[i],
                    etudiant = etudiants[random.Next(etudiants.Count)],

                })
                ;


            }

            context.cours.AddRange(cours);
            context.absences.AddRange(absences);
            context.etudiant.AddRange(etudiants);
            context.professeur.AddRange(enseignants);

            context.SaveChanges();


        }
    }
}
