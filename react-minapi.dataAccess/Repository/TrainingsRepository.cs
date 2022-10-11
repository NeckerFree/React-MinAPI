using react_minapi.dataAccess.Models;

namespace react_minapi.dataAccess.Repository
{
    public class TrainingRepository
    {
        public RunningContext dbContext { get; set; }

        public TrainingRepository(RunningContext runningContext)
        {
            dbContext = runningContext;
        }

        public IEnumerable<Training> Get() =>dbContext.Trainings.ToArray();

        public Training Get(int id) => dbContext.Trainings.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Training> GetByUser(int userId) => dbContext.Trainings.Where(c => c.UserId == userId);
        public Training Create(Training Training)
        {
            dbContext.Trainings.Add(Training);
           dbContext.SaveChanges();
            return Training;
        }

        public void Delete(Training Training)
        {
            dbContext.Trainings.Remove(Training);
            dbContext.SaveChanges();
        }
    }
}
