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
    
    public partial class TEAM
    {
        public TEAM()
        {
            this.GAME = new HashSet<GAME>();
            this.GAME1 = new HashSet<GAME>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
    
        public virtual ICollection<GAME> GAME { get; set; }
        public virtual ICollection<GAME> GAME1 { get; set; }
    }
}
