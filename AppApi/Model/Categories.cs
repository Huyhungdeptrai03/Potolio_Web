using System.ComponentModel.DataAnnotations;

namespace AppApi.Model
{
    public class Categories
    {
        [Key]
        public int Id_Categories { get; set; }

        public string Name { get; set; }

        //mối quan hệ 1-n với video
        public ICollection<Video> Videos { get; set; } = new List<Video>();

        

    }
}
