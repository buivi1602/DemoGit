using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class HelloWorldController : Controller
    { 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        } 
        // GET: /HelloWorld/Welcome/ 
        [HttpPost]
public IActionResult Index(string FullName, string Address)
{
    string strOutput = "Xin chào " + FullName + " đến từ " + Address;
    ViewBag.Message = strOutput;
    return View();
}
        
        public string Welcome()
        {
            return "Bui Thi Ha Vi 2221050783";
        }
    }
}
