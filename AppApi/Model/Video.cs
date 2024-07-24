using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppApi.Model
{
    public class Video
    {
        [Key]
        public int Id_Video { get; set; }

        public int Stt { get; set; }

        public string Title { get; set; }
        public string Video_Links { get; set; }

       

        //khoá ngoại với categories

        [ForeignKey("Id_Categories")]

        //mối quan hệ 1-n với categories
        public int Id_Categories { get; set; }

        public virtual Categories Categories { get; set; }

    }
}
