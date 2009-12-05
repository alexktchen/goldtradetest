namespace GoldTradeNaming.Model
{
    using System;

    public class TradeInfo
    {
        private string _franchisercode;
        private string _insUser;
        private decimal _realTimePrice;
        private string _tradeState;
        private decimal _tradeTotalMoney;
        private decimal _tradeTotalWeight;
        private string _updUser;

        public string FranchiserCode
        {
            get
            {
                return this._franchisercode;
            }
            set
            {
                this._franchisercode = value;
            }
        }

        public string InsUser
        {
            get
            {
                return this._insUser;
            }
            set
            {
                this._insUser = value;
            }
        }

        public decimal RealTimePrice
        {
            get
            {
                return this._realTimePrice;
            }
            set
            {
                this._realTimePrice = value;
            }
        }

        public string TradeState
        {
            get
            {
                return this._tradeState;
            }
            set
            {
                this._tradeState = value;
            }
        }

        public decimal TradeTotalMoney
        {
            get
            {
                return this._tradeTotalMoney;
            }
            set
            {
                this._tradeTotalMoney = value;
            }
        }

        public decimal TradeTotalWeight
        {
            get
            {
                return this._tradeTotalWeight;
            }
            set
            {
                this._tradeTotalWeight = value;
            }
        }

        public string UpdUser
        {
            get
            {
                return this._updUser;
            }
            set
            {
                this._updUser = value;
            }
        }
    }
}
