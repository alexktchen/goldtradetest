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

            //(Master.FindControl("lblOrderOrTrade") as Label).Text = "��ۿ�����";
            //(Master.FindControl("lblTitle") as Label).Text = "���ӽ���";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/flogin.aspx");
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
        /// �ϲ���Ԫ��
        /// </summary>
        /// <param name="iCellNO">�ڼ���</param>
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
                decimal base_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[2].Text.Replace("Ԫ/g", "").Replace(" ", ""));
                decimal add_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[3].Text.Replace("Ԫ/g", "").Replace(" ", ""));
                if (!IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 Ԫ";
                }
                if (Convert.ToInt32(gvTrade.Rows[rowIndex].Cells[4].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = "0 g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = "0 Ԫ";
                }
                else
                {
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblProdWht")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec), 4).ToString() + "g";
                    ((Label)gvTrade.Rows[rowIndex].FindControl("lblMoneyCount")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec * (base_price + add_price)), 4).ToString() + "Ԫ";
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
                decimal base_price = Convert.ToDecimal(gvTrade2.Rows[rowIndex].Cells[2].Text.Replace("Ԫ/g", "").Replace(" ", ""));
                //    decimal add_price = Convert.ToDecimal(gvTrade.Rows[rowIndex].Cells[3].Text.Trim());
                if (!IsNum(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 Ԫ";
                }
                if (Convert.ToInt32(gvTrade2.Rows[rowIndex].Cells[3].Text.Trim()) < Convert.ToInt32(t.Text.Trim()))
                {
                    t.Text = "";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = "0 g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = "0 Ԫ";
                }
                else
                {
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblProdWht2")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec), 4).ToString() + "g";
                    ((Label)gvTrade2.Rows[rowIndex].FindControl("lblMoneyCount2")).Text = decimal.Round((Convert.ToInt32(t.Text.Trim()) * iPro_spec * (base_price)), 4).ToString() + "Ԫ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// �Ƿ�����
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
                MessageBox.Show(this, "�����뽻������");
                return;
            }
            DataSet ds = bll.GetTradetime();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DateTime dtFrom = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtFrom"].ToString().Trim());
                DateTime dtTo = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtTo"].ToString().Trim());
                if (dtFrom.CompareTo(DateTime.Now) > 0 || dtTo.CompareTo(DateTime.Now) < 0)
                {
                    MessageBox.Show(this, "���ڲ��ǽ���ʱ��,���ܽ���");
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


                        proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //�������              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        proInfo.TradeAddPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //���׼Ӽ�
                        proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice; //���㵥��

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//��������

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //���׽��
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToDecimal(gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//��������ʣ���
                        proInfos.Add(proInfo);
                    }
                }

                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);

                lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "Ԫ";
                lblTotalWeight.Text = iTotalWeight + "��";
                lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "Ԫ";
                btnSubmit.Enabled = true;
                MessageBox.Show(this, "����ɹ�������ύȷ�Ͻ��ף�");
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


                        // proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //�������              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        //   proInfo.TradeAddPrice =
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //�̶��۸�/���㵥��

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//��������

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //���׽��
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        int aaa = Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount;
                        proInfo.StockLeft = (Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//��ʣ������ʣ���
                        proInfos.Add(proInfo);
                    }
                }
                string fran_name;
                decimal fran_money, assure_money, money_use;
                string fran_code = Session["fran"].ToString().Trim();

                GetMoneyLeft(fran_code, out fran_name, out fran_money, out assure_money, out money_use);

                lblCanUseMoney.Text = decimal.Round(Convert.ToDecimal(money_use), 4) + "Ԫ";
                lblTotalWeight.Text = iTotalWeight + "��";
                lblTotalMoney.Text = decimal.Round(Convert.ToDecimal(iTotalMoney), 4) + "Ԫ";

                btnSubmit.Enabled = true;
                MessageBox.Show(this, "����ɹ�������ύȷ�Ͻ��ף�");
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


                        proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //�������              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        proInfo.TradeAddPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //���׼Ӽ�
                        proInfo.GoldTradePrice = proInfo.RealTimeBasePrice + proInfo.TradeAddPrice; //���㵥��

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//��������

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //���׽��
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToInt32(gvTrade.Rows[i].Cells[4].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//��������ʣ���
                        proInfos.Add(proInfo);
                    }
                }


                trInfo.FranchiserCode = Session["fran"].ToString().Trim();  //������id
                trInfo.RealTimePrice = Convert.ToDecimal(sCurPrice);        //�������

                trInfo.TradeTotalWeight = iTotalWeight;//������
                trInfo.TradeTotalMoney = iTotalMoney;//�ܽ��           


                trInfo.TradeState = "0";//���� ����Ϊ 0 
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

                        MessageBox.ShowAndRedirect(this, "�ύ�ɹ�...", "../franchiser_trade/Add.aspx");

                    }
                    else
                        MessageBox.Show(this, "�ύʧ��");

                }
                else
                {
                    MessageBox.Show(this, "�������");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "�ύ����" + ex.Message);
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


                        // proInfo.RealTimeBasePrice = Convert.ToDecimal(sCurPrice);       //�������              
                        ds = bll.GetTradeAdd(proInfo.ProductID.ToString());
                        //   proInfo.TradeAddPrice =
                        proInfo.GoldTradePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["trade_add_price"].ToString().Trim()); //�̶��۸�/���㵥��

                        proInfo.TradeAmount = Convert.ToInt32(tradeNum);
                        proInfo.TradeWeight = proInfo.ProductSpecID * proInfo.TradeAmount;//��������

                        proInfo.TradeMoney = proInfo.TradeWeight * proInfo.GoldTradePrice;  //���׽��
                        iTotalMoney += proInfo.TradeMoney;
                        iTotalWeight += proInfo.TradeWeight;

                        proInfo.StockLeft = (Convert.ToInt32(gvTrade2.Rows[i].Cells[3].Text.Replace(" ", "")) - proInfo.TradeAmount) * proInfo.ProductSpecID;//��ʣ������ʣ���
                        proInfos.Add(proInfo);
                    }
                }


                trInfo.FranchiserCode = Session["fran"].ToString().Trim();  //������id       

                trInfo.TradeTotalWeight = iTotalWeight;//������
                trInfo.TradeTotalMoney = iTotalMoney;//�ܽ��           


                trInfo.TradeState = "0";//���� ����Ϊ 0 
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

                        MessageBox.ShowAndRedirect(this, "�ύ�ɹ�...", "../franchiser_trade/Add.aspx");
                    }
                    else
                        MessageBox.Show(this, "�ύʧ��");

                }
                else
                {
                    MessageBox.Show(this, "�������");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "�ύ����" + ex.Message);
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
                // gvTrade.Rows[i].Cells[2].Text = gvTrade.Rows[i].Cells[2].Text.Trim() + " Ԫ/g";
                //  gvTrade.Rows[i].Cells[3].Text = gvTrade.Rows[i].Cells[3].Text.Trim() + " Ԫ/g";
                ((Label)gvTrade.Rows[i].FindControl("lblProdNum")).Text = " *" + gvTrade.Rows[i].Cells[1].Text.Trim();
            }
        }

        protected void gvTrade2_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTrade2.Rows.Count; i++)
            {
                gvTrade2.Rows[i].Cells[1].Text = gvTrade2.Rows[i].Cells[1].Text.Trim() + "g";
                //   gvTrade2.Rows[i].Cells[2].Text = gvTrade2.Rows[i].Cells[1].Text.Trim() + " Ԫ/g";
                ((Label)gvTrade2.Rows[i].FindControl("lblProdNum2")).Text = " *" + gvTrade2.Rows[i].Cells[1].Text.Trim();

            }
        }

        /// <summary>
        /// ��þ���������������������Ͳ��������ģ�
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

            //ʵʱ������� 
            string sCurPrice;//,sTradeAdd;         
            decimal curPrice;
            //�������(δ�����)�͵�����
            DataSet ds = null;
            decimal balance_money = 0;
            // decimal asure_money = 0;
            string strWhere = "franchiser_code='" + fran_code + "'";

            //�Ѷ���δ�ջ����ܼ�ֵ
            decimal unReceiveValue = 0;
            //�������ܼ�ֵ
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

                unReceiveValue = bll.GetGoldNoReceiveValue(fran_code); //�ƽ��ֵ  
                unReceiveValue += bll.GetSilverNoReceiveValue(fran_code);//������ֵ              

                stockValue = bll.GetGoldStockValue(fran_code);
                stockValue += bll.GetSilverStockValue(fran_code);

            }
            catch
            {
                MessageBox.Show(this, "��ȡ�������ʧ��");
                fran_name = "";
                assure_money = 0;
                fran_money = 0;
                money_use = 0;
                return;
            }

            //��ۿ������=�������-������-���������X���й��ƽ�ʵʱ�������+���ۼӼۣ�-����Ͳ�Ʒ�Ѷ�����δ�ջ���������X���й��ƽ�ʵʱ�������+���ۼӼ�)

            //��ۿ������=�������-������-����л�Ʒ��ֵ-�Ѷ���δ�ջ���Ʒ��ֵ

            // fran_money = balance_money - stockValue - unReceiveValue;//����������
            fran_money = balance_money;

            //update by tianjie 0516:������˵Ҫ��ȥ��������ļ�ֵ

            GoldTradeNaming.BLL.CommBaseBLL commBLL = new GoldTradeNaming.BLL.CommBaseBLL();
            money_use = fran_money - assure_money - commBLL.GetSilverStockValue(fran_code);         //������������
        }

        /// <summary>
        /// ������¼۸�
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
                MessageBox.Show(this, "��ȡ���¼۸�ʧ��");
                sCurPrice = "";
                return false;
            }
        }


    }
}
