using Max.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Framework;

namespace Max.Web.Helpers
{
    public class MenuHelper
    {
        public static void UpdateMenuName(IEnumerable<SYS_Action> menuList)
        {
            foreach (var item in menuList)
            {
                if (!item.ParentId.IsNullOrEmpty())
                {
                    var times = item.LevelSort.Length - item.LevelSort.Replace("-", "").Length;
                    item.ActionName = "".PadLeft(times / 2, '　') + "|--" + item.ActionName;
                }
            }
        }
    }
}