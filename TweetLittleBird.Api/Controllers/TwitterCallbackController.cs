using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TweetLittleBird.Api.Models;

namespace TweetLittleBird.Api.Controllers
{
    public class TwitterCallbackController : Controller
    {
        //
        // GET: /TwitterCallback/

        public ActionResult Index()
        {
            var twitterInfo = GetTwitterInfo();
            HttpContext.Application["TwitterInfo"] = twitterInfo;
            var twitterCallbackViewModel = new TwitterCallbackViewModel
                {
                    TwitterInfo = twitterInfo
                };
            return View(twitterCallbackViewModel);
        }

        //
        // GET: /TwitterCallback/Details/5

        public ActionResult Details(int id)
        {
            var twitterInfo = (string) HttpContext.Application["TwitterInfo"];
            var twitterCallbackViewModel = new TwitterCallbackViewModel
            {
                TwitterInfo = twitterInfo
            };
            return View(twitterCallbackViewModel);
        }

        private string GetTwitterInfo()
        {
            var twitterInfoStringBuilder = new StringBuilder();
            foreach (var key in Request.Headers.AllKeys)
            {
                twitterInfoStringBuilder
                    .Append("|").Append(key).Append("=").Append(Request.Headers.Get(key)).Append("|").Append(Environment.NewLine);
            }
            twitterInfoStringBuilder
                .Append("|Url=").Append(Request.Url).Append("|").Append(Environment.NewLine)
                .Append("|RawUrl=").Append(Request.RawUrl).Append("|").Append(Environment.NewLine)
                .Append("|UrlReferrer=").Append(Request.UrlReferrer).Append("|").Append(Environment.NewLine);

            foreach (var key in Request.Params.AllKeys)
            {
                twitterInfoStringBuilder
                    .Append("|").Append(key).Append("=").Append(Request.Headers.Get(Request.Params[key])).Append("|").Append(Environment.NewLine);
            }
            var twitterInfo = twitterInfoStringBuilder.ToString();
            return twitterInfo;
        }
    }
}
