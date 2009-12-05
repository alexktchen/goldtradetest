namespace GoldTradeNaming.Model
{
    using System;

    public class product_type
    {
        private DateTime _ins_date;
        private string _ins_user;
        private decimal _order_add_price;
        private decimal _product_spec_weight;
        private string _product_state;
        private int _product_type_id;
        private string _product_type_name;
        private decimal _trade_add_price;
        private string _type;
        private DateTime _upd_date;
        private string _upd_user;

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

        public decimal product_spec_weight
        {
            get
            {
                return this._product_spec_weight;
            }
            set
            {
                this._product_spec_weight = value;
            }
        }

        public string product_state
        {
            get
            {
                return this._product_state;
            }
            set
            {
                this._product_state = value;
            }
        }

        public int product_type_id
        {
            get
            {
                return this._product_type_id;
            }
            set
            {
                this._product_type_id = value;
            }
        }

        public string product_type_name
        {
            get
            {
                return this._product_type_name;
            }
            set
            {
                this._product_type_name = value;
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

        public string type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
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
