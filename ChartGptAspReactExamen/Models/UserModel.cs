namespace ChartGptAspReactExamen.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(MyData data)
        {
            Id = 0;
            Login=data.Login;
            Password=data.Password;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? UnblockDate { get; set; }
        public string? Subscription { get; set; }
        
        public int? OperationCounter { get; set; }
    }
}
