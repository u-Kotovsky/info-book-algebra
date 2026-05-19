using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoBookAlgebraCore
{
    [Table("themes")]
    public class Theme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DeniedValues([null])]
        public string Name { get; set; }

        public Theme(string name)
        {
            Name = name;
        }
    }
}