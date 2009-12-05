namespace GoldTradeNaming.Web.Controls
{
    using GoldTradeNaming.BLL;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class CheckRight : UserControl
    {
        protected Menu RightMenu;

        private DataTable GetRightList(int adminId)
        {
            sys_admin_authority bll = new sys_admin_authority();
            return bll.GetRightSet(adminId);
        }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    MenuItem mt = null;
                    mt = new MenuItem("\x00b7 返回首页", "", "", "~/goldAdminIndex.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 订单确认", "", "", "~/franchiser_order/Modify.aspx?type=1");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 在线发货", "", "", "~/send_main/Show.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 查看交易", "", "", "~/franchiser_trade/ShowM.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 交易报表", "", "", "~/franchiser_trade/AdminExcel.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 经销商报表", "", "", "~/franchiser_info/franReport.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 产品库存报表", "", "", "~/stock_main/StockExcel.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 修改实时金价", "", "", "~/realtime_price/Add.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 新增入帐", "", "", "~/franchiser_money/Add.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 修改库存", "", "", "~/stock_main/Show.aspx");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 修改密码", "", "", "javascript:window.showModalDialog('../User_Login/IA100edit.htm')");
                    this.RightMenu.Items.Add(mt);
                    mt = new MenuItem("\x00b7 退出系统", "", "", "~/User_Login/AdminLogin.aspx");
                    this.RightMenu.Items.Add(mt);
                }
                catch
                {
                    base.Response.Clear();
                    base.Response.Write("<script defer>window.alert('菜单加载出错');history.back();</script>");
                    base.Response.End();
                }
            }
        }
    }
}
