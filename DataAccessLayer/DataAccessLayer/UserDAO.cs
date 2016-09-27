/* Data Access Object for the User data
 * 
 * Project: Assignment 1 - AIT
 * Developer: Kennedy Oliveira - ID 5399
 * Data of release: 19/08/2016
 * Version: 1.0 - Release
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.UserDSTableAdapters;
using System.Data.SqlClient;
using SystemFramework;

namespace DataAccessLayer
{

    /// <summary>
    /// Classe designed for access the User data.
    /// </summary>
    /// <remarks>
    /// All access of data from User should be implemented here.</remarks>
    /// 
    public class UserDAO
    {
        private UserDS _userDataSet;
        private TabUserTableAdapter _tabUserTableAdapter;

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserDAO()
        {
            //Initialize objects
            _userDataSet = new UserDS();
            _tabUserTableAdapter = new TabUserTableAdapter();
        }

        /// <summary>
        /// Returns all registers from User table.
        /// </summary>
        /// <returns>UserDS.TabUserDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public UserDS.TabUserDataTable GetAllUser()
        {
            try
            {
                _userDataSet = new UserDS();
                _tabUserTableAdapter.FillAllUsers(_userDataSet.TabUser);
                return _userDataSet.TabUser;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Return register from User table based on login details.
        /// </summary>
        /// <param name="userName">string userName</param>
        /// <param name="password">string password</param>
        /// <returns>UserDS.TabUserDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public UserDS.TabUserDataTable GetLogin(string userName, string password)
        {
            try
            {
                _userDataSet = new UserDS();
                _tabUserTableAdapter.FillByUserNamePassword(_userDataSet.TabUser, userName, password);
                return _userDataSet.TabUser;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Delete a user from User table.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">DataAccessLayerException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteUser(int userId)
        {
            try
            {
                return _tabUserTableAdapter.DeleteUser(userId);
            }
            catch (SqlException ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                if (ex.Number == 547)
                {
                    throw new DataAccessLayerException(Constants.msgExceptionRegisterInUse);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Insert a user from User table.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <param name="userLevel">int userLevel</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertUser(string userName, string userPassword, int userLevel)
        {
            try
            {
                return _tabUserTableAdapter.InsertUser(userName, userPassword, userLevel);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Update a user from User table.
        /// </summary>
        /// <param name="userName">string userName</param>
        /// <param name="password">string password</param>
        /// <param name="userLevel">int userLevel</param>
        /// <param name="userId">int userId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateUser(string userName, string userPassword, int userLevel, int userId)
        {
            try
            {
                return _tabUserTableAdapter.UpdateUser(userName, userPassword, userLevel, userId);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Update a user from User table without field password.
        /// </summary>
        /// <param name="userName">string userName</param>
        /// <param name="userLevel">int userLevel</param>
        /// <param name="userId">int userId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateUserWithoutPassword(string userName, int userLevel, int userId)
        {
            try
            {
                return _tabUserTableAdapter.UpdateUserWithoutPassword(userName, userLevel, userId);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Select count in User table by userName.
        /// The count search for user name despite the name of the actual userID.
        /// </summary>
        /// <param name="userName">string userName</param>
        /// <param name="userID">int userID</param>
        /// <returns>int countResult</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountUserByName(string userName, int userID)
        {
            try
            {
                return (int)_tabUserTableAdapter.SelectCountUserByName(userName, userID);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        /// <summary>
        /// Search Users by UserName.
        /// </summary>
        /// <param name="userName">string userName</param>
        /// <returns>UserDS.TabUserDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public UserDS.TabUserDataTable GetUsersByUserName(string userName)
        {
            try
            {
                userName = "%" + userName + "%";
                _userDataSet = new UserDS();
                _tabUserTableAdapter.FillByUserName(_userDataSet.TabUser, userName);
                return _userDataSet.TabUser;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }
    }
}
