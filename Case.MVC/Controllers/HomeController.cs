using Case.MVC.Hubs;
using Case.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case.MVC.Controllers
{
    public class HomeController : Controller
    {
        CaseDbContext context = new CaseDbContext();
        // GET: Home
        public ActionResult Index()
        {
            RssParser.RssParserClient proxy = new RssParser.RssParserClient();
            var list = proxy.ParseFromPage("http://www.milliyet.com.tr/default.aspx?aType=Rss");
            return View();
        }


        //MUST ENABLE THE BROKER TO GET GOING
        //ALTER DATABASE "database name" SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE ;


        public ActionResult GetData()
        {
            //by using listener method we manage a recursive ajax request
            DatabaseListener listen = new DatabaseListener();
            listen.Listener();
            //Should use the model for complex data
            IEnumerable<RssPage> list = context.RssPage.ToList();
            return PartialView(list);
        }
    }
}