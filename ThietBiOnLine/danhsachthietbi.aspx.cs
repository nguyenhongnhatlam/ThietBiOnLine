using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using ThietBiOnLine.Models;

namespace ThietBiOnLine
{
    public partial class danhsachthietbi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<ThietBi> GetBooks([QueryString("id")] int? categoryId)
        {
            var _db = new ThietBiOnLine.Models.ThietBiContext();
            IQueryable<ThietBi> query = _db.ThietBis;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.HangID == categoryId);
            }
            return query;
        }
    }
}