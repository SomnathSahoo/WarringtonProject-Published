using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarringtonDb;
using WarringtonEntity;
using System.Data.Linq;

namespace WarringtonDAL
{
    public class WarringtonDal
    {
        public int SaveLoginHistory(List<LoginHistory> data)
        {
            int returnValue = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        foreach (LoginHistory objItem in data)
                        {

                            var count = context.tblLoginHistories.Count(r => r.RecordId == objItem.RecordId);
                            if (count == 0)
                            {
                                tblLoginHistory objLoginHistory = new tblLoginHistory();
                                PropertyInfo[] userProperties = objLoginHistory.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual == false).ToArray(); ;
                                foreach (PropertyInfo item in userProperties)
                                {
                                    PropertyInfo dataProperty = objItem.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                    item.SetValue(objLoginHistory, dataProperty.GetValue(objItem), null);
                                }
                                context.tblLoginHistories.Add(objLoginHistory);
                            }
                        }
                        returnValue = context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw ex;
                    }
                }
            }
            return returnValue;
        }

        public long SaveUserMaster(List<UserMaster> userData)
        {
            long userId = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        tblUser objUser = new tblUser();
                        foreach (UserMaster objItem in userData)
                        {

                            var count = context.tblUsers.Count(r => r.PrimaryPhoneNo == objItem.PrimaryPhoneNo);
                            if (count == 0)
                            {
                                PropertyInfo[] userProperties = objUser.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual == false).ToArray();
                                foreach (PropertyInfo item in userProperties)
                                {
                                    PropertyInfo dataProperty = objItem.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                    item.SetValue(objUser, dataProperty.GetValue(objItem), null);
                                }
                                context.tblUsers.Add(objUser);
                            }
                            else
                            {
                                objUser = context.tblUsers.Where(r => r.PrimaryPhoneNo == objItem.PrimaryPhoneNo).Single<tblUser>();
                                context.tblUsers.Where(r => r.PrimaryPhoneNo == objItem.PrimaryPhoneNo).ToList().ForEach(p =>
                                {
                                    PropertyInfo[] userProperties = p.GetType().GetProperties().Where(r => r.GetMethod.IsVirtual == false).ToArray();
                                    foreach (PropertyInfo item in userProperties.Skip(1))
                                    {
                                        PropertyInfo dataProperty = objItem.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                        item.SetValue(p, dataProperty.GetValue(objItem), null);
                                    }
                                });
                            }
                        }
                        context.SaveChanges();
                        context.Entry(objUser).GetDatabaseValues();
                        userId = objUser.UserID;
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw ex;
                    }
                }
            }
            return userId;
        }

        public bool SaveUserRequest(UserRequest requestData, RequestStatus statusData, List<DocRepository> documentData)
        {
            long requestId = 0;
            long statusId = 0; long docId = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        tblUserRequest objUserRequest = new tblUserRequest();
                        var sql = "SELECT COUNT(1) FROM dbo.tblUserRequest where RequestId=" + requestData.RequestId;
                        var count = context.Database.SqlQuery<int>(sql).Single();
                        if (count == 0)
                        {
                            requestData.RequestNo = GenerateRequestNo();
                            PropertyInfo[] userProperties = objUserRequest.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual == false).ToArray();
                            foreach (PropertyInfo item in userProperties)
                            {
                                PropertyInfo dataProperty = requestData.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                item.SetValue(objUserRequest, dataProperty.GetValue(requestData), null);
                            }
                            context.tblUserRequests.Add(objUserRequest);
                        }
                        else
                        {
                            objUserRequest = context.tblUserRequests.Where(r => r.RequestId == requestData.RequestId).Single<tblUserRequest>(); ;
                            context.tblUserRequests.Where(r => r.RequestId == requestData.RequestId).ToList().ForEach(p =>
                            {
                                PropertyInfo[] userProperties = p.GetType().GetProperties().Where(r => r.GetMethod.IsVirtual == false).ToArray();
                                foreach (PropertyInfo item in userProperties.Skip(1))
                                {
                                    PropertyInfo dataProperty = requestData.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                    item.SetValue(p, dataProperty.GetValue(requestData), null);
                                }
                            });
                        }

                        context.SaveChanges();
                        context.Entry(objUserRequest).GetDatabaseValues();
                        requestId = objUserRequest.RequestId;

                        tblDocRepository objDocRepository = new tblDocRepository();
                        foreach (DocRepository objItem in documentData)
                        {
                            objItem.RequestId = requestId;
                            var sqlDoc = "SELECT COUNT(1) FROM dbo.tblDocRepository where RecId=" + objItem.RecId;
                            var countDoc = context.Database.SqlQuery<int>(sqlDoc).Single();
                            if (countDoc == 0)
                            {
                                PropertyInfo[] userProperties = objDocRepository.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual == false).ToArray();
                                foreach (PropertyInfo item in userProperties.Skip(1))
                                {
                                    PropertyInfo dataProperty = objItem.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                    item.SetValue(objDocRepository, dataProperty.GetValue(objItem), null);
                                }
                                context.tblDocRepositories.Add(objDocRepository);
                                context.SaveChanges();
                            }
                            docId++;
                        }


                        tblRequestStatu objRequestStatus = new tblRequestStatu();

                        statusData.RequestId = requestId;
                        var sqlStatus = "SELECT COUNT(1) FROM dbo.tblRequestStatus where RecordId=" + statusData.RecordId;
                        var countStatus = context.Database.SqlQuery<int>(sqlStatus).Single();
                        if (countStatus == 0)
                        {
                            PropertyInfo[] userProperties = objRequestStatus.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual == false).ToArray();
                            foreach (PropertyInfo item in userProperties.Skip(1))
                            {
                                PropertyInfo dataProperty = statusData.GetType().GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance);
                                item.SetValue(objRequestStatus, dataProperty.GetValue(statusData), null);
                            }
                            context.tblRequestStatus.Add(objRequestStatus);
                        }
                        context.SaveChanges();
                        if (statusData != null)
                        {
                            context.Entry(objRequestStatus).GetDatabaseValues();
                            statusId = objRequestStatus.RecordId;
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return requestId > 0 && statusId > 0 && documentData.Count == docId;
        }

        public List<StateMaster> GetStateData()
        {
            List<StateMaster> lstStates = new List<StateMaster>();
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    context.tblStateMasters.Where(r => r.Active == true).ToList().ForEach(p =>
                    {
                        lstStates.Add(new StateMaster() { StateId = p.StateId, StateName = p.StateName });
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lstStates;
        }

        public bool IsUserRegistered(string phoneNo)
        {
            var count = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    var users = context.tblUsers.Where(r => r.PrimaryPhoneNo == phoneNo).Select(p => p.UserID).ToList();
                    count = users.Count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return count > 0;
        }

        public bool UserIsAuthenticated(string userName, string password, out long userId)
        {
            var count = 0; userId = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    var objUser = context.tblUsers.Where<tblUser>(r => r.PrimaryPhoneNo == userName && r.PinNo == password);
                    if (objUser != null)
                    {
                        userId = objUser.Select(r => r.UserID).FirstOrDefault();
                        count = objUser.Count();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return count > 0 && userId > 0;
        }

        public string GenerateRequestNo()
        {
            string maxRequestNo = "";
            string requestNo = "";
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    var sql = "SELECT COUNT(1) FROM dbo.tblUserRequest";
                    var count = context.Database.SqlQuery<int>(sql).Single();

                    if (count > 0)
                    {
                        maxRequestNo = context.tblUserRequests.OrderByDescending(p => p.RequestId).Select(r => r.RequestNo).FirstOrDefault();

                    }
                    if (string.IsNullOrEmpty(maxRequestNo))
                    {
                        requestNo = "WTP-" + (1).ToString().PadLeft(6, '0');
                    }
                    else
                    {
                        long maxNo = Convert.ToInt64(maxRequestNo.Substring(4));
                        requestNo = "WTP-" + (maxNo + 1).ToString().PadLeft(6, '0');

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return requestNo;
        }

        public bool CheckPhoneNoExit(string phoneNo)
        {
            var count = 0;
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    var users = context.tblUsers.Where(r => r.PrimaryPhoneNo == phoneNo).Select(p => p.UserID).ToList();
                    count = users.Count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return count > 0;
        }

        public List<UserRequest> SearchRequest(SearchParam objParam)
        {
            List<UserRequest> lstRequests = new List<UserRequest>();
            using (var context = new TheThinkerz_WTPSharePointEntities())
            {
                try
                {
                    var result = context.tblUserRequests.Where(r => string.IsNullOrEmpty(objParam.RequestNo) ? (objParam.RequestNo.Equals(string.Empty)) : (r.RequestNo.Equals(objParam.RequestNo))
                        && (r.PrimaryPhoneNo.Equals(objParam.UserId))
                        && (string.IsNullOrEmpty(objParam.RequestStatus) ? (objParam.RequestStatus.Equals(string.Empty)) : (r.Status.Equals(objParam.RequestStatus)))
                        );
                    switch (objParam.CompareOperator)
                    {
                        case "=":
                            result = result.Where(p => (objParam.RequestDate == DateTime.MinValue ?
                                (objParam.RequestDate.Equals(DateTime.MinValue)) :
                                (p.CreateDate.Equals(objParam.RequestDate))));
                            break;
                        case ">":
                            result = result.Where(p => (objParam.RequestDate == DateTime.MinValue ?
                                (objParam.RequestDate.Equals(DateTime.MinValue)) : (p.CreateDate > objParam.RequestDate)));
                            break;
                        case "<":
                            result = result.Where(p => (objParam.RequestDate == DateTime.MinValue ?
                                (objParam.RequestDate.Equals(DateTime.MinValue)) : (p.CreateDate < objParam.RequestDate)));
                            break;
                    }
                    foreach(tblUserRequest objRequest in result)
                    {
                        lstRequests.Add(new UserRequest()
                        {
                            RequestId = objRequest.RequestId,
                            RequestNo = objRequest.RequestNo,
                            CreateDate = objRequest.CreateDate,
                            UpdateDate = objRequest.UpdateDate,
                            Status = objRequest.Status,
                            ProblemLocation = objRequest.ProblemLocation,
                            ShortDescription = objRequest.ShortDescription,
                            LongDescription = objRequest.LongDescription
                        });
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lstRequests;
        }
    }
}
