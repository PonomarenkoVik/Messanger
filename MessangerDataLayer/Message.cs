//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessangerDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public long MessageId { get; set; }
        public long UserId { get; set; }
        public string Body { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual User User { get; set; }
    }
}
