namespace GoldTradeNaming.Model
{
    using System;

    public class franchiser_trade
    {
        private string _canceled_reason;
        private int _franchiser_code;
        private decimal _gold_trade_price;
        private DateTime _ins_date;
        private string _ins_user;
        private decimal _realtime_base_price;
        private decimal _trade_add_price;
        private int _trade_id;
        private string _trade_state;
        private DateTime _trade_time;
        private decimal _trade_total_money;
        private decimal _trade_total_weight;
        private DateTime _upd_date;
        private string _upd_user;

        public string canceled_reason
        {
            get
            {
                return this._canceled_reason;
            }
            set
            {
                this._canceled_reason = value;
            }
        }

        public int franchiser_code
        {
            get
            {
                return this._franchiser_code;
            }
            set
            {
                this._franchiser_code = value;
            }
        }

        public decimal gold_trade_price
        {
            get
            {
                return this._gold_trade_price;
            }
            set
            {
                this._gold_trade_price = value;
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

        public int trade_id
        {
            get
            {
                return this._trade_id;
            }
            set
            {
                this._trade_id = value;
            }
        }

        public string trade_state
        {
            get
            {
                return this._trade_state;
            }
            set
            {
                this._trade_state = value;
            }
        }

        public DateTime trade_time
        {
            get
            {
                return this._trade_time;
            }
            set
            {
                this._trade_time = value;
            }
        }

        public decimal trade_total_money
        {
            get
            {
                return this._trade_total_money;
            }
            set
            {
                this._trade_total_money = value;
            }
        }

        public decimal trade_total_weight
        {
            get
            {
                return this._trade_total_weight;
            }
            set
            {
                this._trade_total_weight = value;
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
