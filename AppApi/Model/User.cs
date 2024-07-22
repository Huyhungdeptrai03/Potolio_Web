using System.ComponentModel.DataAnnotations;

namespace AppApi.Model
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
