using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class HelloWorldController : Controller
    { 
        // GET: /HelloWorld/
        public string Index()
        {
            return "Bui Thi Ha Vi 2221050783";
        } 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "Bui Thi Ha Vi 2221050783";
        }
    }
}
