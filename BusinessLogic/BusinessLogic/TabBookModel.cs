using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLogic
{
    public class TabBookModel
    {
        # region fields

        private string _ISBN;
        private string _bookName;
        private int _bookAuthorID;
        private int _bookCategory;
        private int _bookLanguage;
        private int _bookPublishYear;
        private int _bookPages;
        private string _bookPublisher;

        #endregion

        # region properties

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }

        public int BookAuthorID
        {
            get { return _bookAuthorID; }
            set { _bookAuthorID = value; }
        }

        public int BookCategory
        {
            get { return _bookCategory; }
            set { _bookCategory = value; }
        }

        public int BookLanguage
        {
            get { return _bookLanguage; }
            set { _bookLanguage = value; }
        }

        public int BookPublishYear
        {
            get { return _bookPublishYear; }
            set { _bookPublishYear = value; }
        }

        public int BookPages
        {
            get { return _bookPages; }
            set { _bookPages = value; }
        }

        public string BookPublisher
        {
            get { return _bookPublisher; }
            set { _bookPublisher = value; }
        }

        #endregion

        #region methods

        public static TabBookModel Parse(BookDS.TabBookRow row)
        {
            if (row == null)
                return null;

            else
            {
                //Model Data = Database data
                TabBookModel model = new TabBookModel();
                model._ISBN = row.ISBN;
                model._bookName = row.BookName;
                model._bookCategory = row.Category;
                model._bookLanguage = row.Language;
                model._bookPages = row.Pages;
                model._bookAuthorID = row.Author;
                model._bookPublishYear = row.PublishYear;
                model._bookPublisher = row.Publisher;

                return model;
            }
        }

        #endregion
    }
}
