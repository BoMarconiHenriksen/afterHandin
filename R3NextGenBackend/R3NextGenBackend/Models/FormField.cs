using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendNextGen.Models
{
    public class FormField
    {
        public FormField()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Headline { get; set; }

        public bool Static { get; set; }

        [ForeignKey("Form")]
        public long FormId { get; set; }
        public Form Form { get; set; }

        public Component Component { get; set; }
    }
}

