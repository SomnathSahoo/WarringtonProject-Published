using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarringtonEntity
{
    public enum TableEnum
    {
        UserMaster, UserRequest, RequestStatus, LoginHistories, DocRepository
    }

    public enum PageEnum
    {
        LoginPage=0,
        RegistrationPage=1,
        RequestSubmissionPage=2,
        RequestDashBoardPage=3
    }
}
