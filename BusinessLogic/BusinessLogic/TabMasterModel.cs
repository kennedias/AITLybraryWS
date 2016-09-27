/* Model Object for the of Author and Category and Language 
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
    /// Model Object of Author and Category and Language data.
    /// </summary>
    /// 
    public class TabMasterModel
    {
        #region fields

        private int _dataId;
        private string _dataDescription;
 
        #endregion

        #region Properties

        public int ID
        {
            set { _dataId = value; }
            get { return _dataId; }
        }

        public string Description
        {
            set { _dataDescription = value; }
            get { return _dataDescription; }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Parse of Author data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">MasterDS.TabAuthorRow row</param>
        /// <returns>MasterModel</returns>     
        public static TabMasterModel Parse(MasterDS.TabAuthorRow row)
        {
            if (row == null)
                return null;
            else
            {
                TabMasterModel masterModel = new TabMasterModel();
                masterModel._dataId = row.AID;
                masterModel._dataDescription = row.AuthorName;
                return masterModel;
            }
        }

        /// <summary>
        /// Parse of Category data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">MasterDS.TabCategoryRow row</param>
        /// <returns>MasterModel</returns>     
        public static TabMasterModel Parse(MasterDS.TabCategoryRow row)
        {
            if (row == null)
                return null;
            else
            {
                TabMasterModel masterModel = new TabMasterModel();
                masterModel._dataId = row.CID;
                masterModel._dataDescription = row.CategoryName;
                return masterModel;
            }
        }

        /// <summary>
        /// Parse of Language data from the DS object to the model object.
        /// Returns null if the row is null.
        /// </summary>
        /// <param name="row">MasterDS.TabLanguageRow row</param>
        /// <returns>MasterModel</returns>     
        public static TabMasterModel Parse(MasterDS.TabLanguageRow row)
        {
            if (row == null)
                return null;
            else
            {
                TabMasterModel masterModel = new TabMasterModel();
                masterModel._dataId = row.LID;
                masterModel._dataDescription = row.LanguageName;
                return masterModel;
            }
        }
        #endregion
    }
}
