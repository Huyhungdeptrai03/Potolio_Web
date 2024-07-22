
using AppApi.IRepository;
using AppApi.Model;


namespace AppApi.Repository
{
    public class VideoRepo : IVideosRepo
    {
        private readonly AppDbContext _context;

        public VideoRepo(AppDbContext dBContext)
        {
            _context = dBContext;
        }
        public Video AddVideo(Video video)
        {
            try
            {
                _context.Videos.Add(video);
                _context.SaveChanges();
                return video;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Video DeleteVideo(int id)
        {
            var video = _context.Videos.Find(id);
            try
            {
                if(video != null)
                {
                    _context.Videos.Remove(video);
                    _context.SaveChanges();
                }
                return video;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _context.Videos.ToList();
        }

        public Video GetVideoById(int id)
        {
            return _context.Videos.Find(id);
        }

        public Video UpdateVideo(Video video)
        {
            try
            {
                var videoExist = _context.Videos.Find(video.Id_Video);
                if (videoExist != null)
                {
                   
                    videoExist.Stt = video.Stt;
                    videoExist.Title = video.Title;
                    videoExist.Video_Links = video.Video_Links;
                    videoExist.Id_Categories = video.Id_Categories;
                    videoExist.Categories = video.Categories;

                    _context.Videos.Update(videoExist);
                    _context.SaveChanges();
                }
                return videoExist;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
