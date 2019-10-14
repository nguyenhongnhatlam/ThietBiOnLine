using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThietBiOnLine.Models;
using System.Web.ModelBinding;

namespace ThietBiOnLine
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<ThietBi> GetDetails([QueryString("bookID")] int? bookId)
        {
            var _db = new ThietBiOnLine.Models.ThietBiContext();
            IQueryable<ThietBi> query = _db.ThietBis;
            if (bookId.HasValue && bookId > 0)
            {
                query = query.Where(p => p.ThietBiID == bookId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}