﻿using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

       

        public ActionResult Index()
        {
            var egitim = repo.List();

            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim=repo.Find(x=>x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim t)
        {
            var e = repo.Find(x => x.ID == t.ID);
            e.Baslik = t.Baslik;
            e.AltBaslik1 = t.AltBaslik1;
            e.AltBaslik2 = t.AltBaslik2;
            e.GNO = t.GNO;
            e.Tarih = t.Tarih;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}