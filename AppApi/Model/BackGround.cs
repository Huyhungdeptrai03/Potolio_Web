using System.ComponentModel.DataAnnotations;

namespace AppApi.Model
{
    public class BackGround
    {
        [Key]
        public int Id_BackGroud { get; set; }

        public string BackGround_Image { get; set; }
    }
}
