<%@ Page Language="C#" Description="IA100 ---ASP.NET" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="LTP.Common" %>
<script language="c#" runat="server">
    //实现MD5运算
    string softMD5(string str)
    {
        byte[] b = System.Text.Encoding.GetEncoding(1252).GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = "";
        for (int i = 0; i < b.Length; i++)
            ret += b[i].ToString("x").PadLeft(2, '0');
        return ret;
    }

    Byte[] hexstr2array(string HexStr)
    {
        string HEX = "0123456789ABCDEF";
        string str = HexStr.ToUpper();
        int len = str.Length;
        byte[] RetByte = new byte[len / 2];
        for (int i = 0; i < len / 2; i++)
        {
            int NumHigh = HEX.IndexOf(str[i * 2]);
            int NumLow = HEX.IndexOf(str[i * 2 + 1]);

            RetByte[i] = Convert.ToByte(NumHigh * 16 + NumLow);
        }
        return RetByte;
    }
</script>

<%
    string RandomStr = Session["Message"].ToString();//随机数
    string CDigest = Request.Form["Digest"];         //客户端摘要
    string SDigest = "";                             //服务器摘要
    string IAID = Request.Form["GUID"];              //IA100锁唯一ID
    Guid gIA100GUID = new Guid(IAID);
    string userkey = "";
    string sAdminId = "";

    string Conn = ConfigurationManager.AppSettings["ConnectionString"];
    using (SqlConnection connection = new SqlConnection(Conn))
    {
        StringBuilder ssql = new StringBuilder();
        ssql.Append("SELECT B.sys_admin_id, A.IA100Key  FROM goldtrade_IA100 A   JOIN goldtrade_db_admin B ");
        ssql.Append("ON A.IA100GUID = B.IA100GUID AND A.IA100GUID=@IA100GUID AND IA100State='0'");
        SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
        parameters[0].Value = gIA100GUID;


        SqlCommand cmd = new SqlCommand(ssql.ToString());
        cmd.Parameters.Add(parameters[0]);
        connection.Open();
        cmd.Connection = connection;
        DataSet ds;
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            ds = new DataSet();
            try
            {
                da.Fill(ds, "ds");
            }
            catch
            {
                Response.Write("<script language=\"javascript\">alert('登录时发生错误！'); window.location.href='AdminLogin.aspx';</script>");
                return;
            }
        }

        if (ds.Tables.Count > 0)
        {
            userkey = ds.Tables[0].Rows[0][1].ToString();
            sAdminId = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Response.Write("<script language=\"javascript\">alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "'); window.location.href='AdminLogin.aspx';</script>");
            return;
        }
    }

    SDigest = softMD5(RandomStr + userkey);    
    if (CDigest != SDigest)
    {
        Response.Write("<script language=\"javascript\">alert('" + "登录出错，请重新操作或联系管理员!" + "'); window.location.href='AdminLogin.aspx';</script>");
        return;
    }
    else
    {      
        Session["admin"] = sAdminId;
        Response.Redirect("../goldAdminIndex.aspx");
    }

%>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>IA100--test</title>
    <link href="CSS/IAtest.css" rel="stylesheet" type="text/css">
</head>
<body>
</body>
</html>
