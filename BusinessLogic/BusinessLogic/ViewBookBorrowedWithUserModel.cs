/* Model Object for the BookBorrowedWithUser view data
 * 
 * Project: Assignment 2 - AIT
 * Developer: Kennedy Oliveira - ID 5399
 * Data of release: 19/09/2016
 * Version: 1.0 - Release
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLogic
{
    /// <summary>
    /// Model Object of the BookBorrowedWithUser view data.
    /// </summary>
    /// 
    public class ViewBookBorrowedWithUserModel
    {
        #region fields

        private string _bookBorrowedISBN;
        private string _bookBorrowedName;
        private string _bookBorrowedAuthorName;
        private string _bookBorrowedUserName;
        private DateTime _bookBorrowedBorrowDate;
        private DateTime _bookBorrowedReturnDate;
        private decimal _bookBorrowedLateFee;
        private int     _bookBorrowedUserId;
        private int     _bookBorrowedBorrowId;
 
        #endregion

        #region Properties

        public string ISBN
        {
            set { _bookBorrowedISBN = value; }
            get { return _bookBorrowedISBN; }
        }

        public string Name
        {
            set { _bookBorrowedName = value; }
            get { return _bookBorrowedName; }
        }

        public string Author
        {
            set { _bookBorrowedAuthorName = value; }
            get { return _bookBorrowedAuthorName; }
        }

        public string User
        {
            set { _bookBorrowedUserName = value; }
            get { return _bookBorrowedUserName; }
        }

        public DateTime Borrow
        {
            set { _bookBorrowedBorrowDate = value; }
            get { return _bookBorrowedBorrowDate; }
        }

        public DateTime Return
        {
            set { _bookBorrowedReturnDate = value; }
            get { return _bookBorrowedReturnDate; }
        }

        public decimal LateFee
        {
            set { _bookBorrowedLateFee = value; }
            get { return _bookBorrowedLateFee; }
        }

        public int UserId
        {
            set { _bookBorrowedUserId = value; }
            get { return _bookBorrowedUserId; }
        }

        public int BorrowId
        {
            set { _bookBorrowedBorrowId = value; }
            get { return _bookBorrowedBorrowId; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.ViewBookBorrowedWithUserRow row</param>
        /// <returns>ViewBookBorrowedWithUserModel</returns>
        public static ViewBookBorrowedWithUserModel Parse(BookDS.ViewBookBorrowedWithUserRow row)
        {
            if (row == null)
                return null;
            else
            {
                ViewBookBorrowedWithUserModel viewBookBorrowedWithUserModel = new ViewBookBorrowedWithUserModel();
                viewBookBorrowedWithUserModel._bookBorrowedISBN = row.ISBN;
                viewBookBorrowedWithUserModel._bookBorrowedName = row.BookName;
                viewBookBorrowedWithUserModel._bookBorrowedAuthorName = row.AuthorName;
                viewBookBorrowedWithUserModel._bookBorrowedUserName = row.UserName;
                viewBookBorrowedWithUserModel._bookBorrowedBorrowDate = row.BorrowDate;
                viewBookBorrowedWithUserModel._bookBorrowedReturnDate = row.ReturnDate;
                viewBookBorrowedWithUserModel._bookBorrowedLateFee = row.LateFee;
                viewBookBorrowedWithUserModel._bookBorrowedUserId = row.UID;
                viewBookBorrowedWithUserModel._bookBorrowedBorrowId = row.BID;
                return viewBookBorrowedWithUserModel;
            }
        }
        #endregion
    }
}
