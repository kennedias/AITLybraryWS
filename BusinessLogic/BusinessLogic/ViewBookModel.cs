/* Model Object for the Book view data
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
using DataAccessLayer;

namespace BusinessLogic
{
    /// <summary>
    /// Model Object of the Book view data.
    /// </summary>
    /// 
    public class ViewBookModel
    {
        #region fields

        private string _bookISBN;
        private string _bookName;
        private string _bookPublisher;
        private int    _bookPublishYear;
        private int    _bookPages;
        private string _bookAuthorName;
        private string _bookCategoryName;
        private string _bookLanguageName; 

        #endregion

        #region Properties

        public string ISBN
        {
            set { _bookISBN = value; }
            get { return _bookISBN; }
        }

        public string Name
        {
            set { _bookName = value; }
            get { return _bookName; }
        }

        public string Publisher
        {
            set { _bookPublisher = value; }
            get { return _bookPublisher; }
        }

        public int PublishYear
        {
            set { _bookPublishYear = value; }
            get { return _bookPublishYear; }
        }

        public int Pages
        {
            set { _bookPages = value; }
            get { return _bookPages; }
        }

        public string Author
        {
            set { _bookAuthorName = value; }
            get { return _bookAuthorName; }
        }

        public String Category
        {
            set { _bookCategoryName = value; }
            get { return _bookCategoryName; }
        }

        public string Language
        {
            set { _bookLanguageName = value; }
            get { return _bookLanguageName; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.ViewBookRow row</param>
        /// <returns>ViewBookModel</returns>
        public static ViewBookModel Parse(BookDS.ViewBookRow row)
        {
            if (row == null)
                return null;
            else
            {
                ViewBookModel viewBookModel = new ViewBookModel();
                viewBookModel._bookISBN = row.ISBN;
                viewBookModel._bookName = row.BookName;
                viewBookModel._bookPublisher = row.Publisher;
                viewBookModel._bookPublishYear = row.PublishYear;
                viewBookModel._bookPages = row.Pages;
                viewBookModel._bookAuthorName = row.AuthorName;
                viewBookModel._bookCategoryName = row.CategoryName;
                viewBookModel._bookLanguageName = row.LanguageName;
                return viewBookModel;
            }
        }
        #endregion
    }
}
