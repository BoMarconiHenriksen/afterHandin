using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BackendNextGen.Models
{

    public class Form
    {
        public Form()
        {
            CompletedForms = new HashSet<CompletedForm>();
            FormFields = new HashSet<FormField>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<CompletedForm> CompletedForms { get; set; }
        public ICollection<FormField> FormFields { get; set; }
    }

}
