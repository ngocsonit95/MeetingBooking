using MeetingBooking.Helper;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class UserController : Controller
  {
    // GET: User
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// Search
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="facultyID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult Search(string fullName, int? facultyID)
    {
      var model = new UserDao().ListUser(fullName, facultyID);
      return Json(model, JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// SearchAll
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="facultyID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult SearchAll(string fullName, int? facultyID)
    {
      var model = new UserDao().ListAllUser(fullName, facultyID);
      return Json(model, JsonRequestBehavior.AllowGet);
    }


    /// <summary>
    /// Login
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult Login(string username, string password)
    {
      var user = new UserDao().Login(username, password);
      if (user != null)
      {
        SessionUtility.User = user;
      }
      return Json(user, JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetAccountLogin
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAccountLogin()
    {
      if (SessionUtility.User != null)
      {
        return Json(new { User = SessionUtility.User, isSessionLogin = true }, JsonRequestBehavior.AllowGet);
      }
      else
      {
        return Json(new { isSessionLogin = false }, JsonRequestBehavior.AllowGet);
      }
    }

    /// <summary>
    /// Logout
    /// </summary>
    /// <returns></returns>
    public JsonResult Logout()
    {
      Session.Abandon();
      return Json(true,JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetAllUser
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAllUser()
    {
      return Json(new UserDao().GetAllUser(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetDetailUser
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDetailUser(string userID)
    {
      return Json(new UserDao().GetDetailUser(userID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetFacultyByUser
    /// </summary>
    /// <param name="facultyID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetFacultyByUser(int facultyID)
    {
      return Json(new UserDao().GetFacultyByUser(facultyID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// AddUser
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="fullName"></param>
    /// <param name="facultyID"></param>
    /// <param name="mobi"></param>
    /// <param name="email"></param>
    /// <param name="visible"></param>
    /// <param name="roles"></param>
    /// <param name="password"></param>
    /// <param name="avatar"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult AddUser(string userID, string fullName, int facultyID, string mobi, string email, bool? visible, bool? roles, string password, string avatar, string createBy)
    {
      return Json(new UserDao().AddUser(userID, fullName, facultyID, mobi, email, visible, roles, password, avatar, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// UpdateUserDetail
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="fullName"></param>
    /// <param name="facultyID"></param>
    /// <param name="mobi"></param>
    /// <param name="email"></param>
    /// <param name="visible"></param>
    /// <param name="roles"></param>
    /// <param name="avatar"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult UpdateUserDetail(string userID, string fullName, int facultyID, string mobi, string email, bool? visible, bool? roles, string avatar, string createBy)
    {
      return Json(new UserDao().UpdateUserDetail(userID, fullName, facultyID, mobi, email, visible, roles, avatar, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// ChangePass
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="password"></param>
    /// <param name="newPassword"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult ChangePass(string userID, string password, string newPassword, string createBy)
    {
      return Json(new UserDao().ChangePass(userID, password, newPassword, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// DeleteUser
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult DeleteUser(string userID)
    {
      return Json(new UserDao().DeleteUser(userID), JsonRequestBehavior.AllowGet);
    }


  }
}
