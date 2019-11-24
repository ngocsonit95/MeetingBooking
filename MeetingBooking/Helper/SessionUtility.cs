using MeetingBooking.Models;
using Model.EF;
using Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingBooking.Helper
{
  public static class SessionUtility
  {
    public static UserSession User
    {
      get
      {
        return HttpContext.Current.Session["User"] as UserSession;
      }
      set
      {
        HttpContext.Current.Session["User"] = value;
      }
    }

    //Multi langue create by Son IT
    //public static string CurrentCulture { get; set; }

    public static string CurrentCulture
    {
      get
      {
        if (HttpContext.Current.Session["CurrentCulture"] == null)
        {
          HttpContext.Current.Session["CurrentCulture"] = "vi";
        }

        return HttpContext.Current.Session["CurrentCulture"].ToSafetyString();
      }
      set
      {
        HttpContext.Current.Session["CurrentCulture"] = value;
      }
    }
  }
}
