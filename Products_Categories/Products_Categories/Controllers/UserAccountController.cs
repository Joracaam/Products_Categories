using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Products_Categories.DataModels;

namespace Products_Categories.Controllers
{
    public class UserAccountController : Controller
    {
        private HBREntities db = new HBREntities();

        // GET: UserAccount
        public ActionResult Index()
        {
            return View(db.UserAccount.ToList());
        }

        [HttpPost]
        public ActionResult AccessToHome(UserAccount login)
        {
            var user = new UserAccount();

            user.UserName = login.UserName;
            user.Password = login.Password;

            if (Access(user) != null)
            {
                return RedirectToAction("Index","Product");
            }
            else
            {
                return RedirectToAction("Login","UserAccount");
            }
        }

        [HttpPost]
        public ActionResult CreateUser(UserAccount userAccount)
        {
            try
            {
                var newUser = new UserAccount()
                {
                    UserName = userAccount.UserName,
                    Password = userAccount.Password,
                    User_FirstName = userAccount.User_FirstName,
                    User_LastName = userAccount.User_LastName,
                    CreationDate = DateTime.Now,
                    Status = 1
                };

                if (ModelState.IsValid)
                {
                    db.UserAccount.Add(newUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: "+ex.Message);
                throw;
            }

            return View(userAccount);
        }

        public UserAccount Access(UserAccount user)
        {
            var localUser = new UserAccount();

            try
            {
                localUser = db.UserAccount.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return localUser;
        }

        // GET: UserAccount
        public ActionResult Login()
        {
            return View(db.UserAccount.ToList());
        }

        // GET: UserAccount
        public ActionResult Register()
        {
            return View(db.UserAccount.ToList());
        }

        // GET: UserAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAccountId,UserName,Password,Status,UserId,CreationDate,User_FirstName,User_LastName")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.CreationDate = DateTime.Now;
                db.UserAccount.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }

        // GET: UserAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAccountId,UserName,Password,Status,UserId,CreationDate,User_FirstName,User_LastName")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: UserAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = db.UserAccount.Find(id);
            db.UserAccount.Remove(userAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
