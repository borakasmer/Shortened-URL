using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace ShortLink.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Shorter()
        {
            return View();
        }
        public string ShortUrl(string Url)
        {
            string shortUrl = GetRandomUrl();
            using (UrlContext dbContext = new UrlContext())
            {
                Urls data = new Urls();
                data.ShortUrl = shortUrl;
                data.Url = Url;
                dbContext.Urls.Add(data);
                dbContext.SaveChanges();
                return shortUrl;
            }            
        }
        public void RedirectLink()
        {
            using (UrlContext dbContext = new UrlContext())
            {
                string url = Request["aspxerrorpath"]?.Replace("/", "");
                string longUrl = dbContext.Urls.Where(u => u.ShortUrl == url).Select(s => s.Url).FirstOrDefault().ToString();
                Response.RedirectPermanent(longUrl, true);
            }
        }
        public string GetRandomUrl()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}