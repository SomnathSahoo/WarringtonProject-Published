using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarringtonEntity;
using WarringtonDAL;
using WarringtonDb;
using WarringtonHelper;

namespace WarringtonBll
{
    public class WarringtonBll
    {
        WarringtonDal objDal = null;

        public void SaveLoginHistory(List<LoginHistory> data)
        {
            try
            {
                objDal = new WarringtonDal();
                objDal.SaveLoginHistory(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public bool SaveUserMaster(List<UserMaster> userData)
        {
            long userId = 0;
            try
            {
                objDal = new WarringtonDal();
                userId = objDal.SaveUserMaster(userData);
                if (userId > 0)
                {
                    List<LoginHistory> lstLoginHistory = new List<LoginHistory>();
                    lstLoginHistory.Add(new LoginHistory()
                    {
                        UserId = userId,
                        ClientIp = Utility.GetLanIPAddress(),
                        Activity = "User Registration Process done",
                        EntryDate = DateTime.UtcNow
                    });

                    return objDal.SaveLoginHistory(lstLoginHistory) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
            return false;
        }

        public List<StateMaster> GetStateData()
        {
            try
            {
                objDal = new WarringtonDal();
                return objDal.GetStateData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public bool SaveUserRequest(UserRequest requestData, RequestStatus statusData, List<DocRepository> documentData)
        {
            long userId = 0;
            bool isSaved = false;
            try
            {
                objDal = new WarringtonDal();
                isSaved = objDal.SaveUserRequest(requestData, statusData, documentData);
                if (isSaved)
                {
                    List<LoginHistory> lstLoginHistory = new List<LoginHistory>();
                    lstLoginHistory.Add(new LoginHistory()
                    {
                        UserId = userId,
                        ClientIp = Utility.GetLanIPAddress(),
                        Activity = "Request submission Process done",
                        EntryDate = DateTime.UtcNow
                    });

                    return objDal.SaveLoginHistory(lstLoginHistory) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
            return false;
        }

        public bool IsUserRegistered(string phoneNo)
        {
            objDal=new WarringtonDal();
            return objDal.IsUserRegistered(phoneNo);
        }

        public bool UserIsAuthenticated(string userName, string password, out long userId)
        {
            userId = 0;
            bool isSaved = false;
            try
            {
                objDal = new WarringtonDal();
                isSaved = objDal.UserIsAuthenticated(userName, password,out userId);
                if (isSaved)
                {
                    List<LoginHistory> lstLoginHistory = new List<LoginHistory>();
                    lstLoginHistory.Add(new LoginHistory()
                    {
                        UserId = userId,
                        ClientIp = Utility.GetLanIPAddress(),
                        Activity = "User logged in",
                        EntryDate = DateTime.UtcNow
                    });

                    return objDal.SaveLoginHistory(lstLoginHistory) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
            return false;
        }

        public bool CheckPhoneNoExit(string phoneNo)
        {
            objDal = new WarringtonDal();
            return objDal.IsUserRegistered(phoneNo);
        }

        public List<UserRequest> SearchRequest(SearchParam objParam)
        {
            try
            {
                objDal = new WarringtonDal();
                return objDal.SearchRequest(objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
            return null;
        }
    }
}
