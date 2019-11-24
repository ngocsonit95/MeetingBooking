using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class ListAreaController : Controller
  {

    /// <summary>
    /// GetAllArea
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAllArea()
    {
      return Json(new AreaDao().GetAllArea(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetListArea
    /// </summary>
    /// <returns></returns>
    public JsonResult GetListArea()
    {
      return Json(new AreaDao().GetListArea(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// AddArea
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="avatar"></param>
    /// <param name="desc"></param>
    /// <param name="visible"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    public JsonResult AddArea(string areaName, string avatar, string desc, bool? visible, string createBy)
    {
      return Json(new AreaDao().AddArea(areaName, avatar, desc, visible, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetDetailArea
    /// </summary>
    /// <param name="AreaID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDetailArea(int AreaID)
    {
      return Json(new AreaDao().GetDetailArea(AreaID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// UpdateArea
    /// </summary>
    /// <param name="areaID"></param>
    /// <param name="areaName"></param>
    /// <param name="avatar"></param>
    /// <param name="desc"></param>
    /// <param name="visible"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult UpdateArea(int areaID, string areaName, string avatar, string desc, bool? visible, string createBy)
    {
      return Json(new AreaDao().UpdateArea(areaID, areaName, avatar, desc, visible, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// DeleteArea
    /// </summary>
    /// <param name="AreaID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult DeleteArea(int AreaID)
    {
      return Json(new AreaDao().DeleteArea(AreaID), JsonRequestBehavior.AllowGet);
    }
  }
}
