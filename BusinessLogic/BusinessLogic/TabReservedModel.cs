/* Model Object for the Reserved table data
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
    /// Model Object of the Reserved table view data.
    /// </summary>
    /// 
    public class TabReservedModel
    {
        #region fields

        private string _reservedBookName;
        private string _reservedBookIsbn;
        private string _reservedBookDate;
        private string _reservedBookUserName;
        private int _reservedBookId;
        private int _reservedBookUserId;


        #endregion

        #region Properties

        public string Name
        {
            set { _reservedBookName = value; }
            get { return _reservedBookName; }
        }

        public string ISBN
        {
            set { _reservedBookIsbn = value; }
            get { return _reservedBookIsbn; }
        }

        public string ReserveDate
        {
            set { _reservedBookDate = value; }
            get { return _reservedBookDate; }
        }

        public string User
        {
            set { _reservedBookUserName = value; }
            get { return _reservedBookUserName; }
        }

        public int ReserveId
        {
            set { _reservedBookId = value; }
            get { return _reservedBookId; }
        }

        public int UserId
        {
            set { _reservedBookUserId = value; }
            get { return _reservedBookUserId; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse of data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">BookDS.BookDS.TabReservedDataTable row</param>
        /// <returns>TabReservedModel</returns>
        public static TabReservedModel Parse(BookDS.TabReservedDataTable row)
        {
            if (row == null)
                return null;
            else
            {
                TabReservedModel tabReservedModel = new TabReservedModel();
                tabReservedModel._reservedBookName = row.BookNameColumn.ToString();
                tabReservedModel._reservedBookIsbn = row.ISBNColumn.ToString();
                tabReservedModel._reservedBookDate = row.ReservedDateColumn.ToString();
                tabReservedModel._reservedBookUserName = row.UserNameColumn.ToString();
                tabReservedModel._reservedBookId = Int32.Parse(row.RIDColumn.ToString());
                tabReservedModel._reservedBookUserId = Int32.Parse(row.ISBNColumn.ToString());

                return tabReservedModel;
            }
        }
        #endregion
    }
}
