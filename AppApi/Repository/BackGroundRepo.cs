
using AppApi.IRepository;
using AppApi.Model;


namespace AppApi.Repository
{
    public class BackGroundRepo : IBackGroundsRepo
    {
        private readonly AppDbContext _context;

        public BackGroundRepo(AppDbContext context)
        {
            _context = context;
        }
        public BackGround AddBackGround(BackGround backGround)
        {
            try
            {

                _context.BackGrounds.Add(backGround);
                _context.SaveChanges();
                return backGround;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BackGround DeleteBackGround(int id)
        {
            var backGround = _context.BackGrounds.Find(id);
            try
            {
                if (backGround != null)
                {
                    _context.BackGrounds.Remove(backGround);
                    _context.SaveChanges();

                }
                return backGround;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<BackGround> GetAllBackGrounds()
        {
            return _context.BackGrounds.ToList();
        }

        public BackGround GetBackGroundById(int id)
        {
            return _context.BackGrounds.Find(id);
        }

        public BackGround UpdateBackGround(BackGround backGround)
        {
            try
            {
                var bg = _context.BackGrounds.Find(backGround.Id_BackGroud);
                if (bg != null)
                {
                    bg.Id_BackGroud = backGround.Id_BackGroud;
                    bg.BackGround_Image = backGround.BackGround_Image;
                    _context.Update(bg);
                    _context.SaveChanges();
                }
                return bg;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
