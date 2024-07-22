



using AppApi.Model;

namespace AppApi.IRepository
{
    public interface IVideosRepo
    {
        IEnumerable<Video> GetAllVideos();

        Video GetVideoById(int id);

        Video AddVideo(Video video);

        Video UpdateVideo(Video video);

        Video DeleteVideo(int id);
    }
}
