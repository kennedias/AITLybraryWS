 /* Contains all business logic of Book 
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
using SystemFramework;

namespace BusinessLogic
{
    /// <summary>
    /// Business logic related with the Book.
    /// </summary>
    public class BookLogic
    {
        private BookDAO _bookDAO;
        
        private BookDS.ViewBookDataTable _viewBookView;
        private List<ViewBookModel> _listBooksView;

        private BookDS.TabReservedDataTable _tabBookDataTable;

        private BookDS.TabReservedDataTable _tabReservedDataTable;
        private List<TabReservedModel> _listTabReservedModel;

        private BookDS.ViewBookBorrowedDataTable _viewBookBorrowedDataTable;
        private List<ViewBookBorrowedModel> _listViewBooksBorrowedModel;

        private BookDS.ViewBookAvailableDataTable _viewBookAvailableDataTable;
        private List<ViewBookAvailableModel> _listViewBooksAvailableModel;

        private BookDS.ViewBookReservedDataTable _viewBookReservedDataTable;
        private List<ViewBookReservedModel> _listViewBooksReservedModel;

        private BookDS.ViewBookBorrowedWithUserDataTable _viewBookBorrowedWithUserDataTable;
        private List<ViewBookBorrowedWithUserModel> _listViewBooksBorrowedWithUserModel;



        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="ex">BusinessLogicException</exception>
        public BookLogic()
        {
            try
            {
                _bookDAO = new BookDAO();
                _tabBookDataTable = new BookDS.TabReservedDataTable();

                _listBooksView = new List<ViewBookModel>();
                _viewBookView = new BookDS.ViewBookDataTable();

                _listTabReservedModel = new List<TabReservedModel>();
                _tabReservedDataTable = new BookDS.TabReservedDataTable();

                _viewBookAvailableDataTable = new BookDS.ViewBookAvailableDataTable();
                _listViewBooksAvailableModel = new List<ViewBookAvailableModel>();

                _viewBookReservedDataTable = new BookDS.ViewBookReservedDataTable();
                _listViewBooksReservedModel = new List<ViewBookReservedModel>();

                _viewBookBorrowedWithUserDataTable = new BookDS.ViewBookBorrowedWithUserDataTable();
                _listViewBooksBorrowedWithUserModel = new List<ViewBookBorrowedWithUserModel>();
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        #region Book View
        /// <summary>
        ///  Returns all books data from view Book.
        /// </summary>
        /// <returns>List<ViewBookModel></returns>
        public List<ViewBookModel> GetAllBooksView()
        {
            try
            {
                _listBooksView = new List<ViewBookModel>();
                _viewBookView = _bookDAO.GetAllBooksView();

                foreach (BookDS.ViewBookRow row in _viewBookView.Rows)
                {
                    _listBooksView.Add(ViewBookModel.Parse(row));
                }

                return _listBooksView;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Search books using ISBN, book name and author, only book name and only author.
        /// The book name and author are searched with partialy letter, it is not mandotory
        /// to inform the exact name.
        /// </summary>
        /// <param name="bookISBN">string bookISBN</param>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">string author</param>
        /// <returns>List<ViewBookModel></returns>
        public List<ViewBookModel> BookSearch(string bookISBN, string bookName, string author)
        {
            try
            {
                _listBooksView = new List<ViewBookModel>();

                if (bookISBN != "")
                {
                    _viewBookView = _bookDAO.GetAllBooksViewByISBN(bookISBN);
                }
                else if (bookName != "" || author != "")
                {
                    _viewBookView = _bookDAO.GetAllBooksViewByBookNameAndAuthor(bookName, author);
                }

                foreach (BookDS.ViewBookRow row in _viewBookView.Rows)
                {
                    _listBooksView.Add(ViewBookModel.Parse(row));
                }

                return _listBooksView;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }
        #endregion

        #region Reserved

        /// <summary>
        /// Insert a book reservation into Reserved table.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="isbn">string isbn</param>
        /// <param name="reservedDate">string reservedDate</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        public int insertBookReserved(int userId, string isbn, string reservedDate)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountBookReservedByIsbn(isbn);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Book already reserved.");
                }

                resultQuery = _bookDAO.InsertBookReserved(userId, isbn, reservedDate);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Reserve not inserted.");
                }

                return resultQuery;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }

        }

        /// <summary>
        /// Select Count(*) from Reserved by ISBN.
        /// </summary>
        /// <param name="reserveId">string isbn</param>
        /// <returns>int numbers of registers found</returns>
        public int SelectCountBookReservedByIsbn(string isbn)
        {
            try
            {
                _bookDAO = new BookDAO();
                return _bookDAO.SelectCountBookReservedByIsbn(isbn);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Delete book Reserve.
        /// </summary>
        /// <param name="reserveId">string isbn</param>
        /// <returns>int rowsAffected</returns>
        public int DeleteBookReserved(int reservedId)
        {
            try
            {
                _bookDAO = new BookDAO();
                return _bookDAO.DeleteBookReserved(reservedId);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }


        /// <summary>
        /// Return all registers from Reserved table by UserID.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>List<TabReservedModel></returns>
        public List<TabReservedModel> GetAllReservedBooksByUserId(int userId)
        {
            try
            {
                _listTabReservedModel = new List<TabReservedModel>();
                _tabReservedDataTable = _bookDAO.GetAllReservedBooksByUserId(userId);

                foreach (BookDS.TabReservedDataTable row in _tabReservedDataTable.Rows)
                {
                    _listTabReservedModel.Add(TabReservedModel.Parse(row));
                }

                return _listTabReservedModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        #endregion

        #region Book Available

        /// <summary>
        /// Return all registers from Book Available.
        /// </summary>
        /// <returns>List<T</returns>
        public List<ViewBookAvailableModel> GetAllAvailableBooks()
        {
            try
            {
                _listViewBooksAvailableModel = new List<ViewBookAvailableModel>();
                _viewBookAvailableDataTable = _bookDAO.GetAllBooksAvailableView();

                foreach (BookDS.ViewBookAvailableRow row in _viewBookAvailableDataTable.Rows)
                {
                    _listViewBooksAvailableModel.Add(ViewBookAvailableModel.Parse(row));
                }

                return _listViewBooksAvailableModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Search availabe books using ISBN, book name and author, only book name and only author.
        /// The book name and author are searched with partialy letter, it is not mandotory
        /// to inform the exact name.
        /// </summary>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">string author</param>
        /// <returns>List<ViewBookAvailableModel></returns>
        public List<ViewBookAvailableModel> GetAllBooksAvailableByBookNameAndAuthor(string bookName, string author)
        {
            try
            {
                _listViewBooksAvailableModel = new List<ViewBookAvailableModel>();

                if (bookName != "" || author != "")
                {
                    _viewBookAvailableDataTable = _bookDAO.GetAllBooksAvailableByBookNameAndAuthorView(bookName, author);
                    foreach (BookDS.ViewBookAvailableRow row in _viewBookAvailableDataTable.Rows)
                    {
                        _listViewBooksAvailableModel.Add(ViewBookAvailableModel.Parse(row));
                    }
                }
                return _listViewBooksAvailableModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        #endregion

        #region BookBorrowed

        /// <summary>
        /// Return all registers from Book Borrowed View.
        /// </summary>
        /// <returns>List<ViewBookBorrowedModel></returns>
        public List<ViewBookBorrowedModel> GetAllBorrowedBooks()
        {
            try
            {
                _listViewBooksBorrowedModel = new List<ViewBookBorrowedModel>();
                _viewBookBorrowedDataTable = _bookDAO.GetAllBooksBorrowedView();

                foreach (BookDS.ViewBookBorrowedRow row in _viewBookBorrowedDataTable.Rows)
                {
                    _listViewBooksBorrowedModel.Add(ViewBookBorrowedModel.Parse(row));
                }

                return _listViewBooksBorrowedModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Return all registers from Book Borrowed View.
        /// </summary>
        /// <returns>List<ViewBookBorrowedWithUserModel></returns>
        public List<ViewBookBorrowedWithUserModel> GetAllBorrowedBooksWithUser()
        {
            try
            {
                _listViewBooksBorrowedWithUserModel = new List<ViewBookBorrowedWithUserModel>();
                _viewBookBorrowedWithUserDataTable = _bookDAO.GetAllBooksBorrowedWithUserView();

                foreach (BookDS.ViewBookBorrowedWithUserRow row in _viewBookBorrowedWithUserDataTable.Rows)
                {
                    _listViewBooksBorrowedWithUserModel.Add(ViewBookBorrowedWithUserModel.Parse(row));
                }

                return _listViewBooksBorrowedWithUserModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Returns all registers from Borrowed Book view  by Book Name.
        /// </summary>
        /// <param name="bookName">string bookName</param>
        /// <returns>List<ViewBookBorrowedWithUserModel></returns>
        public List<ViewBookBorrowedWithUserModel> GetBooksBorrowedViewByName(string bookName)
        {
            try
            {
                _listViewBooksBorrowedWithUserModel = new List<ViewBookBorrowedWithUserModel>();
                _viewBookBorrowedWithUserDataTable = _bookDAO.GetBooksBorrowedViewByName(bookName);

                foreach (BookDS.ViewBookBorrowedWithUserRow row in _viewBookBorrowedWithUserDataTable.Rows)
                {
                    _listViewBooksBorrowedWithUserModel.Add(ViewBookBorrowedWithUserModel.Parse(row));
                }

                return _listViewBooksBorrowedWithUserModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }

        }

        /// <summary>
        /// Insert a book borrow into Borrow Book.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="isbn">string isbn</param>
        /// <returns>int rowsAffected</returns>
        public int InsertBorrowBook(int userId, string isbn)
        {
            try
            {
                /* Borrow book business logic that is done here.
                 * It centralize the logic here and can not be in UI layers such as Forms and Webpages.
                 * 
                 * borrow date = today
                 * return date = today + constant that represents the amount of days that the book can be borrowed
                 * actual return date = constant that represents a actual date return to be used in the insert, once the field is mandatory in DB.
                 * late fee = constant that represents a late fee to be used in the insert, once the field is mandatory in DB.
                 * */
                string borrowDate = DateTime.Today.ToString();
                string returnDate = DateTime.Today.AddDays(Constants.daysOfBorrowingBook).ToString();
                string actualReturnDate = Constants.actualDateReturnForInsert;
                decimal lateFee = Constants.lateFeeToInsert;

                int resultQuery = _bookDAO.InsertBorrowBook(userId, isbn, borrowDate, returnDate, actualReturnDate, lateFee);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Borrow not completed. Contact the Administrator.");
                }
                return resultQuery;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Return all registers from Book Borrowed by UserId.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>List<ViewBookBorrowedModel></returns>
        public List<ViewBookBorrowedModel> GetAllBorrowedBooksByUserId(int userId)
        {
            try
            {
                _listViewBooksBorrowedModel = new List<ViewBookBorrowedModel>();
                _viewBookBorrowedDataTable = _bookDAO.GetAllBooksBorrowedView();

                foreach (BookDS.ViewBookBorrowedRow row in _viewBookBorrowedDataTable.Rows)
                {
                    _listViewBooksBorrowedModel.Add(ViewBookBorrowedModel.Parse(row));
                }

                return _listViewBooksBorrowedModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        /// Return a book borrowed book.
        /// </summary>
        /// <param name="bid">int bid</param>
        /// <param name="returnDate">string returnDate</param>
        /// <returns>int rowsAffected</returns>
        public int ReturnBorrowBook(int bid, string returnDate)
        {
            try
            {
                /* Return borrow book business logic that is done here.
                 * It centralize the logic here and can not be in UI layers such as Forms and Webpages.
                 * 
                 * return date = Maximun date when the book have to be returned.
                 * actual return date = today
                 * late fee = if the actual return date is after return date, the late fee have to be applied diary. The total of
                 *            late days have to be multiplied for the constant that represents the late fee per day late.
                 * */
                DateTime actualReturnDate = DateTime.Today;
                DateTime correctReturnDate = DateTime.Parse(returnDate);
                decimal lateFee = 0;
                TimeSpan daysOfReturnLate = actualReturnDate - correctReturnDate;

                /* Get the days of difference between the correct date that have to be returned and the actual return date.
                 * If the correct day of return is after the actual, the difference of days is negative.
                 * If the correct day of return is before the actual, the difference is positive and then the days of
                 * difference is used to apply the daily fee.
                 **/
                if (daysOfReturnLate.Days > 0)
                {
                    lateFee = Constants.lateFeePerDay * daysOfReturnLate.Days;
                }
                                
                int resultQuery = _bookDAO.UpdateBookBorrowed(bid, actualReturnDate.ToString(), lateFee);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Return book was not completed. Contact the Administrator.");
                }
                return resultQuery;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }



        }


        #endregion

        #region BookViewReserved
        /// <summary>
        ///  Returns all books data from view BookViewReserved.
        /// </summary>
        /// <returns>List<ViewBookReservedModel></returns>
        public List<ViewBookReservedModel> GetAllBooksReservedView()
        {
            try
            {
                _listViewBooksReservedModel = new List<ViewBookReservedModel>();
                _viewBookReservedDataTable = _bookDAO.GetAllBooksReservedView();

                foreach (BookDS.ViewBookReservedRow row in _viewBookReservedDataTable.Rows)
                {
                    _listViewBooksReservedModel.Add(ViewBookReservedModel.Parse(row));
                }

                return _listViewBooksReservedModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        ///  Returns all books data from view BookViewReserved By UserId.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>List<ViewBookReservedModel></returns>
        public List<ViewBookReservedModel> GetAllBooksReservedViewByUserId(int userId)
        {
            try
            {
                _listViewBooksReservedModel = new List<ViewBookReservedModel>();
                _viewBookReservedDataTable = _bookDAO.GetAllBooksReservedViewByUserId(userId);

                foreach (BookDS.ViewBookReservedRow row in _viewBookReservedDataTable.Rows)
                {
                    _listViewBooksReservedModel.Add(ViewBookReservedModel.Parse(row));
                }

                return _listViewBooksReservedModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        #endregion

        #region BookViewBorrowedWithUser
        /// <summary>
        ///  Returns all books data from view ViewBookBorrowedWithUser.
        /// </summary>
        /// <returns>List<ViewBookBorrowedWithUserModel></returns>
        public List<ViewBookBorrowedWithUserModel> GetAllBooksBorrowedWithUserView()
        {
            try
            {
                _listViewBooksBorrowedWithUserModel = new List<ViewBookBorrowedWithUserModel>();
                _viewBookBorrowedWithUserDataTable = _bookDAO.GetAllBooksBorrowedWithUserView();

                foreach (BookDS.ViewBookBorrowedWithUserRow row in _viewBookBorrowedWithUserDataTable.Rows)
                {
                    _listViewBooksBorrowedWithUserModel.Add(ViewBookBorrowedWithUserModel.Parse(row));
                }

                return _listViewBooksBorrowedWithUserModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        /// <summary>
        ///  Returns all books data from view ViewBookBorrowedWithUser By UserId.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>List<ViewBookBorrowedWithUserModel></returns>
        public List<ViewBookBorrowedWithUserModel> GetAllBooksBorrowedWithUserViewByUserId(int userId)
        {
            try
            {
                _listViewBooksBorrowedWithUserModel = new List<ViewBookBorrowedWithUserModel>();
                _viewBookBorrowedWithUserDataTable = _bookDAO.GetAllBooksBorrowedWithUserViewByUserId(userId);

                foreach (BookDS.ViewBookBorrowedWithUserRow row in _viewBookBorrowedWithUserDataTable.Rows)
                {
                    _listViewBooksBorrowedWithUserModel.Add(ViewBookBorrowedWithUserModel.Parse(row));
                }

                return _listViewBooksBorrowedWithUserModel;
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
        }

        #endregion


        #region Book

        /// <summary>
        /// Delete a book.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinnessException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteBook(string isbn)
        {
            try
            {
                _bookDAO = new BookDAO();
                return _bookDAO.DeleteBook(isbn);
            }
            catch (DataAccessLayerException ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
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
        /// Insert a book.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">int author</param>
        /// <param name="category">int category</param>
        /// <param name="language">int language</param>
        /// <param name="publishYear">int publishYear</param>
        /// <param name="pages">int pages</param>
        /// <param name="publisher">string publisher</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertBook(string isbn, string bookName, int author, int category, int language, int publishYear, int pages, string publisher)
        {
            try
            {
                _bookDAO = new BookDAO();
                return _bookDAO.InsertBook(isbn, bookName, author, category, language, publishYear, pages, publisher);
            }
            catch (DataAccessLayerException ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
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
        /// Update register from TabBook.
        /// <summary>
        /// <param name="updatedIsbn">string updatedIsbn</param>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">int author</param>
        /// <param name="category">int category</param>
        /// <param name="language">int language</param>
        /// <param name="publishYear">int publishYear</param>
        /// <param name="pages">int pages</param>
        /// <param name="publisher">string publisher</param>
        /// <param name="isbn">string isbn</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateBook(string updatedIsbn, string bookName, int author, int category, int language, int publishYear,
                              int pages, string publisher, string isbn)
        {
            try
            {
                _bookDAO = new BookDAO();
                return _bookDAO.UpdateBook(updatedIsbn, bookName, author, category, language, publishYear, pages, publisher, isbn);
            }
            catch (DataAccessLayerException ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw new BusinessLogicException(ex.Message);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        #endregion
    }
}
