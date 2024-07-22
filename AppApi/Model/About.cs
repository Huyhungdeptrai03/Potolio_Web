using System.ComponentModel.DataAnnotations;

namespace AppApi.Model
{
    public class About
    {
        [Key] 
        public int Id_About { get; set; }

        public string About_Image { get; set; }
    }
}
