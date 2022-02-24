using Inforcauthu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inforcauthu.Controllers
{
    public class doibongController : Controller
    {

        private InforcauthuContext data = new InforcauthuContext();
        // GET: doibong
        public ActionResult Index(bool? gift, int? page)
        {
            var thongtin = data.Doibongs.ToList();
            if(gift == true) 
            {
                ViewBag.Thongdiep = true;
            }
            var pagesize = 3;
            if(page == null) 
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.IDclub).Skip(paging ?? 1).Take(pagesize);
            var numberpage = 0;
            if(totall % pagesize == 0) 
            {
                numberpage = totall / pagesize;
            }
            else 
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;
            return View(result.ToList());
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(string tenclb,string namthanhlapp,string boss,string fanclb,string chitietclbb,HttpPostedFileBase logoclb) 
        {
            doibong item = new doibong();
            item.Nameclub = tenclb;
            item.Namthanhlap = namthanhlapp;
            item.Chutichclb = boss;
            item.fan = fanclb;
            item.chitietclb = chitietclbb;
            item.logo = Uploadlogo(logoclb);
            data.Doibongs.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index", new { gift = true });
        }
        public string Uploadlogo(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../logoclb/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Remove(int id) 
        {
            var item = data.Doibongs.Find(id);
            data.Doibongs.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id) 
        {
            var item = data.Doibongs.Find(id);
            return View(item);
        }
        public ActionResult Search(string search) 
        {
            var result = data.Doibongs.Where(x => x.Nameclub.Contains(search)).Select(x => x).ToList();
            return View(result);
        }
        public ActionResult Viewupdate(int id) 
        {
            var up = data.Doibongs.Find(id);
            return View(up);
        }
        public ActionResult Update(int ma,string tenclbb, string namthanhlappp, string bosss, string fanclbb, string chitietclbb1, HttpPostedFileBase logoclbb) 
        {
            doibong item = new doibong();
            item.IDclub = ma;
            item.Nameclub = tenclbb;
            item.Namthanhlap = namthanhlappp;
            item.Chutichclb = bosss;
            item.fan = fanclbb;
            item.chitietclb = chitietclbb1;
            item.logo = Uploadlogo(logoclbb);
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}