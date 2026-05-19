using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoBookAlgebraCore
{
    [Table("theme_contents")]
    public class ThemeContent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DeniedValues([null])]
        [MaxLength(65535)]
        public string Content { get; set; }

        public int ThemeId { get; set; }

        [ForeignKey(nameof(ThemeId))]
        public Theme Theme { get; set; }

        public ThemeContent(string content, int themeId)
        {
            Content = content;
            ThemeId = themeId;
        }
    }
}