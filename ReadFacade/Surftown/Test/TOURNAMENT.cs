//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadFacade.Surftown.Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class TOURNAMENT
    {
        public TOURNAMENT()
        {
            this.GAME = new HashSet<GAME>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public int SERIES_SORT_ORDER_ID { get; set; }
        public int PLAYOFF_RULE_ID { get; set; }
    
        public virtual PLAYOFF_RULE PLAYOFF_RULE { get; set; }
        public virtual SERIES_SORT_ORDER SERIES_SORT_ORDER { get; set; }
        public virtual ICollection<GAME> GAME { get; set; }
    }
}
