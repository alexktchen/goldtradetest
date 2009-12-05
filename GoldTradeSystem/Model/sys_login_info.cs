namespace GoldTradeNaming.Model
{
    using System;

    public class sys_login_info
    {
        private int _id;
        private string _ip;
        private string _login_id;
        private DateTime _login_time;

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string IP
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }

        public string login_ID
        {
            get
            {
                return this._login_id;
            }
            set
            {
                this._login_id = value;
            }
        }

        public DateTime login_time
        {
            get
            {
                return this._login_time;
            }
            set
            {
                this._login_time = value;
            }
        }
    }
}
