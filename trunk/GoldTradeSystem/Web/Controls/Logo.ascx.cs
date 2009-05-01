using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GoldTradeNaming.BLL;

namespace GoldTradeNaming.Web.Controls
{
    public partial class Logo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CommBaseBLL bll = new CommBaseBLL();
                    //select realtime_base_price,order_add_price,trade_add_price,r
                    DataSet dsPrice = bll.getCurrentPrice();
                    this.lblPrice.Text = dsPrice.Tables[0].Rows[0][0].ToString();
                    this.lblDateNow.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                }
                catch
                {
                    this.lblPrice.Text = "0.00";
                    this.lblDateNow.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                
                }
            }
        }
    }
}