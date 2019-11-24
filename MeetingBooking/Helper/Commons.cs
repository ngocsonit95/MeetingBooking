using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingBooking.Helper
{
  public static class Commons
  {
    public static string GetCurrentWebsiteRoot()
    {
      return HttpContext.Current.Request.Url.AbsolutePath;
    }

    public static string ActiveMenu(string action)
    {
      string path = GetCurrentWebsiteRoot().ToLower();
      if ((path == "/"&& action == "home"))
      {
        return "active";
      }
      else if ( path.Contains(action))
      {
        return "active";
      }
      else if (path.Contains("error")&& action=="move")
      {
        return "active";
      }
      else
        return string.Empty;
    }
  }
}
