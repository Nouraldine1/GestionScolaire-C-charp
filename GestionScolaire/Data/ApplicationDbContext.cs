using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionScolaire.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);
    }


    public DbSet<gestionecole.Models.Classe> classe { get; set; } = default!;

    public DbSet<gestionecole.Models.Cours> cours { get; set; } = default!;

    public DbSet<gestionecole.Models.DetailCours> detailsCours { get; set; } = default!;

    public DbSet<gestionecole.Models.Etudiant> etudiant { get; set; } = default!;

    public DbSet<gestionecole.Models.Absences> absences { get; set; } = default!;

    public DbSet<gestionecole.Models.Professeur> professeur { get; set; } = default!;




}
