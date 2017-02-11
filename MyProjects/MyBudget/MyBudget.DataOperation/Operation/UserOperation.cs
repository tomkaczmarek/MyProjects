using MyBudget.Common.Cryptography;
using MyBudget.Common.DataExchange;
using MyBudget.Core.DataAccessObject;
using MyBudget.Core.DataTransferObject;
using MyBudget.Core.NHibernate;
using MyBudget.Core.Operation;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataOperation.Operation
{
    public class UserOperation
    {
        public OperationResult AddNewUser(UserVector user)
        {
            OperationResult result = new OperationResult();
            try
            {
                ISession session;
                bool isUserExist;
                session = NHibernateManager.BeginSessionTransaction();
                User userDto = new User()
                {
                    Login = user.Login,
                    Password = CryptoManager.Encrypt(user.Password),
                    FullName = user.FullName,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                isUserExist = UserDAO.Instance.IsUserExist(user.Login, session);
                if (isUserExist)
                {
                    result.OperationStatus = Status.Warning;
                    result.OperationMessage = OperationMessage.USER_EXIST;
                    User users = UserDAO.Instance.Get(5, session);
                    NHibernateManager.CloseSessionTransaction();
                }
                else
                {
                    UserDAO.Instance.Save(userDto, session);
                    NHibernateManager.CommitTransactionAndClose();
                    result.OperationStatus = Status.Success;
                    result.OperationMessage = OperationMessage.USER_ADD;
                }
            }
            catch (Exception e)
            {
                result.OperationMessage = e.Message;
                result.OperationStatus = Status.Error;
                NHibernateManager.RollBackTransaction();
            }
            return result;
        }
    }
}
