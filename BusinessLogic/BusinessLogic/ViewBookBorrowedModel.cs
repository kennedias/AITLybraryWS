/* Model Object for the BookBorrowed view data
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
    /// Model Object of the BookBorrowed view data.
    /// </summary>
    /// 
    public class ViewBookBorrowedModel
    {
        #region fields

        private string _bookBorrowedISBN;
        private string _bookBorrowedName;
        private string _bookBorrowedPublisher;
        private int _bookBorrowedPublishYear;
        private int _bookBorrowedPages;
        private string _bookBorrowedAuthorName;
        private string _bookBorrowedCategoryName;
        private string _bookBorrowedLanguageName;

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

        public string Publisher
        {
            set { _bookBorrowedPublisher = value; }
            get { return _bookBorrowedPublisher; }
        }

        public int PublishYear
        {
            set { _bookBorrowedPublishYear = value; }
            get { return _bookBorrowedPublishYear; }
        }

        public int Pages
        {
            set { _bookBorrowedPages = value; }
            get { return _bookBorrowedPages; }
        }

        public string Author
        {
            set { _bookBorrowedAuthorName = value; }
            get { return _bookBorrowedAuthorName; }
        }

        public String Category
        {
            set { _bookBorrowedCategoryName = value; }
            get { return _bookBorrowedCategoryName; }
        }

        public string Language
        {
            set { _bookBorrowedLanguageName = value; }
            get { return _bookBorrowedLanguageName; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.ViewBookBorrowedRow row</param>
        /// <returns>ViewBookBorrowedModel</returns>
        public static ViewBookBorrowedModel Parse(BookDS.ViewBookBorrowedRow row)
        {
            if (row == null)
                return null;
            else
            {
                ViewBookBorrowedModel viewBookBorrowedModel = new ViewBookBorrowedModel();
                viewBookBorrowedModel._bookBorrowedISBN = row.ISBN;
                viewBookBorrowedModel._bookBorrowedName = row.BookName;
                viewBookBorrowedModel._bookBorrowedPublisher = row.Publisher;
                viewBookBorrowedModel._bookBorrowedPublishYear = row.PublishYear;
                viewBookBorrowedModel._bookBorrowedPages = row.Pages;
                viewBookBorrowedModel._bookBorrowedAuthorName = row.AuthorName;
                viewBookBorrowedModel._bookBorrowedCategoryName = row.CategoryName;
                viewBookBorrowedModel._bookBorrowedLanguageName = row.LanguageName;
                return viewBookBorrowedModel;
            }
        }
        #endregion
    }
}
