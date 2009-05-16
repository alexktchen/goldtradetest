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

namespace GoldTradeNaming.Web.Controls
{
    public partial class Navigator : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuItem mt = null;

                mt = new MenuItem("· 返回首页", "", "", "~/franchiser_index.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 我的订单", "", "", "~/franchiser_order/Show.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 在线订货", "", "", "~/franchiser_order/Add_Type.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 我的交易", "", "", "~/franchiser_trade/Show.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 在线交易", "", "", "~/franchiser_trade/Add.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 收货记录", "", "", "~/send_main/myReceive.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 确认收货", "", "", "~/stock_main/receive.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 我的库存", "", "", "~/stock_main/franchiserStockShow.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 我的入帐", "", "", "~/franchiser_money/franchiserMoneyShow.aspx");
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 修改密码", "", "", "javascript:window.showModalDialog('../User_Login/IA100edit.htm')");   
                this.RightMenu.Items.Add(mt);

                mt = new MenuItem("· 退出系统", "", "", "~/User_Login/flogin.aspx");
                this.RightMenu.Items.Add(mt);
            }
        }
    }
}