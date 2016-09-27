/* Model Object for the ViewBookReservedModel view data
 * Used for interact with user level
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
    /// Model Object of the ViewBookReservedModel view data in user level
    /// </summary>
    /// 
    public class ViewBookReservedForUserModel
    {
        #region fields

        private string _bookBorrowedISBN;
        private string _bookBorrowedName;
        private string _bookBorrowedAuthorName;
        private DateTime _bookBorrowedReserveDate;
        private int      _bookBorrowedReserveId;
 
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

        public DateTime ReserveDate
        {
            set { _bookBorrowedReserveDate = value; }
            get { return _bookBorrowedReserveDate; }
        }

        public int ReserveId
        {
            set { _bookBorrowedReserveId = value; }
            get { return _bookBorrowedReserveId; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.ViewBookReservedModel row</param>
        /// <returns>ViewBookReservedForUserModel</returns>
        public static ViewBookReservedForUserModel Parse(BookDS.ViewBookReservedRow row)
        {
            if (row == null)
                return null;
            else
            {
                ViewBookReservedForUserModel viewBookReservedForUserModel = new ViewBookReservedForUserModel();
                viewBookReservedForUserModel._bookBorrowedISBN = row.ISBN;
                viewBookReservedForUserModel._bookBorrowedName = row.BookName;
                viewBookReservedForUserModel._bookBorrowedAuthorName = row.AuthorName;
                viewBookReservedForUserModel._bookBorrowedReserveDate = row.ReservedDate;
                viewBookReservedForUserModel._bookBorrowedReserveId = row.RID;
                return viewBookReservedForUserModel;
            }
        }
        #endregion
    }
}
