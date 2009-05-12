using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldTradeNaming.Model
{
    public class TradeInfo
    {
        private string _franchisercode;
        private decimal _realTimePrice;
        //  private decimal _goldTradePrice;
        // private decimal _tradeAddPrice;


        private int _tradeTotalWeight;
        private decimal _tradeTotalMoney;
        private string _tradeState;
        private string _insUser;
        //  private DateTime _insdate;
        private string _updUser;
        //   private DateTime _upddate;




        public TradeInfo()
        {

        }

        public string FranchiserCode
        {
            get
            {
                return _franchisercode;
            }
            set
            {
                _franchisercode = value;
            }
        }

        public decimal RealTimePrice
        {
            get
            {
                return _realTimePrice;
            }
            set
            {
                _realTimePrice = value;
            }
        }

        //public decimal GoldTradePrice
        //{
        //    get
        //    {
        //        return _goldTradePrice;
        //    }
        //    set
        //    {
        //        _goldTradePrice = value;
        //    }
        //}
        //public decimal TradeAddPrice
        //{
        //    get
        //    {
        //        return _tradeAddPrice;
        //    }
        //    set
        //    {
        //        _tradeAddPrice = value;
        //    }
        //}
        public int TradeTotalWeight
        {
            get
            {
                return _tradeTotalWeight;
            }
            set
            {
                _tradeTotalWeight = value;
            }
        }
        public decimal TradeTotalMoney
        {
            get
            {
                return _tradeTotalMoney;
            }
            set
            {
                _tradeTotalMoney = value;
            }
        }
        public string TradeState
        {
            get
            {
                return _tradeState;
            }
            set
            {
                _tradeState = value;
            }
        }
        public string InsUser
        {
            get
            {
                return _insUser;
            }
            set
            {
                _insUser = value;
            }
        }
        //public DateTime InsDate
        //{
        //    get
        //    {
        //        return _insdate;
        //    }
        //    set
        //    {
        //        _insdate = value;
        //    }
        //}
        public string UpdUser
        {
            get
            {
                return _updUser;
            }
            set
            {
                _updUser = value;
            }
        }
        //public DateTime UpdDate
        //{
        //    get
        //    {
        //        return _upddate;
        //    }
        //    set
        //    {
        //        _upddate = value;
        //    }
        //}


    }

    public class ProductInfo
    {
        private int _tradeId;
        private int _productID;
        private int _productSpecID;

        private decimal _realtimeBasePrice;
        private decimal _tradeAddPrice;
        private decimal _goldTradePrice;
        private decimal _tradeMoney;
        private int _tradeWeight;
        private int _stockleft;
        private int _tradeamount;

        //private string _productNum;
        //private string _productCount;

        public ProductInfo()
        {

        }


        public int TradeAmount
        {
            get
            {
                return _tradeamount;
            }
            set
            {
                _tradeamount = value;
            }
        }
        public decimal RealTimeBasePrice
        {
            get
            {
                return _realtimeBasePrice;
            }
            set
            {
                _realtimeBasePrice = value;
            }
        }

        public decimal TradeAddPrice
        {
            get
            {
                return _tradeAddPrice;
            }
            set
            {
                _tradeAddPrice = value;
            }
        }
        public decimal GoldTradePrice
        {
            get
            {
                return _goldTradePrice;
            }
            set
            {
                _goldTradePrice = value;
            }
        }
        public decimal TradeMoney
        {
            get
            {
                return _tradeMoney;
            }
            set
            {
                _tradeMoney = value;
            }
        }

        public int TradeId
        {
            get
            {
                return _tradeId;
            }
            set
            {
                _tradeId = value;
            }
        }
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }
        public int ProductSpecID
        {
            get
            {
                return _productSpecID;
            }
            set
            {
                _productSpecID = value;
            }
        }
        public int TradeWeight
        {
            get
            {
                return _tradeWeight;
            }
            set
            {
                _tradeWeight = value;
            }
        }
        public int StockLeft
        {
            get
            {
                return _stockleft;
            }
            set
            {
                _stockleft = value;
            }
        }
    }
}
