using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// ʵ����sys_admin_authority ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

