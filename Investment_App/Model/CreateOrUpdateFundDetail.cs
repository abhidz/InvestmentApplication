using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment_App.Model
{
    public class CreateOrUpdateFundDetail
    {
        public int ID { get; set; }

        public string FundName { get; set; }

        public string Description { get; set; }
    }
}
