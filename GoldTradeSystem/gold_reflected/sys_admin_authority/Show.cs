namespace GoldTradeNaming.Web.sys_admin_authority
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        private GoldTradeNaming.BLL.sys_admin_authority bll = new GoldTradeNaming.BLL.sys_admin_authority();
        private GoldTradeNaming.BLL.goldtrade_db_admin bllAdmin = new GoldTradeNaming.BLL.goldtrade_db_admin();
        protected Button btnCancle;
        protected Button btnSave;
        protected Button btnSearch1;
        protected CheckBox ckbAddAdmin;
        protected CheckBox ckbAddFran;
        protected CheckBox ckbAddIA;
        protected CheckBox ckbAddMoney;
        protected CheckBox ckbAddProduct;
        protected CheckBox ckbAuthMgn;
        protected CheckBox ckbCheckAddMoney;
        protected CheckBox ckbChgFran;
        protected CheckBox ckbChgOrder;
        protected CheckBox ckbChgPrice;
        protected CheckBox ckbChgProduct;
        protected CheckBox ckbConOrder;
        private static string[] ckbControls = new string[] { 
            "AddAdmin", "AddFran", "AddIA", "AddMoney", "AddProduct", "AuthMgn", "CheckAddMoney", "ChgFran", "TradeLock", "ChgPrice", "ChgProduct", "ConOrder", "SearchIA", "Send", "StockMgn", "TradeReport", 
            "ViewAddMoney", "ViewAdmin", "ViewFran", "ViewOrder", "ViewPrice", "ViewProduct", "ViewTrade", "ViewStockLog", "StockView", "SendShow", "FranExcel", "TradeExcel", "StockExcel"
         };
        protected CheckBox ckbFranExcel;
        protected CheckBox ckbSearchIA;
        protected CheckBox ckbSend;
        protected CheckBox ckbSendShow;
        protected CheckBox ckbStockExcel;
        protected CheckBox ckbStockMgn;
        protected CheckBox ckbStockView;
        protected CheckBox ckbTradeExcel;
        protected CheckBox ckbTradeLock;
        protected CheckBox ckbTradeReport;
        protected CheckBox ckbViewAddMoney;
        protected CheckBox ckbViewAdmin;
        protected CheckBox ckbViewFran;
        protected CheckBox ckbViewOrder;
        protected CheckBox ckbViewPrice;
        protected CheckBox ckbViewProduct;
        protected CheckBox ckbViewStockLog;
        protected CheckBox ckbViewTrade;
        protected GridView grd_AdminInfo;
        protected HiddenField hdnAdminID;
        protected HiddenField hdnAdminNm;
        protected Label Label1;
        protected Label Label2;
        protected Label lblAdminName;
        protected Panel plAuth;
        protected Panel plSearch;
        protected Button Reset;
        protected TextBox txt_sysadmin_id;
        protected TextBox txtsys_admin_name;

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            this.plAuth.Visible = false;
            this.plSearch.Visible = true;
            this.InitCtrl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int adminID = Convert.ToInt32(this.hdnAdminID.Value.Trim());
                ArrayList alModule = new ArrayList(ckbControls.Length);
                ContentPlaceHolder cpHolder = (ContentPlaceHolder) base.Master.FindControl("ContentPlaceHolder1");
                Control ckb = null;
                foreach (string ctl in ckbControls)
                {
                    ckb = cpHolder.FindControl("ckb" + ctl);
                    if ((ckb != null) && ((CheckBox) ckb).Checked)
                    {
                        alModule.Add(ctl);
                    }
                }
                this.bll.Update(adminID, alModule);
                MessageBox.Show(this, "保存成功");
                this.plAuth.Visible = false;
                this.plSearch.Visible = true;
                this.InitCtrl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "保存错误:" + ex.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int adminID = -1;
            string adminName = string.Empty;
            if (this.txt_sysadmin_id.Text.Trim() != string.Empty)
            {
                try
                {
                    adminID = Convert.ToInt32(this.txt_sysadmin_id.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "请输入正确的管理员编号");
                    return;
                }
            }
            adminName = this.txtsys_admin_name.Text.Trim();
            try
            {
                DataSet ds = this.bllAdmin.GetList(adminID, adminName, false);
                this.Session["grd_Data"] = ds;
                this.grd_AdminInfo.DataSource = ds;
                this.grd_AdminInfo.DataBind();
            }
            catch (Exception ex)
            {
                this.Session["grd_Data"] = null;
                this.grd_AdminInfo.DataSource = null;
                this.grd_AdminInfo.DataBind();
                MessageBox.Show(this, "查询错误:" + ex.ToString());
            }
        }

        protected void grd_AdminInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grd_AdminInfo.PageIndex = e.NewPageIndex;
            this.grd_AdminInfo.DataSource = this.Session["grd_Data"] as DataSet;
            this.grd_AdminInfo.DataBind();
        }

        protected void grd_AdminInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.plAuth.Visible = true;
                this.plSearch.Visible = false;
                this.lblAdminName.Text = this.grd_AdminInfo.Rows[this.grd_AdminInfo.SelectedIndex].Cells[1].Text.Trim();
                this.hdnAdminID.Value = this.grd_AdminInfo.Rows[this.grd_AdminInfo.SelectedIndex].Cells[0].Text.Trim();
                this.ShowAuth();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void InitCtrl()
        {
            ContentPlaceHolder cpHolder = (ContentPlaceHolder) base.Master.FindControl("ContentPlaceHolder1");
            foreach (string s in ckbControls)
            {
                ((CheckBox) cpHolder.FindControl("ckb" + s)).Checked = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AuthMgn.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                DataSet ds = this.bllAdmin.GetList(-1, string.Empty, true);
                if (ds != null)
                {
                    this.grd_AdminInfo.DataSource = ds;
                    this.grd_AdminInfo.DataBind();
                    this.Session["grd_Data"] = ds;
                }
                this.btnSave.Attributes.Add("onclick", "return confirm('確定要保存吗?')");
                this.plAuth.Visible = false;
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "权限管理";
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            this.txtsys_admin_name.Text = "";
            this.txt_sysadmin_id.Text = "";
            this.grd_AdminInfo.SelectedIndex = -1;
        }

        private void ShowAuth()
        {
            string strWhere = "sys_admin_id='" + this.hdnAdminID.Value + "'; ";
            ContentPlaceHolder cpHolder = (ContentPlaceHolder) base.Master.FindControl("ContentPlaceHolder1");
            try
            {
                DataSet ds = this.bll.GetList(strWhere);
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string module = ds.Tables[0].Rows[i]["sys_module"].ToString().Trim();
                        foreach (string s in ckbControls)
                        {
                            if (module == s)
                            {
                                ((CheckBox) cpHolder.FindControl("ckb" + s)).Checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
    }
}
