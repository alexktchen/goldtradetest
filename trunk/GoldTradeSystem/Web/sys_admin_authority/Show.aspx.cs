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

namespace GoldTradeNaming.Web.sys_admin_authority
{
    public partial class Show : System.Web.UI.Page
    {
        private static string[] ckbControls = { "AddAdmin","AddFran","AddIA","AddMoney","AddProduct","AuthMgn","CheckAddMoney","ChgFran","TradeLock",
                                       "ChgPrice","ChgProduct","ConOrder","SearchIA","Send","StockMgn","TradeReport","ViewAddMoney","ViewAdmin",
                                       "ViewFran","ViewOrder","ViewPrice","ViewProduct","ViewTrade" ,"ViewStockLog","StockView","SendShow","FranExcel","TradeExcel","StockExcel"};
        GoldTradeNaming.BLL.sys_admin_authority bll = new GoldTradeNaming.BLL.sys_admin_authority();
        GoldTradeNaming.BLL.goldtrade_db_admin bllAdmin = new GoldTradeNaming.BLL.goldtrade_db_admin();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "Ȩ�޹���";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AuthMgn.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                DataSet ds = bllAdmin.GetList(-1, String.Empty, true);
                if (ds != null)
                {
                    grd_AdminInfo.DataSource = ds;
                    grd_AdminInfo.DataBind();
                    Session["grd_Data"] = ds;
                }

                btnSave.Attributes.Add("onclick", "return confirm('" + "�_��Ҫ������?" + "')");
                plAuth.Visible = false;

            }
        }
        protected void grd_AdminInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grd_AdminInfo.PageIndex = e.NewPageIndex;
            this.grd_AdminInfo.DataSource = Session["grd_Data"] as DataSet;
            this.grd_AdminInfo.DataBind();
        }

        protected void grd_AdminInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                plAuth.Visible = true;
                plSearch.Visible = false;
                lblAdminName.Text = grd_AdminInfo.Rows[grd_AdminInfo.SelectedIndex].Cells[1].Text.Trim();
                hdnAdminID.Value = grd_AdminInfo.Rows[grd_AdminInfo.SelectedIndex].Cells[0].Text.Trim();
                ShowAuth();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            plAuth.Visible = false;
            plSearch.Visible = true;
            InitCtrl();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            txtsys_admin_name.Text = "";
            txt_sysadmin_id.Text = "";
            grd_AdminInfo.SelectedIndex = -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int adminID = Convert.ToInt32(hdnAdminID.Value.Trim());
                ArrayList alModule = new ArrayList(ckbControls.Length);

                ContentPlaceHolder cpHolder;
                cpHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

                System.Web.UI.Control ckb = null;
                foreach (string ctl in ckbControls)
                {
                    ckb = cpHolder.FindControl("ckb" + ctl);

                    if (ckb != null && ((CheckBox)ckb).Checked)
                    {
                        alModule.Add(ctl);
                    }
                }
                bll.Update(adminID, alModule);
                MessageBox.Show(this, "����ɹ�");
                plAuth.Visible = false;
                plSearch.Visible = true;
                InitCtrl();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "�������:" + ex.ToString());
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int adminID = -1;
            string adminName = String.Empty;

            if (txt_sysadmin_id.Text.Trim() != String.Empty)
            {
                try
                {
                    adminID = Convert.ToInt32(txt_sysadmin_id.Text.Trim());

                }
                catch
                {
                    MessageBox.Show(this, "��������ȷ�Ĺ���Ա���");
                    return;
                }
            }
            adminName = txtsys_admin_name.Text.Trim();
            
            try
            {
                DataSet ds = bllAdmin.GetList(adminID, adminName, false);
                Session["grd_Data"] = ds;
                this.grd_AdminInfo.DataSource = ds;
                this.grd_AdminInfo.DataBind();

              //  MessageBox.Show(this, "��ѯ�ɹ�");
            }
            catch (Exception ex)
            {
                Session["grd_Data"] = null;
                this.grd_AdminInfo.DataSource = null;
                this.grd_AdminInfo.DataBind();
                MessageBox.Show(this, "��ѯ����:" + ex.ToString());
            }
        }
        private void InitCtrl()
        {
            ContentPlaceHolder cpHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            foreach (string s in ckbControls)
            {
                ((CheckBox)cpHolder.FindControl("ckb" + s)).Checked = false;
            }
        }

        private void ShowAuth()
        {
            string strWhere = "sys_admin_id='" + hdnAdminID.Value + "'; ";

            ContentPlaceHolder cpHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

            try
            {
                DataSet ds = bll.GetList(strWhere);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string module = ds.Tables[0].Rows[i]["sys_module"].ToString().Trim();
                        foreach (string s in ckbControls)
                        {
                            if (module == s)
                            {
                                ((CheckBox)cpHolder.FindControl("ckb" + s)).Checked = true;
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
