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
    ///	CheckRight ��ժҪ˵����
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

                        mt = new MenuItem("�� ������", "", "", "~/stock_main/Show.aspx");                      
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� ����ȷ��", "", "", "~/franchiser_order/Modify.aspx?type=1");                       
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� ���߷���", "", "", "~/send_main/Show.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� �鿴����", "", "", "~/franchiser_trade/ShowM.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� �޸�ʵʱ���", "", "", "~/realtime_price/Add.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� ��������", "", "", "~/franchiser_money/Add.aspx");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� �޸�����", "", "", "~/User_Login/IA100edit.htm");
                        this.RightMenu.Items.Add(mt);

                        mt = new MenuItem("�� �˳�ϵͳ", "", "", "~/User_Login/AdminLogin.aspx");
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
                                        mt = new MenuItem("�� ��������", "OrderM", "", "~/franchiser_order/Show.aspx");
                                        Session["OrderM"] = "OrderM";
                                        break;
                                    case "SendM":
                                        mt = new MenuItem("�� ��������", "SendM", "", "~/send_main/Show.aspx");
                                        Session["SendM"] = "SendM";
                                        break;
                                    case "TradeM":
                                        mt = new MenuItem("�� ���׹���", "TradeM", "", "~/franchiser_trade/Show.aspx");
                                        Session["TradeM"] = "TradeM";
                                        break;
                                    case "PriceM":
                                        mt = new MenuItem("�� ʵʱ��۹���", "PriceM", "", "~/realtime_price/Show.aspx");
                                        Session["PriceM"] = "PriceM";
                                        break;
                                    case "FranM":
                                        mt = new MenuItem("�� �����̹���", "FranM", "", "~/franchiser_info/Show.aspx");
                                        Session["FranM"] = "FranM";
                                        break;
                                    case "MoneyM":
                                        mt = new MenuItem("�� �������", "MoneyM", "", "~/franchiser_money/Show.aspx");
                                        Session["MoneyM"] = "MoneyM";
                                        break;
                                    case "IA100M":
                                        mt = new MenuItem("�� ��֤������", "IA100M", "", "~/goldtrade_IA100/Show.aspx");
                                        Session["IA100M"] = "IA100M";
                                        break;
                                    case "AdminM":
                                        mt = new MenuItem("�� ����Ա����", "AdminM", "", "~/goldtrade_db_admin/Show.aspx");
                                        Session["AdminM"] = "AdminM";
                                        break;
                                    case "ProdM":
                                        mt = new MenuItem("�� ��Ʒ����", "ProdM", "", "~/product_type/show.aspx");
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
                    Response.Write("<script defer>window.alert('" +"�˵����س���" + "');history.back();</script>");
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

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
