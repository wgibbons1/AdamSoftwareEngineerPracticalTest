using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContact
{
    public static class SaleLevelExtensions
    {
        public static string GetMinText(this SaleLevels saleLevel) {
            return saleLevel switch
            {
                SaleLevels.NoMovement_NotInterested => "No movement / not interested",
                SaleLevels.SomeInterest => "Some interest",
                SaleLevels.Interested => "Interested",
                SaleLevels.Sold => "Sold",
                _ => throw new Exception()
            };
        }
        public static string GetMaxText(this SaleLevels saleLevel) {
            return saleLevel switch
            {
                SaleLevels.NoMovement_NotInterested => "No movement / not interested",
                SaleLevels.SomeInterest => "Some interest (need to create a sales package and send to them)",
                SaleLevels.Interested => "Interested (need to book a meeting and try and get a solid sell)",
                SaleLevels.Sold => "Sold (customer has agreed to sign up)",
                _ => throw new Exception()
            };
        }
    }
}
