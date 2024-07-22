using System.ComponentModel.DataAnnotations;

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


        //mối quan hệ 1-n với categories
        public int Id_Categories { get; set; }

        public Categories Categories { get; set; }

    }
}
