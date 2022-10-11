namespace react_minapi.dataAccess.Models
{
    public  class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email  { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
