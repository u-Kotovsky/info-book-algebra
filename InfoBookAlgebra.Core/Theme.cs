using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoBookAlgebraCore
{
    public class Theme
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ThemeContentId { get; set; }

        public ThemeContent? Content { get; set; }
    }
}
