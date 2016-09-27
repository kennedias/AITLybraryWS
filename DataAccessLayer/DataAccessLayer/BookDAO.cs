/* Data Access Object for the Book data
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
using DataAccessLayer.BookDSTableAdapters;
using System.Data.SqlClient;
using SystemFramework;


namespace DataAccessLayer
{
    /// <summary>
    /// Classe designed for access the Book data.
    /// </summary>
    /// <remarks>
    /// All access of data from Book, tabble and view, should be implemented here.</remarks>
    /// 
    public class BookDAO
    {

        private BookDS _bookDataSet;
        private TabBookTableAdapter _tabBookTableAdapter;        
        private TabReservedTableAdapter _tabReservedTableAdapter;
        private TabBorrowTableAdapter _tabBorrowTableAdapter;
        private ViewBookTableAdapter _viewBookTableAdapter;
        private ViewBookAvailableTableAdapter _viewBookAvailableTableAdapter;
        private ViewBookBorrowedTableAdapter _viewBookBorrowedTableAdapter;
        private ViewBookBorrowedWithUserTableAdapter _viewBookBorrowedWithUserTableAdapter;
        private ViewBookReservedTableAdapter _viewBookReservedTableAdapter;

        /// <summary>
        /// Class constructor
        /// </summary>
        public BookDAO()
        {
            //Initialize objects
            _bookDataSet = new BookDS();
            _tabBookTableAdapter = new TabBookTableAdapter();
            _tabReservedTableAdapter = new TabReservedTableAdapter();
            _tabBorrowTableAdapter = new TabBorrowTableAdapter();
            _viewBookTableAdapter = new ViewBookTableAdapter();
            _viewBookAvailableTableAdapter = new ViewBookAvailableTableAdapter();
            _viewBookBorrowedTableAdapter = new ViewBookBorrowedTableAdapter();
            _viewBookBorrowedWithUserTableAdapter = new ViewBookBorrowedWithUserTableAdapter();
            _viewBookReservedTableAdapter = new ViewBookReservedTableAdapter();
        }

        #region BookView

        /// <summary>
        /// Returns all registers from Book view.
        /// </summary>
        /// <returns>BookDS.ViewBookDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookDataTable GetAllBooksView()
        {
            try
            {
                _viewBookTableAdapter.FillAllBooks(_bookDataSet.ViewBook);
                return _bookDataSet.ViewBook;
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
        /// Return registers from Book view filtred by bookName and Author, only bookName or only bookAuthor.
        /// </summary>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">string author</param>
        /// <returns>BookDS.ViewBookDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookDataTable GetAllBooksViewByBookNameAndAuthor(string bookName, string author)
        {
            try
            {
                bookName = "%" + bookName + "%";
                author = "%" + author + "%";
                _viewBookTableAdapter.FillByBookNameAndAuthorName(_bookDataSet.ViewBook, bookName, author);
                return _bookDataSet.ViewBook;
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
        /// Return registers from Book view filtred by ISBN.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <returns>BookDS.ViewBookDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookDataTable GetAllBooksViewByISBN(string isbn)
        {
            try
            {
                _viewBookTableAdapter.FillByISBN(_bookDataSet.ViewBook, isbn);
                return _bookDataSet.ViewBook;
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

        #region ReservedBook

        /// <summary>
        /// Return all registers from Reserved table.
        /// </summary>
        /// <returns>BookDS.TabReservedDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.TabReservedDataTable GetAllReservedBooks()
        {
            try
            {
                _tabReservedTableAdapter.FillAllReservedBooks(_bookDataSet.TabReserved);
                return _bookDataSet.TabReserved;
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
        /// Delete a reserved book from Reserved table.
        /// </summary>
        /// <param name="reservedId">int reservedId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int DeleteBookReserved(int reservedId)
        {
            try
            {
                return _tabReservedTableAdapter.DeleteBookReserved(reservedId);
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
        /// Return all registers from Reserved table by UserID.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>BookDS.TabReservedDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.TabReservedDataTable GetAllReservedBooksByUserId(int userId)
        {
            try
            {
                _bookDataSet = new BookDS();
                _tabReservedTableAdapter.FillAllReservedBooksByUserID(_bookDataSet.TabReserved, userId);
                return _bookDataSet.TabReserved;
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
        /// Insert a book reserve into Reserved table.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="isbn">string isbn</param>
        /// <param name="reservedDate">string reservedDate</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertBookReserved(int userId, string isbn, string reservedDate)
        {
            try
            {
                return _tabReservedTableAdapter.InsertBookReserve(userId, isbn, reservedDate);
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
        /// Select Count(*) from Reserved by ISBN.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <returns>int numbers of registers found</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountBookReservedByIsbn(string isbn)
        {
            try
            {
                return (int)_tabReservedTableAdapter.SelectCountReservedBookByISBN(isbn);
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

        #region BorrowedBook

        /// <summary>
        /// Return all registers from Borrow.
        /// </summary>
        /// <returns>BookDS.TabBorrowDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.TabBorrowDataTable GetAllBorrowedBooks()
        {
            try
            {
                _tabBorrowTableAdapter.FillAllBooksBorrowed(_bookDataSet.TabBorrow);
                return _bookDataSet.TabBorrow;
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
        /// Return all registers from Borrow by UserID.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>BookDS.TabBorrowDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.TabBorrowDataTable GetAllBorrowedBooksByUserId(int userId)
        {
            try
            {
                _tabBorrowTableAdapter.FillAllBorrowedBooksByUserID(_bookDataSet.TabBorrow, userId);
                return _bookDataSet.TabBorrow;
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
        /// Insert a book borrow into Borrow table.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="isbn">string isbn</param>
        /// <param name="borrowDate">string borrowDate</param>
        /// <param name="returnDate">string returnDate</param>
        /// <param name="actualReturnDate">string actualReturnDate</param>
        /// <param name="lateFee">decimal lateFee</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertBorrowBook(int userId, string isbn, string borrowDate, string returnDate, string actualReturnDate, decimal lateFee)
        {
            try
            {
                return _tabBorrowTableAdapter.InsertBookBorrowed(userId, isbn, borrowDate, returnDate, actualReturnDate, lateFee);
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
        /// Update a book borrow into Borrow table.
        /// </summary>
        /// <param name="bid">int bid</param>
        /// <param name="actualReturnDate">string actualReturnDate</param>
        /// <param name="lateFee">decimal lateFee</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateBookBorrowed(int bid, string actualReturnDate, decimal lateFee)
        {
            try
            {
                return _tabBorrowTableAdapter.UpdateBookBorrowed(actualReturnDate, lateFee, bid);  
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

        #region AvailableBookView

        /// <summary>
        /// Returns all registers from Available Book view.
        /// </summary>
        /// <returns>BookDS.ViewBookAvailableDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookAvailableDataTable  GetAllBooksAvailableView()
        {
            try
            {
                _viewBookAvailableTableAdapter.FillAllBooksAvailable(_bookDataSet.ViewBookAvailable);
                return _bookDataSet.ViewBookAvailable;
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
        /// Returns all registers from Available Book view by Book Name And Author.
        /// </summary>
        /// <param name="bookname">string bookName</param>
        /// <param name="authorname">string author</param>
        /// <returns>BookDS.ViewBookAvailableDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookAvailableDataTable GetAllBooksAvailableByBookNameAndAuthorView(string bookName, string author)
        {
            try
            {
                bookName = "%" + bookName + "%";
                author = "%" + author + "%";
                _viewBookAvailableTableAdapter.FillAllAvailableBooksByNameAndAuthor(_bookDataSet.ViewBookAvailable, bookName, author);
                return _bookDataSet.ViewBookAvailable;
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
        /// Select Count(*) from Book Available View by ISBN.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <returns>int numbers of registers found</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountBookAvailableViewByIsbn(string isbn)
        {
            try
            {
                return (int)_viewBookAvailableTableAdapter.SelectCountByISBN(isbn);
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

        #region BorrowedBookView
   
        /// <summary>
        /// Returns all registers from Borrowed Book view.
        /// </summary>
        /// <returns>BookDS.ViewBookDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookBorrowedDataTable GetAllBooksBorrowedView()
        {
            try
            {
                _viewBookBorrowedTableAdapter.FillAllBooksBorrowed(_bookDataSet.ViewBookBorrowed);
                return _bookDataSet.ViewBookBorrowed;
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
        /// Returns all registers from Borrowed Book view by Book Name.
        /// </summary>
        /// <param name="bookName">string bookName</param>
        /// <returns>BookDS.ViewBookBorrowedWithUserDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookBorrowedWithUserDataTable GetBooksBorrowedViewByName(string bookName)
        {
            try
            {
                bookName = "%" + bookName + "%";
                _viewBookBorrowedWithUserTableAdapter.FillAllBorrowedBooksByBookName(_bookDataSet.ViewBookBorrowedWithUser, bookName);
                return _bookDataSet.ViewBookBorrowedWithUser;
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

        #region BookBorrowedWithUserView

        /// <summary>
        /// Returns all registers from Borrowed BookBorrowedWithUser view.
        /// </summary>
        /// <returns>BookDS.ViewBookBorrowedWithUser</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookBorrowedWithUserDataTable GetAllBooksBorrowedWithUserView()
        {
            try
            {
                _viewBookBorrowedWithUserTableAdapter.FillAllBorrowedBooksWithUser(_bookDataSet.ViewBookBorrowedWithUser);
                return _bookDataSet.ViewBookBorrowedWithUser;
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
        /// Returns all registers from Borrowed BookBorrowedWithUser view by userID.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>BookDS.ViewBookBorrowedWithUser</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookBorrowedWithUserDataTable GetAllBooksBorrowedWithUserViewByUserId(int userId)
        {
            try
            {
                _viewBookBorrowedWithUserTableAdapter.FillAllBorrowedBooksByUserId(_bookDataSet.ViewBookBorrowedWithUser, userId);
                return _bookDataSet.ViewBookBorrowedWithUser;
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

        #region BookReservedView

        /// <summary>
        /// Returns all registers from BookReserved view.
        /// </summary>
        /// <returns>BookDS.ViewBookReservedDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookReservedDataTable GetAllBooksReservedView()
        {
            try
            {
                _viewBookReservedTableAdapter.FillAllReservedBooks(_bookDataSet.ViewBookReserved);
                return _bookDataSet.ViewBookReserved;
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
        /// Returns all registers from BookReserved view by userID.
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>BookDS.ViewBookReservedDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public BookDS.ViewBookReservedDataTable GetAllBooksReservedViewByUserId(int userId)
        {
            try
            {
                _bookDataSet = new BookDS();
                _viewBookReservedTableAdapter.FillAllReservedBooksByUserId(_bookDataSet.ViewBookReserved, userId);
                return _bookDataSet.ViewBookReserved;
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

        #region BookTable

        /// <summary>
        /// Delete register from TabBook.
        /// </summary>
        /// <param name="isbn">string isbn</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">DataAccessLayerException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteBook(string isbn)
        {
            try
            {
                return (int)_tabBookTableAdapter.DeleteBook(isbn);
            }
            catch (SqlException ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());

                if (ex.Number == 547)
                {
                    throw new DataAccessLayerException("Register is in use and can not be deleted.");
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
        /// Insert register into TabBook.
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
                return (int)_tabBookTableAdapter.InsertBook(isbn, bookName, author, category, language, publishYear, pages, publisher);
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
                else if (ex.Number == 2627)
                {
                    throw new DataAccessLayerException(Constants.msgExceptionISBNInUse);
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
        /// Update register from TabBook.
        /// </summary>
        /// <param name="updatedIsbn">string updatedIsbn</param>
        /// <param name="bookName">string bookName</param>
        /// <param name="author">int author</param>
        /// <param name="category">int category</param>
        /// <param name="language">int language</param>
        /// <param name="publishYear">int publishYear</param>
        /// <param name="pages">int pages</param>
        /// <param name="publisher">string publisher</param>
        /// <param name="isbn">string Isbn</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateBook(string updatedIsbn, string bookName, int author, int category, int language, int publishYear,
                              int pages, string publisher, string isbn)
        {
            try
            {
                return (int)_tabBookTableAdapter.UpdateBook(updatedIsbn, bookName, author, category, language, publishYear, pages, publisher, isbn);
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
