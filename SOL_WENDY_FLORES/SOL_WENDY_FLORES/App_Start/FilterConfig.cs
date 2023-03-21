using System.Web;
using System.Web.Mvc;

namespace SOL_WENDY_FLORES
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
