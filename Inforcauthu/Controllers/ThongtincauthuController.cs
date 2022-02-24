using Inforcauthu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inforcauthu.Controllers
{
    public class ThongtincauthuController : Controller
    {
        private InforcauthuContext data = new InforcauthuContext();
        // GET: Thongtincauthu
        public ActionResult Index(bool? gift, int? page)
        {
            var thongtin = data.Thongtincauthus.ToList();
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
            var result = thongtin.OrderBy(x => x.ID).Skip(paging ?? 1).Take(pagesize);
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
        public string Upload(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../imagect/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate()
        {
            var thongtin = data.Doibongs.ToList();
            return View(thongtin);
        }
        [ValidateInput(false)]
        public ActionResult Create(string namect, DateTime tuoict, string datnuoc, string thehinh, string luongct, string giatrict,string chitietcauthu, HttpPostedFileBase anhct,int iddoibong)
        {
            Thongtincauthu item = new Thongtincauthu();
            item.IDdoibongcauthu = iddoibong;
            item.Name = namect;
            item.Age = tuoict;
            item.Country = datnuoc;
            item.inforcaothap = thehinh;
            item.Salary = luongct;
            item.Value = giatrict;
            item.infor = chitietcauthu;
            item.Image = Upload(anhct);
            data.Thongtincauthus.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index", new { gift = true});
        }
        public ActionResult Search(string search) 
        {
            var result = data.Thongtincauthus.Where(x => x.Name.Contains(search)).Select(x => x).ToList();
            return View(result);
        }
        public ActionResult Remove(int idd) 
        {
            var item = data.Thongtincauthus.Find(idd);
            data.Thongtincauthus.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult detail(int id) 
        {
            var item = data.Thongtincauthus.Find(id);
            return View(item);
        }
        public ActionResult Viewupdate(int id) 
        {
            var update = data.Thongtincauthus.Find(id);
            return View(update);
        }
        [ValidateInput(false)]
        public ActionResult Update(int iddb,string namectt, DateTime tuoictt, string datnuocc,string thehinhh,string chitietcauthu1, string luongctt, string giatrictt , HttpPostedFileBase anhctt) 
        {
            Thongtincauthu item = new Thongtincauthu();
            item.ID = iddb;
            item.Name = namectt;
            item.Age = tuoictt;
            item.Country = datnuocc;
            item.inforcaothap = thehinhh;
            item.infor = chitietcauthu1;
            item.Salary = luongctt;
            item.Value = giatrictt;
            item.Image = Upload(anhctt);
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}