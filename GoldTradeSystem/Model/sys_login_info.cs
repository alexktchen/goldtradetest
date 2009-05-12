using System;
namespace GoldTradeNaming.Model
{
    /// <summary>
    /// 实体类sys_login_info 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class sys_login_info
    {
        public sys_login_info()
        {
        }
        #region Model
        private int _id;
        private string _ip;
        private DateTime _login_time;
        private string _login_id;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set
            {
                _ip = value;
            }
            get
            {
                return _ip;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime login_time
        {
            set
            {
                _login_time = value;
            }
            get
            {
                return _login_time;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string login_ID
        {
            set
            {
                _login_id = value;
            }
            get
            {
                return _login_id;
            }
        }
        #endregion Model

    }
}

