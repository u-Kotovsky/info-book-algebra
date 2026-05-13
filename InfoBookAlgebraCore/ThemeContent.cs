using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InfoBookAlgebraCore
{
    public class ThemeContent
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(65535)]
        public string Content { get; set; }

        public int ThemeId { get; set; }

        public Theme? Theme { get; set; }
    }
}
