namespace GoldTradeNaming.Model
{
    using System;

    public class ProductInfo
    {
        private decimal _goldTradePrice;
        private int _productID;
        private decimal _productSpecID;
        private decimal _realtimeBasePrice;
        private decimal _stockleft;
        private decimal _tradeAddPrice;
        private int _tradeamount;
        private int _tradeId;
        private decimal _tradeMoney;
        private decimal _tradeWeight;

        public decimal GoldTradePrice
        {
            get
            {
                return this._goldTradePrice;
            }
            set
            {
                this._goldTradePrice = value;
            }
        }

        public int ProductID
        {
            get
            {
                return this._productID;
            }
            set
            {
                this._productID = value;
            }
        }

        public decimal ProductSpecID
        {
            get
            {
                return this._productSpecID;
            }
            set
            {
                this._productSpecID = value;
            }
        }

        public decimal RealTimeBasePrice
        {
            get
            {
                return this._realtimeBasePrice;
            }
            set
            {
                this._realtimeBasePrice = value;
            }
        }

        public decimal StockLeft
        {
            get
            {
                return this._stockleft;
            }
            set
            {
                this._stockleft = value;
            }
        }

        public decimal TradeAddPrice
        {
            get
            {
                return this._tradeAddPrice;
            }
            set
            {
                this._tradeAddPrice = value;
            }
        }

        public int TradeAmount
        {
            get
            {
                return this._tradeamount;
            }
            set
            {
                this._tradeamount = value;
            }
        }

        public int TradeId
        {
            get
            {
                return this._tradeId;
            }
            set
            {
                this._tradeId = value;
            }
        }

        public decimal TradeMoney
        {
            get
            {
                return this._tradeMoney;
            }
            set
            {
                this._tradeMoney = value;
            }
        }

        public decimal TradeWeight
        {
            get
            {
                return this._tradeWeight;
            }
            set
            {
                this._tradeWeight = value;
            }
        }
    }
}
