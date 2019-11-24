using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
    public class FacultyController : Controller
    {

    /// <summary>
    /// GetAllFaculty
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAllFaculty()
    {
      return Json(new FacultyDao().GetAllFaculty(), JsonRequestBehavior.AllowGet);
    }


    /// <summary>
    /// GetListFaculty
    /// </summary>
    /// <returns></returns>
    public JsonResult GetListFaculty()
    {
      return Json(new FacultyDao().GetListFaculty(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// AddFaculty
    /// </summary>
    /// <param name="facultyName"></param>
    /// <param name="avatar"></param>
    /// <param name="desc"></param>
    /// <param name="visible"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult AddFaculty(string facultyName, string avatar, string desc, bool? visible, string createBy)
    {
      return Json(new FacultyDao().AddFaculty(facultyName, avatar, desc, visible, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetDetailFaculty
    /// </summary>
    /// <param name="FacultyID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDetailFaculty(int FacultyID)
    {
      return Json(new FacultyDao().GetDetailFaculty(FacultyID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// UpdateFaculty
    /// </summary>
    /// <param name="FacultyID"></param>
    /// <param name="facultyName"></param>
    /// <param name="avatar"></param>
    /// <param name="desc"></param>
    /// <param name="visible"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult UpdateFaculty(int FacultyID, string facultyName, string avatar, string desc, bool? visible, string createBy)
    {
      return Json(new FacultyDao().UpdateFaculty(FacultyID, facultyName, avatar, desc, visible, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// DeleteFaculty
    /// </summary>
    /// <param name="FacultyID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult DeleteFaculty(int FacultyID)
    {
      return Json(new FacultyDao().DeleteFaculty(FacultyID), JsonRequestBehavior.AllowGet);
    }
  }
}
