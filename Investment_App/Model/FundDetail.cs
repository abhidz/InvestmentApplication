using System.Collections.Generic;

namespace Investment_App.Model
{
    public class FundDetail
    {
        public int ID { get; set; }

        public string FundName { get; set; }

        public string Description { get; set; }

        public int InvestedAmount { get; set; }

        public int CurrentValueOfInvestedAmount { get; set; }

        public string InvestorName { get; set; }

    }
}
