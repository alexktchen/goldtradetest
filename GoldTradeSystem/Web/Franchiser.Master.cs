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
using GoldTradeNaming.BLL;

namespace GoldTradeNaming.Web
{
    public partial class Franchiser : System.Web.UI.MasterPage
    {
        CommBaseBLL bll = new CommBaseBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                int franid = Convert.ToInt32(Session["fran"]);

                GoldTradeNaming.BLL.franchiser_info bllfrn = new GoldTradeNaming.BLL.franchiser_info();
                GoldTradeNaming.Model.franchiser_info frninfo = bllfrn.GetModel(franid);

               
                this.lblFranName.Text = frninfo.franchiser_name;
                this.lblFranBalance.Text = frninfo.franchiser_balance_money.ToString();
                this.lblAsure.Text = frninfo.franchiser_asure_money.ToString();

                //订单余额
                decimal leftmoney = CommBaseBLL.GetBalance(franid);
                this.lblOrderBalance.Text = Convert.ToString(leftmoney);                

                //点价余额
                leftmoney = CommBaseBLL.GetTradeBalance(franid);
                lblTradeBalance.Text = leftmoney.ToString();
            }
            catch
            {

            }
        }



        /// <summary>
        /// 获得经销商账面余额（包括担保款和不含担保的）
        /// </summary>
        /// <param name="fran_code"></param>
        /// <param name="fran_name"></param>
        /// <param name="fran_money"></param>
        /// <param name="money_use"></param>
        private void GetMoneyLeft(string fran_code, out string fran_name, out decimal fran_money, out decimal assure_money, out decimal money_use)
        {
            fran_name = "";
            fran_money = 0;
            assure_money = 0;
            money_use = 0;

            //实时基础金价 
            //string sCurPrice;//,sTradeAdd;         
            //decimal curPrice;
            //账面余额(未减差价)和担保款
            DataSet ds = null;
            decimal balance_money = 0;
            // decimal asure_money = 0;
            string strWhere = "franchiser_code='" + fran_code + "'";

            //已定货未收货的总价值
            decimal unReceiveValue = 0;
            //库存货物总价值
            decimal stockValue = 0;
            try
            {
                //GetCurPriceInfo(out sCurPrice);
                //curPrice = Convert.ToDecimal(sCurPrice.Trim());
                //  tradeAdd = Convert.ToDecimal(sTradeAdd.Trim());

                //ds = bll.GetFranList(strWhere);
                balance_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString().Trim());
                assure_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString().Trim());
                fran_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString().Trim();

                unReceiveValue = bll.GetGoldNoReceiveValue(fran_code); //黄金价值  
                unReceiveValue += bll.GetSilverNoReceiveValue(fran_code);//白银价值              

                stockValue = bll.GetGoldStockValue(fran_code);
                stockValue += bll.GetSilverStockValue(fran_code);

            }
            catch
            {
                //MessageBox.Show(this, "读取账面余额失败");
                fran_name = "";
                assure_money = 0;
                fran_money = 0;
                money_use = 0;
                return;
            }

            //点价可用余额=帐面余额-担保款-库存中重量X（中国黄金实时基础金价+销售加价）-理财型产品已定货但未收货的总重量X（中国黄金实时基础金价+销售加价)

            //点价可用余额=帐面余额-担保款-库存中货品价值-已定货未收货货品价值

            fran_money = balance_money - stockValue - unReceiveValue;//包括担保款
            money_use = fran_money - assure_money;          //不包括担保款
        }




    }
}
