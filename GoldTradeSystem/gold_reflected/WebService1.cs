namespace GoldTradeNaming.Web
{
    using GoldTradeNaming.BLL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Web.Script.Services;
    using System.Web.Services;

    [ToolboxItem(false), ScriptService, WebService(Namespace="http://tempuri.org/"), WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
    public class WebService1 : WebService
    {
        [WebMethod]
        public string[] GetCompleteDepart(string prefixText, int count)
        {
            IList<string> list = new List<string>();
            string strSql = " franchiser_name like '%" + prefixText.ToString().Trim() + "%'";
            DataSet ds = new GoldTradeNaming.BLL.franchiser_info().GetList(strSql);
            if ((ds != null) && (ds.Tables.Count > 0))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr["franchiser_name"].ToString());
                }
            }
            string[] matchResultList = new string[list.Count];
            int i = 0;
            foreach (string str in list)
            {
                matchResultList[i++] = str;
            }
            return matchResultList;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
