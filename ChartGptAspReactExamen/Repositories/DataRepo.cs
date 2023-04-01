using ChartGptAspReactExamen.Models;

namespace ChartGptAspReactExamen.Repositories
{
    public class DataRepo
    {
        string pathDir = Directory.GetCurrentDirectory() + "/Images/";
        Context context = new Context();
        public void AddData(string name, DateTime date, string quest, string ans)
        {
            context.DataModels.Add(new DataModel(name, date, quest, ans ));
            context.SaveChanges();
        }
        public string RandomName(string extenc)
        {
            while (true)
            {
                string name = Path.GetRandomFileName();
                string fileName = pathDir + name + extenc;
                if (!System.IO.File.Exists(fileName))
                {
                    return fileName;
                }
            }
        }
        public IEnumerable<DataModel>GetHistory(string login)=> context.DataModels.Where(e=>e.Login==login);
        public void SetOperationIncrement(string name)
        {
            context.UserModels.FirstOrDefault(e=>e.Login==name).OperationCounter+=1;
            context.SaveChanges();
        }
        
    }
}
