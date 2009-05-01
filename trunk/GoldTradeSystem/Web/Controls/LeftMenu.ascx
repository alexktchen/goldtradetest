<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="GoldTradeNaming.Web.Controls.LeftMenu" %>
<table width="200" height="250" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="38">
                        <img height="38" src="../image/leftlist_head.jpg" width="200" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" 
                        style="background-image: url('../image/leftlist_bg.jpg')" >

		            <script language="javascript" id="clientEventHandlersJS">
<!--
var number=8;

function LMYC() {
var lbmc;
//var treePic;
    for (i=1;i<=number;i++) {
        lbmc = eval('LM' + i);
        //treePic = eval('treePic'+i);
        //treePic.src = '../images/file.gif';
        lbmc.style.display = 'none';
    }
}
 
function ShowFLT(i) {
    lbmc = eval('LM' + i);
    //treePic = eval('treePic' + i)
    if (lbmc.style.display == 'none') {
        LMYC();
        //treePic.src = '../images/nofile.gif';
        lbmc.style.display = '';
    }
    else {
        //treePic.src = '../images/file.gif';
        lbmc.style.display = 'none';
    }
}
//-->
      </script>

                        <table cellspacing="0" cellpadding="0" width="88%" border="0">
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" alt="" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(1)" href="javascript:void(null)">金价管理</a>
                                </td>
                            </tr>
                            <tr id="LM1" style="display: none">
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr id="trChgPrice" runat="server" >
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">                                                
                                               <asp:HyperLink ID="HyperLink11"  NavigateUrl="~/realtime_price/Add.aspx" runat="server">修改实时金价</asp:HyperLink>
                                            </td>
                                        </tr>
                                       
                                        <tr id="trViewPrice" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink10"  NavigateUrl="~/realtime_price/Show.aspx" runat="server">查看实时金价</asp:HyperLink>
                                            </td>
                                        </tr>
                                    
                                        </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle"/>
                                    <a onclick="javascript:ShowFLT(2)" href="javascript:void(null)">订单管理</a>
                                </td>
                            </tr>
                            <tr id="LM2" style="display: none">
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr id="trViewOrder" runat = "server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle"/>
                                                <asp:HyperLink ID="HyperLink1"  NavigateUrl="~/franchiser_order/Modify.aspx?type=0" runat="server">查看订单</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr id="trConOrder" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink2" NavigateUrl="~/franchiser_order/Modify.aspx?type=1"  runat="server">确认订单</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                   <%--     <tr>
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../images/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink3" NavigateUrl="~/franchiser_order/Modify.aspx?type=2" runat="server">修改订单</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  height="3">
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                               <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(7)" href="javascript:void(null)">交易管理</a>
                                </td>
                            </tr>
                            <tr id="LM7" style="display: none">
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr  id="trViewTrade" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink3"  NavigateUrl="~/franchiser_trade/ShowM.aspx" runat="server">查看交易</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trTradeReport" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink20"  NavigateUrl="~/franchiser_order_desc/SalesReport.aspx" runat="server">销售报表</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trTradeLock" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink21"  NavigateUrl="~/franchiser_trade/TradeTime.aspx" runat="server">交易时间锁定</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(3)" href="javascript:void(null)">财务管理</a>
                                </td>
                            </tr>
                            <tr id="LM3" style="display: none">
                                <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr  id="trViewAddMoney" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink17"  NavigateUrl="~/franchiser_money/Show.aspx" runat="server">查看入帐</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trAddMoney" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink18"  NavigateUrl="~/franchiser_money/Add.aspx" runat="server">添加入帐</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trCheckAddMoney" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink19" NavigateUrl="~/franchiser_money/Manage.aspx"  runat="server">审核入帐</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(8)" href="javascript:void(null)">库存管理</a>
                                </td>
                            </tr>
                            <tr id="LM8" style="display: none">
                                <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr id="tr2" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink22"  NavigateUrl="~/stock_main/stockModifyLog.aspx" runat="server">查看修改记录</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                         <tr id="tr3" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink23" NavigateUrl="~/stock_main/Show.aspx"  runat="server">修改库存</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(4)" href="javascript:void(null)">产品管理</a>
                                </td>
                            </tr>
                            <tr id="LM4" style="display: none">
                                <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr id="trViewProduct" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink4"  NavigateUrl="~/product_type/Show.aspx" runat="server">查看产品</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                         <tr id="trChgProduct" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink5" NavigateUrl="~/product_type/Modify_index.aspx"  runat="server">修改产品</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                         <tr id="trAddProduct" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink6" NavigateUrl="~/product_type/Add_index.aspx" runat="server">添加产品</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(5)" href="javascript:void(null)">经销商管理</a>
                                </td>
                            </tr>
                            <tr id="LM5" style="display: none">
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr id="trViewFran" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink9"  NavigateUrl="~/franchiser_info/ShowNoEdit.aspx" runat="server">查看经销商</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr id="trChgFran" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink7"  NavigateUrl="~/franchiser_info/Show.aspx" runat="server">修改经销商</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr id="trAddFran" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                               <asp:HyperLink ID="HyperLink8" NavigateUrl="~/franchiser_info/Add.aspx"  runat="server">添加经销商</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                     
                            <tr>
                                <td style="padding-left: 20px"  height="28">
                                    <img height="9" src="../image/bit06.gif" width="8" align="middle">
                                    <a onclick="javascript:ShowFLT(6)" href="javascript:void(null)">系统管理</a>
                                </td>
                            </tr>
                            <tr id="LM6" style="display: none">
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr  id="trAddAdmin" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink12"  NavigateUrl="~/goldtrade_db_admin/Add.aspx" runat="server">添加管理员</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trViewAdmin" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink13"  NavigateUrl="~/goldtrade_db_admin/Show.aspx" runat="server">查看管理员</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trAuthMgn" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink14"  NavigateUrl="~/sys_admin_authority/Show.aspx" runat="server">权限管理</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trSearchIA" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                               <asp:HyperLink ID="HyperLink15"  NavigateUrl="~/goldtrade_IA100/Show.aspx" runat="server">认证锁查询</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                        <tr  id="trAddIA" runat="server">
                                            <td style="padding-left: 40px" height="28">
                                                <img height="7" src="../image/bit06.gif" width="8" align="middle">
                                                <asp:HyperLink ID="HyperLink16"  NavigateUrl="~/goldtrade_IA100/Add.aspx" runat="server">认证锁添加</asp:HyperLink>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                           
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="17">
                        <img height="17" src="../image/leftlist_bottom.jpg" width="200" />
                    </td>
                </tr>
            </table>
 