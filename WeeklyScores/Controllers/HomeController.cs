using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace WeeklyScores.Controllers
{
    public class HomeController : Controller
    {
        private const string scrapeUrlHome = "http://tr.beinsports.com/topnavigation/topnavigation";
        // GET: Home
        public ActionResult Index()
        {
            GetLeagues();

            return View();
        }

        private void GetLeagues()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-9")
            };
            HtmlDocument doc = web.Load(scrapeUrlHome);

            var leagues = doc.DocumentNode.SelectNodes("//ul[@class='sf-menu']//li[@data-item-text='FUTBOL']//div[@class='submenuC']//ul//li");

            //hafta seçimleri
            doc = web.Load("http://tr.beinsports.com/lig/spor-toto-super-lig/puan-durumu");
            var score = doc.DocumentNode.SelectNodes("//div[@class='selections']//div[@class='selector r']//select[@id='selector_week_standings_content']//option");

        }
    }
}