using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarringtonEntity
{
    public class UserMaster
    {
        public long UserID { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> ZipCode { get; set; }
        public string CityName { get; set; }
        public Nullable<int> StateId { get; set; }
        public string PrimaryPhoneNo { get; set; }
        public string PrimaryPhoneType { get; set; }
        public string PrimaryMobileProvider { get; set; }
        public string SecondaryPhoneNo { get; set; }
        public string SecondaryPhoneType { get; set; }
        public string SecondaryMobileProvider { get; set; }
        public string PrefferedContactMethod { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string PinNo { get; set; }
        public Nullable<bool> Active { get; set; }

    }

    public partial class UserRequest
    {
        public long RequestId { get; set; }
        public string RequestNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<long> ZipCode { get; set; }
        public string CityName { get; set; }
        public Nullable<int> StateId { get; set; }
        public string PrimaryPhoneNo { get; set; }
        public string PrimaryPhoneType { get; set; }
        public string PrimaryMobileProvider { get; set; }
        public string SecondaryPhoneNo { get; set; }
        public string SecondaryPhoneType { get; set; }
        public string SecondaryMobileProvider { get; set; }
        public string EmailId { get; set; }
        public string PrefContactMethod { get; set; }
        public string ProblemLocation { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AttachedDocName { get; set; }
        public Nullable<bool> EmailConfirmation { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Status { get; set; }
    }

    public partial class LoginHistory
    {
        public int RecordId { get; set; }
        public Nullable<long> UserId { get; set; }
        public string ClientIp { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Activity { get; set; }
    }

    public partial class RequestStatus
    {
        public long RecordId { get; set; }
        public Nullable<long> RequestId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
    }

    public partial class DocRepository
    {
        public long RecId { get; set; }
        public Nullable<long> RequestId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
    }

    public partial class StateMaster
    {
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public Nullable<bool> Active { get; set; }
    }

    public class SearchParam
    {
        public string UserId { get; set; }
        public string RequestNo { get; set; }
        public string RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public string CompareOperator { get; set; }
        public int NoOfData { get; set; }
    }
}
