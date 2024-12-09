using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionScolaire.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelle = table.Column<string>(type: "text", nullable: false),
                    niveau = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professeur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    specialite = table.Column<string>(type: "text", nullable: false),
                    grade = table.Column<string>(type: "text", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professeur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "etudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    addresse = table.Column<string>(type: "text", nullable: false),
                    classeId = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_etudiant_classe_classeId",
                        column: x => x.classeId,
                        principalTable: "classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datedebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    datefin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NbreHoraire = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    semestre = table.Column<int>(type: "integer", nullable: false),
                    ProfesseurId = table.Column<int>(type: "integer", nullable: false),
                    ClasseId = table.Column<int>(type: "integer", nullable: false),
                    module = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cours_classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cours_professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "professeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "absences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etudiantId = table.Column<int>(type: "integer", nullable: false),
                    coursId = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_absences_cours_coursId",
                        column: x => x.coursId,
                        principalTable: "cours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_absences_etudiant_etudiantId",
                        column: x => x.etudiantId,
                        principalTable: "etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailsCours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coursId = table.Column<int>(type: "integer", nullable: false),
                    classeId = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailsCours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailsCours_classe_classeId",
                        column: x => x.classeId,
                        principalTable: "classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailsCours_cours_coursId",
                        column: x => x.coursId,
                        principalTable: "cours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_absences_coursId",
                table: "absences",
                column: "coursId");

            migrationBuilder.CreateIndex(
                name: "IX_absences_etudiantId",
                table: "absences",
                column: "etudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_cours_ClasseId",
                table: "cours",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_cours_ProfesseurId",
                table: "cours",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_detailsCours_classeId",
                table: "detailsCours",
                column: "classeId");

            migrationBuilder.CreateIndex(
                name: "IX_detailsCours_coursId",
                table: "detailsCours",
                column: "coursId");

            migrationBuilder.CreateIndex(
                name: "IX_etudiant_classeId",
                table: "etudiant",
                column: "classeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "absences");

            migrationBuilder.DropTable(
                name: "detailsCours");

            migrationBuilder.DropTable(
                name: "etudiant");

            migrationBuilder.DropTable(
                name: "cours");

            migrationBuilder.DropTable(
                name: "classe");

            migrationBuilder.DropTable(
                name: "professeur");
        }
    }
}
