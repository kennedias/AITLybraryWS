/* Model Object for the Book Available view data
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
    /// Model Object of the Book Available view data.
    /// </summary>
    /// 
    public class ViewBookAvailableModel
    {
        #region fields

        private string _bookAvailableISBN;
        private string _bookAvailableName;
        private string _bookAvailablePublisher;
        private int _bookAvailablePublishYear;
        private int _bookAvailablePages;
        private string _bookAvailableAuthorName;
        private string _bookAvailableCategoryName;
        private string _bookAvailableLanguageName;

        #endregion

        #region Properties

        public string ISBN
        {
            set { _bookAvailableISBN = value; }
            get { return _bookAvailableISBN; }
        }

        public string Name
        {
            set { _bookAvailableName = value; }
            get { return _bookAvailableName; }
        }

        public string Publisher
        {
            set { _bookAvailablePublisher = value; }
            get { return _bookAvailablePublisher; }
        }

        public int PublishYear
        {
            set { _bookAvailablePublishYear = value; }
            get { return _bookAvailablePublishYear; }
        }

        public int Pages
        {
            set { _bookAvailablePages = value; }
            get { return _bookAvailablePages; }
        }

        public string Author
        {
            set { _bookAvailableAuthorName = value; }
            get { return _bookAvailableAuthorName; }
        }

        public String Category
        {
            set { _bookAvailableCategoryName = value; }
            get { return _bookAvailableCategoryName; }
        }

        public string Language
        {
            set { _bookAvailableLanguageName = value; }
            get { return _bookAvailableLanguageName; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.ViewBookAvailableRow row</param>
        /// <returns>ViewBookAvailableModel</returns>
        public static ViewBookAvailableModel Parse(BookDS.ViewBookAvailableRow row)
        {
            if (row == null)
                return null;
            else
            {
                ViewBookAvailableModel viewBookAvailableModel = new ViewBookAvailableModel();
                viewBookAvailableModel._bookAvailableISBN = row.ISBN;
                viewBookAvailableModel._bookAvailableName = row.BookName;
                viewBookAvailableModel._bookAvailablePublisher = row.Publisher;
                viewBookAvailableModel._bookAvailablePublishYear = row.PublishYear;
                viewBookAvailableModel._bookAvailablePages = row.Pages;
                viewBookAvailableModel._bookAvailableAuthorName = row.AuthorName;
                viewBookAvailableModel._bookAvailableCategoryName = row.CategoryName;
                viewBookAvailableModel._bookAvailableLanguageName = row.LanguageName;
                return viewBookAvailableModel;
            }
        }
        #endregion
    }
}
