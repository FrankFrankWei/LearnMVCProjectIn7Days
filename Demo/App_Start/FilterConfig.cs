using Demo.Filters;
using System.Web;
using System.Web.Mvc;

namespace Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());// global authentication
            filters.Add(new HeaderFooterFilter());
        }
    }
}
