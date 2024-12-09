using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestionScolaire.Models
{
    public abstract class AbstractEntity
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("createat")]
        public DateTime? CreateAt { get; set; }

        [Column("updateat")]
        public DateTime? UpdateAt { get; set; }

        // Association Many-to-One pour UserCreate







        public void OnPrePersist()
        {
            CreateAt = DateTime.UtcNow;

            Console.WriteLine($"CreateAt: {CreateAt}, UpdateAt: {UpdateAt}");
        }

        public void OnPreUpdate()
        {
            UpdateAt = DateTime.Now;
        }
    }
}
