
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.SpielerEntity
{
    [Table("Player")]
    public class Player
    {
       
        public Player()
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public String Spitzname{ get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public String Nachname { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public String Voname { get; set; }

    }
}
