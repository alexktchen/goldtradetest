namespace GoldTradeNaming.Model
{
    using System;

    public class franchiser_order_desc
    {
        private int _franchiser_order_id;
        private int _id;
        private DateTime _ins_date;
        private string _ins_user;
        private decimal _order_add_price;
        private decimal _order_appraise;
        private int _order_product_amount;
        private decimal _order_weight;
        private int _product_id;
        private decimal _product_received;
        private decimal _product_spec_id;
        private decimal _product_unreceived;
        private decimal _realtime_base_price;
        private DateTime _upd_date;
        private string _upd_user;

        public int franchiser_order_id
        {
            get
            {
                return this._franchiser_order_id;
            }
            set
            {
                this._franchiser_order_id = value;
            }
        }

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

        public decimal order_appraise
        {
            get
            {
                return this._order_appraise;
            }
            set
            {
                this._order_appraise = value;
            }
        }

        public int order_product_amount
        {
            get
            {
                return this._order_product_amount;
            }
            set
            {
                this._order_product_amount = value;
            }
        }

        public decimal order_weight
        {
            get
            {
                return this._order_weight;
            }
            set
            {
                this._order_weight = value;
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

        public decimal product_received
        {
            get
            {
                return this._product_received;
            }
            set
            {
                this._product_received = value;
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

        public decimal product_unreceived
        {
            get
            {
                return this._product_unreceived;
            }
            set
            {
                this._product_unreceived = value;
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
