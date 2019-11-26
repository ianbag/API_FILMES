using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_FILMES.Models
{
    public class MovieDetail
    {
        [Key]
        public int MVId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Genero { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataLancamento { get; set; }

        
    }
}
