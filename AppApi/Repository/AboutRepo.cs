
using AppApi.IRepository;
using AppApi.Model;



namespace AppApi.Repository
{
    public class AboutRepo : IAboutsRepos
    {
        private readonly AppDbContext _context;

        public AboutRepo(AppDbContext dBContext)
        {
            _context = dBContext;
        }
        public About AddAbout(About about)
        {
            try
            {
                _context.Abouts.Add(about);
                _context.SaveChanges();
                return about;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public About DeleteAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            try
            {
                if (about != null)
                {
                    _context.Abouts.Remove(about);
                    _context.SaveChanges();
                }
                return about;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public About GetAboutById(int id)
        {
            return _context.Abouts.Find(id);
        }

        public IEnumerable<About> GetAllAbouts()
        {
            return _context.Abouts.ToList();
        }

        public About UpdateAbout(About about)
        {
            try
            {

                var _about = _context.Abouts.Find(about.Id_About);
                if (_about != null)
                {
                    _about.Id_About = about.Id_About;
                    _about.About_Image = about.About_Image;
                    _context.Abouts.Update(_about);
                    _context.SaveChanges();
                    
                }
                return about;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
