namespace ChartGptAspReactExamen.Models
{
    public class MyData
    {
        public MyData() { }
        public MyData(string log,string pass)
        {
            Login = log;
            Password = pass;
            
        }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
