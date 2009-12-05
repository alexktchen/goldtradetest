namespace GoldTradeNaming.Model
{
    using System;

    public class franchiser_trade_desc
    {
        private int _id;
        private DateTime _ins_date;
        private string _ins_user;
        private int _product_id;
        private decimal _product_spec_id;
        private int _trade_id;
        private decimal _trade_weight;
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

        public int product_id
        {
            get
            {
                return this._product_id;
            }
            set
            {
                this._product_id = value;
            }
        }

        public decimal product_spec_id
        {
            get
            {
                return this._product_spec_id;
            }
            set
            {
                this._product_spec_id = value;
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

        public decimal trade_weight
        {
            get
            {
                return this._trade_weight;
            }
            set
            {
                this._trade_weight = value;
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
