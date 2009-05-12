using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace GoldTradeNaming.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        //public static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //i += 1;
            //this.lblTitle.Text = i.ToString();
            //if (Session["admin"] == null)
            //    Session["admin"] = "Master";
            ////Session["admin"] = Session["admin"].ToString() + "  Default ";
            //Session["admin"] = Session["admin"]+"Master";
            //this.lblTitle.Text = Session["admin"].ToString();
        }



        private int GetAdminRight(int adminid)
        {
            return 1;
        }
    }
}
