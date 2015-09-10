using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarringtonEntity;
using WarringtonSharePointService.SharePointService;

namespace WarringtonSharePointService
{
    public class WarringtonSPService
    {
        private const string ALICKEY="b7b92a53-8975-4d3e-97e2-33a5f3b1f76e";
        private const string ASSIGNEDUSERID = "sudipta@thethinkerz.com";
        private const string ASSIGNEDPASSWORD = "Bcn@8791";
        public void SaveUser(UserMaster objUser)
        {
            Service objService = new Service();
            var licKey = objService.GetUserLicKey(ALICKEY, ASSIGNEDUSERID, ASSIGNEDPASSWORD);
            Callers obj = new Callers() 
            {
                FirstName=objUser.FirstName,
                LastName=objUser.LastName,
                EmailAddress=objUser.EmailId,
                PhoneNumber=objUser.PrimaryPhoneNo,
                ZipCode=objUser.ZipCode.ToString(),
                AddressLine1=objUser.Address1,
                AddressLine2=objUser.Address2,
                TextMessageAddress=objUser.EmailId,
                Pin=objUser.PinNo,
                PinRequired=true
            };

            var response=objService.AddWebSubscriberInfo(licKey, obj, true);
            var res=objService.AddToBCNetwork(licKey, response.MemberId, response.NetWorkRefId, response.SponsorId);
            
        
        }
    }
}
    
