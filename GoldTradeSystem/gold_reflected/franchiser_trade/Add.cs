namespace WebReflector.franchiser_trade
{
    using AjaxControlToolkit;
    using Anthem;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.Button btnSubmit;
        protected System.Web.UI.WebControls.Button ButtonCancel;
        protected System.Web.UI.WebControls.Button ButtonOk;
        protected ConfirmButtonExtender ConfirmButtonExtender2;
        protected HtmlGenericControl divBtn;
        protected HtmlGenericControl divGold;
        protected HtmlGenericControl divSilver;
        protected HtmlGenericControl divType;
        protected Anthem.GridView gvTrade;
        protected Anthem.GridView gvTrade2;
        protected System.Web.UI.WebControls.HiddenField hfType;
        protected System.Web.UI.WebControls.ImageButton ibGold;
        protected System.Web.UI.WebControls.ImageButton ibSilver;
        protected System.Web.UI.WebControls.Label lblCanUseMoney;
        protected System.Web.UI.WebControls.Label lblTotalMoney;
        protected System.Web.UI.WebControls.Label lblTotalWeight;
        protected ModalPopupExtender ModalPopupExtender1;
        protected System.Web.UI.WebControls.Panel PNL;
        protected ScriptManager ScriptManager1;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput())
            {
                MessageBox.Show(this, "请输入交易数量");
            }
            else
            {
                DataSet ds = this.bll.GetTradetime();
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    DateTime dtFrom = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtFrom"].ToString().Trim());
                    DateTime dtTo = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtTo"].ToString().Trim());
                    if ((dtFrom.CompareTo(DateTime.Now) > 0) || (dtTo.CompareTo(DateTime.Now) < 0))
                    {
                        MessageBox.Show(this, "现在不是交易时间,不能交易");
                        return;
                    }
                }
                if (this.hfType.Value == "0")
                {
                    this.SaveGoldTrade();
                }
                else if (this.hfType.Value == "1")
                {
                    this.SaveSilverTrade();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.hfType.Value == "0")
            {
                this.SubmitGoldTrade();
            }
            else if (this.hfType.Value == "1")
            {
                this.SubmitSilverTrade();
            }
        }

        private bool CheckInput()
        {
            int i;
            if (this.hfType.Value == "0")
            {
                for (i = 0; i < this.gvTrade.Rows.Count; i++)
                {
                    if (((System.Web.UI.WebControls.TextBox)this.gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim() != "")
                    {
                        return true;
                    }
                }
                return false;
            }
            if (this.hfType.Value == "1")
            {
                for (i = 0; i < this.gvTrade2.Rows.Count; i++)
                {
                    if (((System.Web.UI.WebControls.TextBox)this.gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim() != "")
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        protected bool GetCurPriceInfo(out string sCurPrice)
        {
            try
            {
                DataSet ds = this.bll.getCurrentPrice();
                sCurPrice = ds.Tables[0].Rows[0]["realtime_base_price"].ToString().Trim();
                return true;
            }
            catch
            {
                MessageBox.Show(this, "读取最新价格失败");
                sCurPrice = "";
                return false;
            }
        }

        private DataSet GetGoldStock(string sFranchiser_code)
        {
            int franchiser_code = Convert.ToInt32(sFranchiser_code);
            return this.bll.GetGoldStock(franchiser_code);
        }

        private void GetMoneyLeft(string sFran_code, out string fran_name, out decimal fran_money, out decimal assure_money, out decimal money_use)
        {
            fran_name = "";
            fran_money = 0M;
            assure_money = 0M;
            money_use = 0M;
            DataSet ds = null;
            decimal balance_money = 0M;
            int fran_code = Convert.ToInt32(sFran_code);
            decimal unReceiveValue = 0M;
            decimal stockValue = 0M;
            try
            {
                string sCurPrice;
                this.GetCurPriceInfo(out sCurPrice);
                decimal curPrice = Convert.ToDecimal(sCurPrice.Trim());
                ds = this.bll.GetFranList(fran_code);
                balance_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString().Trim());
                assure_money = Convert.ToDecimal(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString().Trim());
                fran_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString().Trim();
                unReceiveValue = this.bll.GetGoldNoReceiveValue(fran_code) + this.bll.GetSilverNoReceiveValue(fran_code);
                stockValue = this.bll.GetGoldStockValue(fran_code) + this.bll.GetSilverStockValue(fran_code);
            }
            catch
            {
                MessageBox.Show(this, "读取账面余额失败");
                fran_name = "";
                assure_money = 0M;
                fran_money = 0M;
                money_use = 0M;
                return;
            }
            fran_money = balance_money;
            CommBaseBLL commBLL = new CommBaseBLL();
            money_use = (fran_money - assure_money) - commBLL.GetSilverStockValue(sFran_code);
        }

        private DataSet GetSilverStock(string sFranchiser_code)
        {
            int franchiser_code = Convert.ToInt32(sFranchiser_code);
            return this.bll.GetSilverStock(franchiser_code);
        }

        protected void ibGold_Click(object sender, ImageClickEventArgs e)
        {
            if (this.showGoldGrid())
            {
                this.divSilver.Visible = false;
                this.divBtn.Visible = true;
                this.divGold.Visible = true;
                this.btnSubmit.Enabled = false;
                this.hfType.Value = "0";
            }
        }

        protected void ibSilver_Click(object sender, ImageClickEventArgs e)
        {
            if (this.showSilverGrid())
            {
                this.divSilver.Visible = true;
                this.divBtn.Visible = true;
                this.divGold.Visible = false;
                this.hfType.Value = "1";
                this.btnSubmit.Enabled = false;
            }
        }

        private void InitControl()
        {
            this.divSilver.Style.Add("display", "none");
            this.divGold.Style.Add("display", "none");
            this.divBtn.Style.Add("display", "none");
        }

        private bool IsNum(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\d+$");
        }

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
                    {
                        nSpan = 1;
                    }
                    nSpan++;
                    agv.Rows[i].Cells[iCellNO].Visible = false;
                    agv.Rows[j].Cells[iCellNO].RowSpan = nSpan;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!base.IsPostBack)
            {
                this.divSilver.Visible = false;
                this.divGold.Visible = false;
                this.divBtn.Visible = false;
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        protected void ProdNumChg(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.TextBox t = (System.Web.UI.WebControls.TextBox)sender;
                GridViewRow drv = (GridViewRow)t.NamingContainer;
                int rowIndex = drv.RowIndex;
                decimal iPro_spec = Convert.ToDecimal(this.gvTrade.Rows[rowIndex].Cells[1].Text.Replace("g", "").Replace(" ", "").Trim());
                decimal base_price = Convert.ToDecimal(this.gvTrade.Rows[rowIndex].Cells[2].Text.Replace("元/g", "").Replace(" ", ""));
                decimal add_price = Convert.ToDecimal(this.gvTrade.Rows[rowIndex].Cells[3].Text.Replace("元/g", "").Replace(" ", ""));
                if (!this.IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 元";
                }
                if (Convert.ToInt32(this.gvTrade.Rows[rowIndex].Cells[4].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 元";
                }
                else
                {
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = decimal.Round(Convert.ToInt32(t.Text.Trim()) * iPro_spec, 4).ToString() + "g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec) * (base_price + add_price), 4).ToString() + "元";
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
                System.Web.UI.WebControls.TextBox t = (System.Web.UI.WebControls.TextBox)sender;
                GridViewRow drv = (GridViewRow)t.NamingContainer;
                int rowIndex = drv.RowIndex;
                decimal iPro_spec = 1M;
                decimal base_price = Convert.ToDecimal(this.gvTrade2.Rows[rowIndex].Cells[2].Text.Replace("元/g", "").Replace(" ", ""));
                if (!this.IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 元";
                }
                if (Convert.ToInt32(this.gvTrade2.Rows[rowIndex].Cells[3].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 元";
                }
                else
                {
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = decimal.Round(Convert.ToInt32(t.Text.Trim()) * iPro_spec, 4).ToString() + "g";
                    ((System.Web.UI.WebControls.Label)this.gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec) * base_price, 4).ToString() + "元";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void SaveGoldTrade()
        {
            string sCurPrice;
            if (this.GetCurPriceInfo(out sCurPrice))
            {
                try
                {
                    string fran_name;
                    decimal fran_money;
                    decimal assure_money;
                    decimal money_use;
                    string tradeNum = "";
                    decimal iTotalWeight = 0M;
                    decimal iTotalMoney = 0M;
                    TradeInfo trInfo = new TradeInfo();
                    List<ProductInfo> proInfos = new List<ProductInfo>();
                    DataSet ds = null;
                    for (int i = 0; i < this.gvTrade.Rows.Count; i++)
                    {
                        tradeNum = ((System.Web.UI.WebControls.TextBox)this.gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim();
                        if ((tradeNum != "") && (Convert.ToInt32(tradeNum) != 0))
                        {
                            ProductInfo proInfo = new ProductInfo();
                            proInfo.ProductID = Convert.ToInt32(this.gvTrade.DataKeys[i].Value.ToString().Trim());
                            proInfo.ProductSpecID = Convert.ToDecimal(this.gvTrade.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));
                            proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);
                            // ds = this.bll.GetTradeAdd(proInfo.ProductID);
                            proInfo.TradeAddPrice = Convert.ToDecimal(this.gvTrade.Rows[i].Cells[3].Text.Replace("元/g", "").Replace(" ", "")); //Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim());
                            proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice;
                            proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                            proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;
                            proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;
                            iTotalMoney += proInfo.TradeMoney;
                            iTotalWeight += proInfo.TradeWeight;
                            proInfo.StockLeft = (Convert.ToDecimal(this.gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;
                            proInfos.Add(proInfo);
                        }
                    }
                    string fran_code = this.Session["fran"].ToString().Trim();
                    this.GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);
                    this.lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "元";
                    this.lblTotalWeight.Text = iTotalWeight + "克";
                    this.lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "元";
                    this.btnSubmit.Enabled = true;
                    MessageBox.Show(this, "保存成功，请点提交确认交易！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private void SaveSilverTrade()
        {
            try
            {
                string fran_name;
                decimal fran_money;
                decimal assure_money;
                decimal money_use;
                string tradeNum = "";
                decimal iTotalWeight = 0M;
                decimal iTotalMoney = 0M;
                TradeInfo trInfo = new TradeInfo();
                List<ProductInfo> proInfos = new List<ProductInfo>();
                DataSet ds = null;
                for (int i = 0; i < this.gvTrade2.Rows.Count; i++)
                {
                    tradeNum = ((System.Web.UI.WebControls.TextBox)this.gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim();
                    if ((tradeNum != "") && (Convert.ToInt32(tradeNum) != 0))
                    {
                        ProductInfo proInfo = new ProductInfo();
                        proInfo.ProductID = Convert.ToInt32(this.gvTrade2.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = 1M;
                        ds = this.bll.GetTradeAdd(proInfo.ProductID);
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim());
                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;
                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;
                        int aaa = Convert.ToInt32(this.gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount;
                        proInfo.StockLeft = (Convert.ToInt32(this.gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;
                        proInfos.Add(proInfo);
                    }
                }
                string fran_code = this.Session["fran"].ToString().Trim();
                this.GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);
                this.lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "元";
                this.lblTotalWeight.Text = iTotalWeight + "克";
                this.lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "元";
                this.btnSubmit.Enabled = true;
                MessageBox.Show(this, "保存成功，请点提交确认交易！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private bool showGoldGrid()
        {
            string franchiser_code = this.Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = this.GetGoldStock(franchiser_code);
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
                this.JoinCells(this.gvTrade, 0);
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
            string franchiser_code = this.Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = this.GetGoldStock(franchiser_code);
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
                this.JoinCells(this.gvTrade, 0);
                ds = this.GetSilverStock(franchiser_code);
                this.gvTrade2.DataSource = ds;
                this.gvTrade2.DataBind();
                this.JoinCells(this.gvTrade2, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private bool showSilverGrid()
        {
            string franchiser_code = this.Session["fran"].ToString().Trim();
            try
            {
                DataSet ds = this.GetSilverStock(franchiser_code);
                this.gvTrade2.DataSource = ds;
                this.gvTrade2.DataBind();
                this.JoinCells(this.gvTrade2, 0);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }

        private void SubmitGoldTrade()
        {
            string sCurPrice;
            if (this.GetCurPriceInfo(out sCurPrice))
            {
                try
                {
                    string tradeNum = "";
                    decimal iTotalWeight = 0M;
                    decimal iTotalMoney = 0M;
                    TradeInfo trInfo = new TradeInfo();
                    List<ProductInfo> proInfos = new List<ProductInfo>();
                    DataSet ds = null;
                    for (int i = 0; i < this.gvTrade.Rows.Count; i++)
                    {
                        tradeNum = ((System.Web.UI.WebControls.TextBox)this.gvTrade.Rows[i].FindControl("txtProdNum")).Text.Trim();
                        if ((tradeNum != "") && (Convert.ToInt32(tradeNum) != 0))
                        {
                            ProductInfo proInfo = new ProductInfo();
                            proInfo.ProductID = Convert.ToInt32(this.gvTrade.DataKeys[i].Value.ToString().Trim());
                            proInfo.ProductSpecID = Convert.ToDecimal(this.gvTrade.Rows[i].Cells[1].Text.Replace("g", "").Replace(" ", ""));
                            proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);
                            //  ds = this.bll.GetTradeAdd(proInfo.ProductID);
                            proInfo.TradeAddPrice = Convert.ToDecimal(this.gvTrade.Rows[i].Cells[3].Text.Replace("元/g", "").Replace(" ", "")); //Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim());
                            proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice;
                            proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                            proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;
                            proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;
                            iTotalMoney += proInfo.TradeMoney;
                            iTotalWeight += proInfo.TradeWeight;
                            proInfo.StockLeft = (Convert.ToInt32(this.gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;
                            proInfos.Add(proInfo);
                        }
                    }
                    trInfo.FranchiserCode = this.Session["fran"].ToString().Trim();
                    trInfo.RealTimePrice = Convert.ToDecimal(sCurPrice);
                    trInfo.TradeTotalWeight = iTotalWeight;
                    trInfo.TradeTotalMoney = iTotalMoney;
                    trInfo.TradeState = "0";
                    trInfo.InsUser = this.Session["fran"].ToString();
                    trInfo.UpdUser = this.Session["fran"].ToString();
                    if (CommBaseBLL.GetTradeBalance(Convert.ToInt32(this.Session["fran"])) > 0M)
                    {
                        if (this.bll.AddTrandeInfo(proInfos, trInfo, this.hfType.Value))
                        {
                            this.showGoldGrid();
                            this.btnSubmit.Enabled = false;
                            MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/Add.aspx");
                        }
                        else
                        {
                            MessageBox.Show(this, "提交失败,请重新操作");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "你的点价可用余额不够");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "提交错误：" + ex.Message);
                }
            }
        }

        private void SubmitSilverTrade()
        {
            try
            {
                string fran_name;
                decimal fran_money;
                decimal assure_money;
                decimal money_use;
                string tradeNum = "";
                decimal iTotalWeight = 0M;
                decimal iTotalMoney = 0M;
                TradeInfo trInfo = new TradeInfo();
                List<ProductInfo> proInfos = new List<ProductInfo>();
                DataSet ds = null;
                for (int i = 0; i < this.gvTrade2.Rows.Count; i++)
                {
                    tradeNum = ((System.Web.UI.WebControls.TextBox)this.gvTrade2.Rows[i].FindControl("txtProdNum2")).Text.Trim();
                    if ((tradeNum != "") && (Convert.ToInt32(tradeNum) != 0))
                    {
                        ProductInfo proInfo = new ProductInfo();
                        proInfo.ProductID = Convert.ToInt32(this.gvTrade2.DataKeys[i].Value.ToString().Trim());
                        proInfo.ProductSpecID = 1M;
                        ds = this.bll.GetTradeAdd(proInfo.ProductID);
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim());
                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;
                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;
                        proInfo.StockLeft = (Convert.ToInt32(this.gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;
                        proInfos.Add(proInfo);
                    }
                }
                trInfo.FranchiserCode = this.Session["fran"].ToString().Trim();
                trInfo.TradeTotalWeight = iTotalWeight;
                trInfo.TradeTotalMoney = iTotalMoney;
                trInfo.TradeState = "0";
                trInfo.InsUser = this.Session["fran"].ToString();
                trInfo.UpdUser = this.Session["fran"].ToString();
                string fran_code = this.Session["fran"].ToString().Trim();
                this.GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);
                CommBaseBLL commBLL = new CommBaseBLL();
                if (((money_use + commBLL.GetSilverStockValue(fran_code)) > 0M) && ((money_use + commBLL.GetSilverStockValue(fran_code)) >= trInfo.TradeTotalMoney))
                {
                    if (this.bll.AddTrandeInfo(proInfos, trInfo, this.hfType.Value))
                    {
                        this.showSilverGrid();
                        this.btnSubmit.Enabled = false;
                        MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/Add.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "提交失败");
                    }
                }
                else
                {
                    MessageBox.Show(this, "你的点价可用余额不够");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "提交错误" + ex.Message);
            }
        }
    }
}
