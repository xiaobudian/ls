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
using ls.data.query;

namespace ls.web.Controllers
{
    public class BlogsController : Controller
    {
        public IBlogService blogService { get; set; }

        [HttpPost]
        public JsonResult QueryData(BlogQueryInfo bqi)
        {
            var result = blogService.QueryData(bqi);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Blogs
        public ActionResult Index()
        {
            return View(blogService.Entities.ToList());
        }


        public ActionResult PagedIndex(string title, int pageIndex = 1)
        {
            ViewBag.blogtitle = title;
            var dto = blogService.QueryData(new BlogQueryInfo { PageIndex = pageIndex, title = title });
            return View(dto);
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dto = blogService.GetByKey(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            return View(dto);
        }

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

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogDto dto = blogService.GetByKey(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            return View(dto);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title")] BlogDto dto)
        {
            if (ModelState.IsValid)
            {
                blogService.Update(dto);

                return RedirectToAction("Index");
            }
            return View(dto);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogDto dto = blogService.GetByKey(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            return View(dto);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = blogService.Delete(id);
            if (result.ResultType == OperationResultType.Success)
            {
                return RedirectToAction("Index");
            }
            return View("Delete", blogService.GetByKey(id));
        }

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
