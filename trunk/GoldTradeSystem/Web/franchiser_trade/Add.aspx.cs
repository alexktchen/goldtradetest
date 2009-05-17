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
using System.Text;
using LTP.Common;
using System.Collections.Generic;
using GoldTradeNaming.Model;
using System.Text.RegularExpressions;
namespace GoldTradeNaming.Web.franchiser_trade
{
    public partial class Add : System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        //    GoldTradeNaming.BLL.realtime_price bllPrice = new GoldTradeNaming.BLL.realtime_price();
        //   GoldTradeNaming.BLL.franchiser_info bllInfo = new GoldTradeNaming.BLL.franchiser_info();     

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            //(Master.FindControl("lblOrderOrTrade") as Label).Text = "点价可用余额：";
            //(Master.FindControl("lblTitle") as Label).Text = "增加交易";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
            if (!IsPostBack)
            {
                divSilver.Visible = false;
                divGold.Visible = false;
                divBtn.Visible = false;

            }
        }

        private bool showGoldGrid()
        {
            string franchiser_code = Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = GetGoldStock(franchiser_code);
                gvTrade.DataSource = ds;
                gvTrade.DataBind();
                JoinCells(gvTrade, 0);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }

        private bool showSilverGrid()
        {
            string franchiser_code = Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = GetSilverStock(franchiser_code);
                gvTrade2.DataSource = ds;
                gvTrade2.DataBind();
                JoinCells(gvTrade2, 0);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }

        private void ShowGrid()
        {
            string franchiser_code = Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = GetGoldStock(franchiser_code);
                gvTrade.DataSource = ds;
                gvTrade.DataBind();
                JoinCells(gvTrade, 0);

                ds = GetSilverStock(franchiser_code);
                gvTrade2.DataSource = ds;
                gvTrade2.DataBind();
                JoinCells(gvTrade2, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="iCellNO">第几列</param>
        public void JoinCells(Anthem.GridView agv, int iCellNO)
        {
            for (int i = agv.Rows.Count - 1; i > 0; i--)
            {
                int j = i - 1;
                string s1 = agv.Rows[i].Cells[iCellNO].Text.Trim();
                string s2 = agv.Rows[j].Cells[iCellNO].Text.Trim();

                if (s1 == s2)
                {
                    int nSpan = 1;
                    nSpan = agv.Rows[i].Cells[iCellNO].RowSpan;
                    if (nSpan == 0)
                        nSpan = 1;
                    nSpan++;
                    agv.Rows[i].Cells[iCellNO].Visible = false;
                    agv.Rows[j].Cells[iCellNO].RowSpan = nSpan;
                }
            }
        }

        protected void ibGold_Click(object sender, ImageClickEventArgs e)
        {
            if (showGoldGrid())
            {
                divSilver.Visible = false;
                divBtn.Visible = true;
                divGold.Visible = true;
                btnSubmit.Enabled = false;
                hfType.Value = "0";
            }
        }

        protected void ibSilver_Click(object sender, ImageClickEventArgs e)
        {
            if (showSilverGrid())
            {
                divSilver.Visible = true;
                divBtn.Visible = true;
                divGold.Visible = false;
                hfType.Value = "1";
                btnSubmit.Enabled = false;
            }
        }


        protected void ProdNumChg(object sender, EventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                GridViewRow drv = (GridViewRow)t.NamingContainer;
                int rowIndex = drv.RowIndex;

                decimal iPro_spec = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[1].Text.Replace("g", "").Replace(" ", "").Trim());
                decimal base_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[2].Text.Replace("元/g", "").Replace(" ", ""));
                decimal add_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[3].Text.Replace("元/g", "").Replace(" ", ""));
                if (!IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 元";
                }
                if (Convert.ToInt32(gvTrade.Rows[rowIndex].Cells[4].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 元";
                }
                else
                {
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec), 4).ToString() + "g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec * (base_price + add_price)), 4).ToString() + "元";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        protected void ProdNumChg2(object sender, EventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                GridViewRow drv = (GridViewRow)t.NamingContainer;
                int rowIndex = drv.RowIndex;

                decimal iPro_spec = Convert.ToDecimal(gvTrade2.Rows[rowIndex].Cells[1].Text.Replace("g", "").Replace(" ", ""));
                decimal base_price = Convert.ToDecimal(gvTrade2.Rows[rowIndex].Cells[2].Text.Replace("元/g", "").Replace(" ", ""));
                //    decimal add_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[3].Text.Trim());
                if (!IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 元";
                }
                if (Convert.ToInt32(gvTrade2.Rows[rowIndex].Cells[3].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 元";
                }
                else
                {
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec), 4).ToString() + "g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec * (base_price)), 4).ToString() + "元";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        bool IsNum(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\d+$");
        }


        private DataSet GetGoldStock(string franchiser_code)
        {
            return bll.GetGoldStock(franchiser_code);

        }
        private DataSet GetSilverStock(string franchiser_code)
        {
            return bll.GetSilverStock(franchiser_code);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfType.Value == "0")
                SubmitGoldTrade();
            else if (hfType.Value == "1")
                SubmitSilverTrade();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                MessageBox.Show(this, "请输入交易数量");
                return;
            }
            DataSet ds = bll.GetTradetime();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DateTime dtFrom = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtFrom"].ToString().Trim());
                DateTime dtTo = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtTo"].ToString().Trim());
                if (dtFrom.CompareTo(DateTime.Now) > 0 || dtTo.CompareTo(DateTime.Now) < 0)
                {
                    MessageBox.Show(this, "现在不是交易时间,不能交易");
                    return;
                }
            }
            if (hfType.Value == "0")
                SaveGoldTrade();
            else if (hfType.Value == "1")
                SaveSilverTrade();
        }

        private void SaveGoldTrade()
        {
            string sCurPrice;//,trade_add_price;
            if (!GetCurPriceInfo(out sCurPrice))
                return;

            try
            {
                string tradeNum = "";

                decimal iTotalWeight = 0;
                decimal iTotalMoney = 0;
                TradeInfo trInfo = new TradeInfo();

                List<ProductInfo> proInfos = new List<ProductInfo>();

                ProductInfo proInfo;
                DataSet ds = null;
                for (int i = 0; i < gvTrade.Rows.Count; i++)
                {
                    tradeNum = ((TextBox)gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim();
                    if (tradeNum != "" && Convert.ToInt32(tradeNum) != 0)
                    {
                        proInfo = new ProductInfo();

                        proInfo.ProductID = Convert.ToInt32(gvTrade.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = Convert.ToDecimal(gvTrade.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));


                        proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //基础金价              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        proInfo.TradeAddPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //交易加价
                        proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice; //结算单价

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//交易重量

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //交易金额
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToDecimal(gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//交易完所剩库存
                        proInfos.Add(proInfo);
                    }
                }

                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);

                lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "元";
                lblTotalWeight.Text = iTotalWeight + "克";
                lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "元";
                btnSubmit.Enabled = true;
                MessageBox.Show(this, "保存成功，请点提交确认交易！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

        }

        private void SaveSilverTrade()
        {
            try
            {
                string tradeNum = "";

                decimal iTotalWeight = 0;
                decimal iTotalMoney = 0;
                TradeInfo trInfo = new TradeInfo();
                List<ProductInfo> proInfos = new List<ProductInfo>();
                ProductInfo proInfo;
                DataSet ds = null;

                for (int i = 0; i < gvTrade2.Rows.Count; i++)
                {
                    tradeNum = ((TextBox)gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim();
                    if (tradeNum != "" && Convert.ToInt32(tradeNum) != 0)
                    {
                        proInfo = new ProductInfo();

                        proInfo.ProductID = Convert.ToInt32(gvTrade2.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = Convert.ToDecimal(gvTrade2.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));


                        // proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //基础金价              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        //   proInfo.TradeAddPrice =
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //固定价格/结算单价

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//交易重量

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //交易金额
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        int aaa = Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount;
                        proInfo.StockLeft = (Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//所剩交易完剩库存
                        proInfos.Add(proInfo);
                    }
                }
                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);

                lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "元";
                lblTotalWeight.Text = iTotalWeight + "克";
                lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "元";

                btnSubmit.Enabled = true;
                MessageBox.Show(this, "保存成功，请点提交确认交易！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void SubmitGoldTrade()
        {
            string sCurPrice;//,trade_add_price;
            if (!GetCurPriceInfo(out sCurPrice))
                return;

            try
            {
                string tradeNum = "";

                decimal iTotalWeight = 0;
                decimal iTotalMoney = 0;
                TradeInfo trInfo = new TradeInfo();

                List<ProductInfo> proInfos = new List<ProductInfo>();

                ProductInfo proInfo;
                DataSet ds = null;
                for (int i = 0; i < gvTrade.Rows.Count; i++)
                {
                    tradeNum = ((TextBox)gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim();
                    if (tradeNum != "" && Convert.ToInt32(tradeNum) != 0)
                    {
                        proInfo = new ProductInfo();

                        proInfo.ProductID = Convert.ToInt32(gvTrade.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = Convert.ToDecimal(gvTrade.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));


                        proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //基础金价              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        proInfo.TradeAddPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //交易加价
                        proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice; //结算单价

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//交易重量

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //交易金额
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToInt32(gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//交易完所剩库存
                        proInfos.Add(proInfo);
                    }
                }


                trInfo.FranchiserCode = Session["fran"].ToString().Trim();  //经销商id
                trInfo.RealTimePrice = Convert.ToDecimal(sCurPrice);        //基础金价

                trInfo.TradeTotalWeight = iTotalWeight;//总重量
                trInfo.TradeTotalMoney = iTotalMoney;//总金额           


                trInfo.TradeState = "0";//新增 交易为 0 
                trInfo.InsUser = Session["fran"].ToString();
                trInfo.UpdUser = Session["fran"].ToString();

                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);

                if (money_use > 0 && money_use >= trInfo.TradeTotalMoney)
                {
                    if (bll.AddTrandeInfo(proInfos, trInfo, hfType.Value))
                    {
                        showGoldGrid();
                        btnSubmit.Enabled = false;

                        MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/Add.aspx");

                    }
                    else
                        MessageBox.Show(this, "提交失败");

                }
                else
                {
                    MessageBox.Show(this, "你的余额不够");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "提交错误" + ex.Message);
            }
        }

        private void SubmitSilverTrade()
        {
            try
            {
                string tradeNum = "";

                decimal iTotalWeight = 0;
                decimal iTotalMoney = 0;
                TradeInfo trInfo = new TradeInfo();
                List<ProductInfo> proInfos = new List<ProductInfo>();
                ProductInfo proInfo;
                DataSet ds = null;

                for (int i = 0; i < gvTrade2.Rows.Count; i++)
                {
                    tradeNum = ((TextBox)gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim();
                    if (tradeNum != "" && Convert.ToInt32(tradeNum) != 0)
                    {
                        proInfo = new ProductInfo();

                        proInfo.ProductID = Convert.ToInt32(gvTrade2.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = Convert.ToDecimal(gvTrade2.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));


                        // proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //基础金价              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        //   proInfo.TradeAddPrice =
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //固定价格/结算单价

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//交易重量

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //交易金额
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//所剩交易完剩库存
                        proInfos.Add(proInfo);
                    }
                }


                trInfo.FranchiserCode = Session["fran"].ToString().Trim();  //经销商id       

                trInfo.TradeTotalWeight = iTotalWeight;//总重量
                trInfo.TradeTotalMoney = iTotalMoney;//总金额           


                trInfo.TradeState = "0";//新增 交易为 0 
                trInfo.InsUser = Session["fran"].ToString();
                trInfo.UpdUser = Session["fran"].ToString();

                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);
                GoldTradeNaming.BLL.CommBaseBLL commBLL = new GoldTradeNaming.BLL.CommBaseBLL();
                if (money_use + commBLL.GetSilverStockValue(fran_code) > 0 && money_use + commBLL.GetSilverStockValue(fran_code) >= trInfo.TradeTotalMoney)
                {
                    if (bll.AddTrandeInfo(proInfos, trInfo, hfType.Value))
                    {
                        showSilverGrid();
                        btnSubmit.Enabled = false;

                        //Franchiser master = new Franchiser();
                        //master.LoadData();

                        MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/Add.aspx");
                    }
                    else
                        MessageBox.Show(this, "提交失败");

                }
                else
                {
                    MessageBox.Show(this, "你的余额不够");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "提交错误" + ex.Message);
            }
        }





        private bool CheckInput()
        {
            if (hfType.Value == "0")
            {
                for (int i = 0; i < gvTrade.Rows.Count; i++)
                {
                    if (((TextBox)gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim() != "")
                        return true;
                }
                return false;
            }
            else if (hfType.Value == "1")
            {
                for (int i = 0; i < gvTrade2.Rows.Count; i++)
                {
                    if (((TextBox)gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim() != "")
                        return true;
                }
                return false;
            }
            else
                return false;
        }

        private void InitControl()
        {
            divSilver.Style.Add("display", "none");
            divGold.Style.Add("display", "none");
            divBtn.Style.Add("display", "none");
        }



        protected void gvTrade_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTrade.Rows.Count; i++)
            {
                gvTrade.Rows[i].Cells[1].Text = gvTrade.Rows[i].Cells[1].Text.Trim() + "g";
                // gvTrade.Rows[i].Cells[2].Text = gvTrade.Rows[i].Cells[2].Text.Trim() + " 元/g";
                //  gvTrade.Rows[i].Cells[3].Text = gvTrade.Rows[i].Cells[3].Text.Trim() + " 元/g";
                ((Label)gvTrade.Rows[i].FindControl("lblProdNum")).Text = " *" + gvTrade.Rows[i].Cells[1].Text.Trim();
            }
        }

        protected void gvTrade2_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTrade2.Rows.Count; i++)
            {
                gvTrade2.Rows[i].Cells[1].Text = gvTrade2.Rows[i].Cells[1].Text.Trim() + "g";
                //   gvTrade2.Rows[i].Cells[2].Text = gvTrade2.Rows[i].Cells[1].Text.Trim() + " 元/g";
                ((Label)gvTrade2.Rows[i].FindControl("lblProdNum2")).Text = " *" + gvTrade2.Rows[i].Cells[1].Text.Trim();

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
            string sCurPrice;//,sTradeAdd;         
            decimal curPrice;
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
                GetCurPriceInfo(out sCurPrice);
                curPrice = Convert.ToDecimal(sCurPrice.Trim());
                //  tradeAdd = Convert.ToDecimal(sTradeAdd.Trim());

                ds = bll.GetFranList(strWhere);
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
                MessageBox.Show(this, "读取账面余额失败");
                fran_name = "";
                assure_money = 0;
                fran_money = 0;
                money_use = 0;
                return;
            }

            //点价可用余额=帐面余额-担保款-库存中重量X（中国黄金实时基础金价+销售加价）-理财型产品已定货但未收货的总重量X（中国黄金实时基础金价+销售加价)

            //点价可用余额=帐面余额-担保款-库存中货品价值-已定货未收货货品价值

            // fran_money = balance_money - stockValue - unReceiveValue;//包括担保款
            fran_money = balance_money;

            //update by tianjie 0516:波儿公说要减去库存中银的价值

            GoldTradeNaming.BLL.CommBaseBLL commBLL = new GoldTradeNaming.BLL.CommBaseBLL();
            money_use = fran_money - assure_money - commBLL.GetSilverStockValue(fran_code);         //不包括担保款
        }

        /// <summary>
        /// 获得最新价格
        /// </summary>
        /// <param name="sCurPrice"></param>
        /// <param name="trade_add_price"></param>
        /// <param name="sTime"></param>
        /// <returns></returns>
        protected bool GetCurPriceInfo(out string sCurPrice)
        {
            try
            {
                DataSet ds = bll.getCurrentPrice();
                sCurPrice = ds.Tables[0].Rows[0]["realtime_base_price"].ToString().Trim();
                return true;
                //}             
            }
            catch
            {
                MessageBox.Show(this, "读取最新价格失败");
                sCurPrice = "";
                return false;
            }
        }


    }
}
