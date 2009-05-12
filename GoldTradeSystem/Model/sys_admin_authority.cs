using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类sys_admin_authority 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class sys_admin_authority
	{
		public sys_admin_authority()
		{}
		#region Model
		private int _sys_admin_id;
		private string _sys_module;
		/// <summary>
		/// 
		/// </summary>
		public int sys_admin_id
		{
			set{ _sys_admin_id=value;}
			get{return _sys_admin_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sys_module
		{
			set{ _sys_module=value;}
			get{return _sys_module;}
		}
		#endregion Model

	}
}

