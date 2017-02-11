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
using MyBudget.Common.PageHandler;
using MyBudget.Core.DataHelpers;


namespace MyBudget.DataOperation.Operation
{
    public static class OperationUser
    {
        /// <summary>
        /// Add new user to application.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static OperationResult AddNewUser(UserVector user)
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

        public static OperationResult LogUser(UserVector userVector)
        {
            OperationResult result = new OperationResult();
            try
            {
                ISession session;
                bool passwordMatch = false;
                session = NHibernateManager.BeginSessionTransaction();
                User user = UserDAO.Instance.GetUserByLogin(userVector.Login, session);

                if (user != null)
                    passwordMatch = CryptoManager.IsMatch(CryptoManager.Encrypt(userVector.Password), user.Password);

                if(passwordMatch == true)
                {
                    UserHelper.Instance.GetUser = user;
                    result.OperationStatus = Status.Success;
                    result.UrlRedirect = WebSitePageHandler.MainOperationPage;
                }
                else
                {
                    result.OperationStatus = Status.Error;
                    result.OperationMessage = OperationMessage.LOGIN_ERROR;
                }
                NHibernateManager.CloseSessionTransaction();
            }
            catch(Exception e)
            {
                result.OperationMessage = e.Message;
                result.OperationStatus = Status.Error;
                NHibernateManager.RollBackTransaction();
            }
            return result;
        }
    }
}
