namespace GoldTradeNaming.Web
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using GoldTradeNaming.Web.Controls;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Franchiser : System.Web.UI.MasterPage
    {
        private CommBaseBLL bll = new CommBaseBLL();
        protected ContentPlaceHolder ContentPlaceHolder2;
        protected GoldTradeNaming.Web.Controls.CopyRight1 CopyRight1;
        protected HtmlForm form1;
        protected ContentPlaceHolder head;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label10;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label7;
        protected Label Label8;
        protected Label Labelx;
        protected Label lblAsure;
        protected Label lblFranBalance;
        protected Label lblFranName;
        protected Label lblOrder;
        protected Label lblOrderBalance;
        protected Label lblOrderSum;
        protected Label lblTrade;
        protected Label lblTradeBalance;
        protected Label lblTradeSum;
        protected Logo Logo1;
        protected Navigator Nav1;

        private void GetMoneyLeft(string fran_code, out string fran_name, out decimal fran_money, out decimal assure_money, out decimal money_use)
        {
            fran_name = "";
            fran_money = 0M;
            assure_money = 0M;
            money_use = 0M;
            DataSet ds = null;
            decimal balance_money = 0M;
            string strWhere = "franchiser_code='" + fran_code + "'";
            decimal unReceiveValue = 0M;
            decimal stockValue = 0M;
            try
            {
                balance_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString().Trim());
                assure_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString().Trim());
                fran_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString().Trim();
                unReceiveValue = this.bll.GetGoldNoReceiveValue(fran_code) + this.bll.GetSilverNoReceiveValue(fran_code);
                stockValue = this.bll.GetGoldStockValue(fran_code) + this.bll.GetSilverStockValue(fran_code);
            }
            catch
            {
                fran_name = "";
                assure_money = 0M;
                fran_money = 0M;
                money_use = 0M;
                return;
            }
            fran_money = (balance_money - stockValue) - unReceiveValue;
            money_use = fran_money - assure_money;
        }

        private void LoadData()
        {
            try
            {
                int franid = Convert.ToInt32(base.Session["fran"]);
                GoldTradeNaming.Model.franchiser_info frninfo = new GoldTradeNaming.BLL.franchiser_info().GetModel(franid);
                this.lblFranName.Text = frninfo.franchiser_name;
                this.lblFranBalance.Text = frninfo.franchiser_balance_money.ToString();
                this.lblAsure.Text = frninfo.franchiser_asure_money.ToString();
                decimal leftmoney = CommBaseBLL.GetBalance(franid);
                this.lblOrderBalance.Text = Convert.ToString(leftmoney);
                this.lblTradeBalance.Text = CommBaseBLL.GetTradeBalance(franid).ToString();
                this.lblOrderSum.Text = CommBaseBLL.GetOrderSumByFranId(franid).ToString();
                this.lblTradeSum.Text = CommBaseBLL.GetTradeSumByFranId(franid).ToString();
            }
            catch
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.LoadData();
            }
        }
    }
}
