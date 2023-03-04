using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MpaGoPay.Domain.Enums;

namespace MpaGoPay.Domain.Entities
{
    public class CardRecharge : BaseEntity
    {
        public CardRecharge(Card card)
        {
            Card = card;
        }
        public Card Card { get; set; }  
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public MeansOfPayment MeansOfPayment { get; set; }
    }
}
