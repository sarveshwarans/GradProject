//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookQueries
{
    using System;
    using System.Collections.Generic;
    
    public partial class Title
    {
        public Title()
        {
            this.Authors = new HashSet<Author>();
        }
    
        public string ISBN { get; set; }
        public string Title1 { get; set; }
        public int EditionNumber { get; set; }
        public string Copyright { get; set; }
    
        public virtual ICollection<Author> Authors { get; set; }
    }
}
