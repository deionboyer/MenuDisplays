using System.Configuration;

namespace MenuItems.DataAccess.Controller
{
    public abstract class Controller
    {
        protected string sqlConnectionString = ConfigurationManager.ConnectionStrings["MenuItems"].ConnectionString;
    }
}
