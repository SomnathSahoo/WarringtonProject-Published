//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WarringtonDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLoginHistory
    {
        public long RecordId { get; set; }
        public Nullable<long> UserId { get; set; }
        public string ClientIp { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Activity { get; set; }
    }
}
