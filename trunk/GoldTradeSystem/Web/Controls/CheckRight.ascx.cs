namespace GoldTradeNaming.Web.Controls
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using LTP.Accounts.Bus;
    using System.Configuration;
    using System.Web.Security;
    using System.Collections.Generic;

    using GoldTradeNaming.Web.goldtrade_db_admin;

    /// <summary>
    ///	CheckRight 的摘要说明。
    /// </summary>
    public partial class CheckRight : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {            
                        MenuItem mt = null;

                        mt = new MenuItem("· 库存管理", "", "", "~/stock_main/Show.aspx");                      
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 订单确认", "", "", "~/franchiser_order/Modify.aspx?type=1");                       
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 在线发货", "", "", "~/send_main/Show.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 查看交易", "", "", "~/franchiser_trade/ShowM.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 修改实时金价", "", "", "~/realtime_price/Add.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 新增入帐", "", "", "~/franchiser_money/Add.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 修改密码", "", "", "~/User_Login/IA100edit.htm");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("· 退出系统", "", "", "~/User_Login/AdminLogin.aspx");
                        this.RightMenu.Items.Add(mt);


                    }

                    #region oldway
                    /*
                        DataTable tblRight = this.GetRightList(Convert.ToInt32(Session["admin"]));
                        if (tblRight == null || tblRight.Rows.Count <= 0)
                        {
                            Response.Clear();
                            Response.Write("<script defer>window.alert('" + goldtrade_db_adminRes.strNoRigthIntoSystem + "');history.back();</script>");
                            Response.End();
                        }
                        else
                        {
                            MenuItem mt = null;
                            for (int i = 0; i < tblRight.Rows.Count; i++)
                            {
                                string rightstr = tblRight.Rows[i][1].ToString();
                                switch (rightstr)
                                {
                                    case "OrderM":
                                        mt = new MenuItem("· 订单管理", "OrderM", "", "~/franchiser_order/Show.aspx");
                                        Session["OrderM"] = "OrderM";
                                        break;
                                    case "SendM":
                                        mt = new MenuItem("· 发货管理", "SendM", "", "~/send_main/Show.aspx");
                                        Session["SendM"] = "SendM";
                                        break;
                                    case "TradeM":
                                        mt = new MenuItem("· 交易管理", "TradeM", "", "~/franchiser_trade/Show.aspx");
                                        Session["TradeM"] = "TradeM";
                                        break;
                                    case "PriceM":
                                        mt = new MenuItem("· 实时金价管理", "PriceM", "", "~/realtime_price/Show.aspx");
                                        Session["PriceM"] = "PriceM";
                                        break;
                                    case "FranM":
                                        mt = new MenuItem("· 经销商管理", "FranM", "", "~/franchiser_info/Show.aspx");
                                        Session["FranM"] = "FranM";
                                        break;
                                    case "MoneyM":
                                        mt = new MenuItem("· 财务管理", "MoneyM", "", "~/franchiser_money/Show.aspx");
                                        Session["MoneyM"] = "MoneyM";
                                        break;
                                    case "IA100M":
                                        mt = new MenuItem("· 认证锁管理", "IA100M", "", "~/goldtrade_IA100/Show.aspx");
                                        Session["IA100M"] = "IA100M";
                                        break;
                                    case "AdminM":
                                        mt = new MenuItem("· 管理员管理", "AdminM", "", "~/goldtrade_db_admin/Show.aspx");
                                        Session["AdminM"] = "AdminM";
                                        break;
                                    case "ProdM":
                                        mt = new MenuItem("· 产品管理", "ProdM", "", "~/product_type/show.aspx");
                                        Session["ProdM"] = "ProdM";
                                        break;
                                    default:
                                        break;
                                }
                                this.RightMenu.Items.Add(mt);
                            }
                        }
                         */
                    //}
                    #endregion
                
                catch
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" +"菜单加载出错" + "');history.back();</script>");
                    Response.End();
                    return;
                }

            }
        }



        private DataTable GetRightList(int adminId)
        {
            GoldTradeNaming.BLL.sys_admin_authority bll = new GoldTradeNaming.BLL.sys_admin_authority();

            return bll.GetRightSet(adminId);
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
