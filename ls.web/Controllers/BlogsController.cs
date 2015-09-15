using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ls.context;
using ls.data.models;
using ls.service.Int;
using ls.data.dtos;
using ls.common;

namespace ls.web.Controllers
{
    public class BlogsController : Controller
    {
        public IBlogService blogService { get; set; }

        // GET: Blogs
        public ActionResult Index()
        {
            return View(blogService.Blogs.ToList());
        }

        //// GET: Blogs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Blog blog = db.Blogs.Find(id);
        //    if (blog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blog);
        //}

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title")] BlogDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = blogService.Add(dto);
               
                if (result.ResultType == OperationResultType.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }

            return View(dto);
        }

        //// GET: Blogs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Blog blog = db.Blogs.Find(id);
        //    if (blog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blog);
        //}

        //// POST: Blogs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,title")] Blog blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blog).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blog);
        //}

        //// GET: Blogs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Blog blog = db.Blogs.Find(id);
        //    if (blog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blog);
        //}

        //// POST: Blogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Blog blog = db.Blogs.Find(id);
        //    db.Blogs.Remove(blog);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
