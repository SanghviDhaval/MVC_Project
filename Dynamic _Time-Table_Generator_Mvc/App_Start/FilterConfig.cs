using System.Web;
using System.Web.Mvc;

namespace Dynamic__Time_Table_Generator_Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
