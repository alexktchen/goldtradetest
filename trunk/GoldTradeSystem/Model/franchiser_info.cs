using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类franchiser_info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class franchiser_info
	{
		public franchiser_info()
		{}
		#region Model
		private int _franchiser_code;
		private string _franchiser_name;
		private decimal _franchiser_balance_money;
		private decimal _franchiser_asure_money;
		private string _franchiser_tel;
		private string _franchiser_cellphone;
		private string _franchiser_address;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
		private Guid _ia100guid;
		/// <summary>
		/// 经销商编号
		/// </summary>
		public int franchiser_code
		{
			set{ _franchiser_code=value;}
			get{return _franchiser_code;}
		}
		/// <summary>
		/// 经销商名称
		/// </summary>
		public string franchiser_name
		{
			set{ _franchiser_name=value;}
			get{return _franchiser_name;}
		}
		/// <summary>
		/// 帐面余额
		/// </summary>
		public decimal franchiser_balance_money
		{
			set{ _franchiser_balance_money=value;}
			get{return _franchiser_balance_money;}
		}
		/// <summary>
		/// 担保款
		/// </summary>
		public decimal franchiser_asure_money
		{
			set{ _franchiser_asure_money=value;}
			get{return _franchiser_asure_money;}
		}
		/// <summary>
		/// 经销商座机
		/// </summary>
		public string franchiser_tel
		{
			set{ _franchiser_tel=value;}
			get{return _franchiser_tel;}
		}
		/// <summary>
		/// 经销商手机
		/// </summary>
		public string franchiser_cellphone
		{
			set{ _franchiser_cellphone=value;}
			get{return _franchiser_cellphone;}
		}
		/// <summary>
		/// 经销商地址
		/// </summary>
		public string franchiser_address
		{
			set{ _franchiser_address=value;}
			get{return _franchiser_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ins_user
		{
			set{ _ins_user=value;}
			get{return _ins_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ins_date
		{
			set{ _ins_date=value;}
			get{return _ins_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string upd_user
		{
			set{ _upd_user=value;}
			get{return _upd_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime upd_date
		{
			set{ _upd_date=value;}
			get{return _upd_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid IA100GUID
		{
			set{ _ia100guid=value;}
			get{return _ia100guid;}
		}
		#endregion Model

	}
}

