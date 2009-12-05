namespace GoldTradeNaming.Model
{
    using System;

    public class realtime_price
    {
        private int _id;
        private DateTime _ins_date;
        private string _ins_user;
        private decimal _order_add_price;
        private decimal _realtime_base_price;
        private DateTime _realtime_time;
        private int _sys_admin_id;
        private decimal _trade_add_price;
        private DateTime _upd_date;
        private string _upd_user;

        public int id
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

        public DateTime ins_date
        {
            get
            {
                return this._ins_date;
            }
            set
            {
                this._ins_date = value;
            }
        }

        public string ins_user
        {
            get
            {
                return this._ins_user;
            }
            set
            {
                this._ins_user = value;
            }
        }

        public decimal order_add_price
        {
            get
            {
                return this._order_add_price;
            }
            set
            {
                this._order_add_price = value;
            }
        }

        public decimal realtime_base_price
        {
            get
            {
                return this._realtime_base_price;
            }
            set
            {
                this._realtime_base_price = value;
            }
        }

        public DateTime realtime_time
        {
            get
            {
                return this._realtime_time;
            }
            set
            {
                this._realtime_time = value;
            }
        }

        public int sys_admin_id
        {
            get
            {
                return this._sys_admin_id;
            }
            set
            {
                this._sys_admin_id = value;
            }
        }

        public decimal trade_add_price
        {
            get
            {
                return this._trade_add_price;
            }
            set
            {
                this._trade_add_price = value;
            }
        }

        public DateTime upd_date
        {
            get
            {
                return this._upd_date;
            }
            set
            {
                this._upd_date = value;
            }
        }

        public string upd_user
        {
            get
            {
                return this._upd_user;
            }
            set
            {
                this._upd_user = value;
            }
        }
    }
}
