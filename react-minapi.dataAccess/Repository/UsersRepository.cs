using react_minapi.dataAccess.Models;

namespace react_minapi.dataAccess.Repository
{
    public class UserRepository
    {
        public RunningContext dbContext { get; set; }

        public UserRepository(RunningContext runningContext)
        {
            dbContext = runningContext;
        }

        public IEnumerable<User> Get() =>dbContext.Users.ToArray();

        public User Get(int id) => dbContext.Users.FirstOrDefault(c => c.Id == id);

        public User Create(User User)
        {
            dbContext.Users.Add(User);
           dbContext.SaveChanges();
            return User;
        }

        public void Delete(User User)
        {
            dbContext.Users.Remove(User);
            dbContext.SaveChanges();
        }
    }
}
