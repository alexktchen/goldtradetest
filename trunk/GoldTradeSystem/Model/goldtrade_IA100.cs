using System;
namespace GoldTradeNaming.Model
{
	/// <summary>
	/// 实体类goldtrade_IA100 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class goldtrade_IA100
	{
		public goldtrade_IA100()
		{}
		#region Model
		private Guid _ia100guid;
		private string _ia100key;
		private string _ia100superpswd;
		private string _ia100state;
		private string _statechangereason;
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
		public string IA100Key
		{
			set{ _ia100key=value;}
			get{return _ia100key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IA100SuperPswd
		{
			set{ _ia100superpswd=value;}
			get{return _ia100superpswd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IA100State
		{
			set{ _ia100state=value;}
			get{return _ia100state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StateChangeReason
		{
			set{ _statechangereason=value;}
			get{return _statechangereason;}
		}
		#endregion Model

	}
}

