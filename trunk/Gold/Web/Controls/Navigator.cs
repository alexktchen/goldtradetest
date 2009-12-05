namespace GoldTradeNaming.Web.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Navigator : UserControl
    {
        protected Menu RightMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                MenuItem mt = null;
                mt = new MenuItem("\x00b7 返回首页", "", "", "~/franchiser_index.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 我的订单", "", "", "~/franchiser_order/Show.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 在线订货", "", "", "~/franchiser_order/Add_Type.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 我的交易", "", "", "~/franchiser_trade/Show.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 交易报表", "", "", "~/franchiser_trade/FranExcel.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 在线交易", "", "", "~/franchiser_trade/Add.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 收货记录", "", "", "~/send_main/myReceive.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 确认收货", "", "", "~/stock_main/receive.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 我的库存", "", "", "~/stock_main/franchiserStockShow.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 我的入帐", "", "", "~/franchiser_money/franchiserMoneyShow.aspx");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 修改密码", "", "", "javascript:window.showModalDialog('../User_Login/IA100edit.htm')");
                this.RightMenu.Items.Add(mt);
                mt = new MenuItem("\x00b7 退出系统", "", "", "~/User_Login/flogin.aspx");
                this.RightMenu.Items.Add(mt);
            }
        }
    }
}
