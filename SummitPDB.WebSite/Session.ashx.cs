using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SummitPDB.WebSite
{
    /// <summary>
    /// Summary description for Session
    /// </summary>
    public class Session : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "application/x-javascript";
            context.Response.Write("//");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}