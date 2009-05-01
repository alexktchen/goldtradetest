using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类goldtrade_db_admin 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class goldtrade_db_admin
	{
		public goldtrade_db_admin()
		{}
		#region Model
		private int _sys_admin_id;
		private string _sys_admin_name;
		private string _sys_admin_tel;
		private string _sys_admin_cellphone;
		private Guid _ia100guid;
		private string _ins_user;
		private DateTime _ins_date;
		private string _upd_user;
		private DateTime _upd_date;
		/// <summary>
		/// 管理员帐号
		/// </summary>
		public int sys_admin_id
		{
			set{ _sys_admin_id=value;}
			get{return _sys_admin_id;}
		}
		/// <summary>
		/// 管理员姓名
		/// </summary>
		public string sys_admin_name
		{
			set{ _sys_admin_name=value;}
			get{return _sys_admin_name;}
		}
		/// <summary>
		/// 管理员TEl
		/// </summary>
		public string sys_admin_tel
		{
			set{ _sys_admin_tel=value;}
			get{return _sys_admin_tel;}
		}
		/// <summary>
		/// 管理员手机
		/// </summary>
		public string sys_admin_cellphone
		{
			set{ _sys_admin_cellphone=value;}
			get{return _sys_admin_cellphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid IA100GUID
		{
			set{ _ia100guid=value;}
			get{return _ia100guid;}
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
		#endregion Model

	}
}

