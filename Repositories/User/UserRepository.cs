using HR_System.Models;

namespace HR_System.Repositories.User
{
    public class UserRepository:IUserRepository
    {
        private readonly HREntity hREntity;
        public UserRepository(HREntity hREntity) => this.hREntity = hREntity;
        
        public List<Models.User> GetAll()
        {
            return hREntity.Users.Where(u=>u.IsDeleted==false).ToList();
        }
        public Models.User GetByUsername(string username) 
        {
            return hREntity.Users.FirstOrDefault(u => u.Username == username && u.IsDeleted==false);
        }
        public void Insert(Models.User NewUser)
        {
            hREntity.Users.Add(NewUser);
            hREntity.SaveChanges();
        }
        public void Update(Models.User UpdateUSer) {
            hREntity.Users.Update(UpdateUSer);
            hREntity.SaveChanges();
        }
        public void Delete(string username)
        {
            var old = GetByUsername(username);
            if(old != null)
            {
                old.IsDeleted = false;
            }
        }

    }
}
