namespace ChartGptAspReactExamen.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public DateTime? OperationTime { get; set; }
        public string? Question { get; set; }
        public string? Ansever { get; set; }
        public DataModel() { }
        public DataModel(string name,DateTime date,string quest,string ans) 
        {
            Id = 0;
            Login = name;
            OperationTime = date;
            Question = quest;
            Ansever = ans;
        }
    }
}
