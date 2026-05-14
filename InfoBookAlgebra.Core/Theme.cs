using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoBookAlgebraCore
{
    public class Theme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public void OnSelect()
        {
            throw new Exception("YayI was selected " + Name);
        }
    }
}
