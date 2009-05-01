using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace GoldTradeNaming.Web
{
    public partial class gold_AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ////随机数生成
            Random randomGenerator = new Random(DateTime.Now.Millisecond);
            String RndStr = "";
            for (int i = 0; i < 32; i++)
                RndStr += Convert.ToChar(randomGenerator.Next(97, 122));
            Session["Message"] = RndStr;
            //this.TextBox1.Text = Session["Message"].ToString();
            
        }
    }
}
