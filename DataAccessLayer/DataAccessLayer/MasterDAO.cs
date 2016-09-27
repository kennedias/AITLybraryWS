/* Data Access Object for the Author, Category and Language data
 * 
 * Project: Assignment 2 - AIT
 * Developer: Kennedy Oliveira - ID 5399
 * Data of release: 13/09/2016
 * Version: 1.0 - Release
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.MasterDSTableAdapters;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Classe designed for access the  Author, Category and Language data.
    /// </summary>
    /// <remarks>
    /// All access of data from  Author, Category and Language should be implemented here.</remarks>
    /// 
    public class MasterDAO
    {
        private MasterDS _masterDataSet;
        private TabAuthorTableAdapter _tabAuthorTableAdapter;
        private TabCategoryTableAdapter _tabCategoryTableAdapter;
        private TabLanguageTableAdapter _tabLanguageTableAdapter;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public MasterDAO()
        {
            _masterDataSet = new MasterDS();
            _tabAuthorTableAdapter = new TabAuthorTableAdapter();
            _tabCategoryTableAdapter = new TabCategoryTableAdapter();
            _tabLanguageTableAdapter = new TabLanguageTableAdapter();
        }


        /* AUTHOR */

        /// <summary>
        /// Returns all registers from TabAuthor
        /// </summary>
        /// <returns>MasterDS.TabAuthorDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public MasterDS.TabAuthorDataTable GetAllAuthors()
        {
            try
            {
                _tabAuthorTableAdapter.FillAll(_masterDataSet.TabAuthor);
                return _masterDataSet.TabAuthor;
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
        /// Delete register from TabAuthor.
        /// </summary>
        /// <param name="authorID">int authorID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">DataAccessLayerException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteAuthor(int authorID)
        {
            try
            {
                return (int)_tabAuthorTableAdapter.DeleteAuthor(authorID);
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
        /// Insert register into TabAuthor.
        /// </summary>
        /// <param name="authorName">string authorName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertAuthor(string authorName)
        {
            try
            {
                return (int)_tabAuthorTableAdapter.InsertAuthor(authorName);
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
        /// Select count in Author table by authorName.
        /// </summary>
        /// <param name="authorName">string authorName</param>
        /// <returns>int countResult</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountByAuthorName(string authorName)
        {
            try
            {
                return (int)_tabAuthorTableAdapter.SelectCountByAuthorName(authorName);
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
        /// Update register from TabAuthor.
        /// </summary>
        /// <param name="authorName">string authorName</param>
        /// <param name="authorID">int authorID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateAuthor(string authorName, int authorID)
        {
            try
            {
                return (int)_tabAuthorTableAdapter.UpdateAuthor(authorName, authorID);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }


        /* CATEGORY */


        /// <summary>
        /// Returns all registers from TabCategory
        /// </summary>
        /// <returns>MasterDS.TabCategoryDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public MasterDS.TabCategoryDataTable GetAllCategories()
        {
            try
            {
                _tabCategoryTableAdapter.FillAll(_masterDataSet.TabCategory);
                return _masterDataSet.TabCategory;
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
        /// Delete register from TabCategory.   
        /// </summary>
        /// <param name="categoryID">int categoryID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">DataAccessLayerException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteCategory(int categoryID)
        {
            try
            {
                return (int)_tabCategoryTableAdapter.DeleteCategory(categoryID);
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
        /// Insert register into TabCategory.
        /// </summary>
        /// <param name="categoryName">string categoryName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertCategory(string categoryName)
        {
            try
            {
                return (int)_tabCategoryTableAdapter.InsertCategory(categoryName);
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
        /// Select count in TabCategory table by categoryName.
        /// </summary>
        /// <param name="categoryName">string categoryName</param>
        /// <returns>int countResult</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountByCategoryName(string categoryName)
        {
            try
            {
                return (int)_tabCategoryTableAdapter.SelectCountByCategoryName(categoryName);
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
        /// Update register from TabCategory.
        /// </summary>
        /// <param name="categoryName">string categoryName</param>
        /// <param name="authorID">int authorID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateCategory(string categoryName, int authorID)
        {
            try
            {
                return (int)_tabCategoryTableAdapter.UpdateCategory(categoryName, authorID);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }



        /* Language */

        /// <summary>
        /// Returns all registers from TabLanguage
        /// </summary>
        /// <returns>MasterDS.TabLanguageDataTable</returns>
        /// <exception cref="ex">Exception</exception>
        public MasterDS.TabLanguageDataTable GetAllLanguages()
        {
            try
            {
                _tabLanguageTableAdapter.FillAll(_masterDataSet.TabLanguage);
                return _masterDataSet.TabLanguage;
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
        /// Delete register from TabLanguage.     
        /// </summary>
        /// <param name="languageID">int languageID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">DataAccessLayerException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteLanguage(int languageID)
        {
            try
            {
                return (int)_tabLanguageTableAdapter.DeleteLanguage(languageID);
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
        /// Insert register into TabLanguage.
        /// </summary>
        /// <param name="languageName">string languageName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int InsertLanguage(string languageName)
        {
            try
            {
                return (int)_tabLanguageTableAdapter.InsertLanguage(languageName);
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
        /// Select count in TabLanguage table by langaugeName.
        /// </summary>
        /// <param name="languageName">string languageName</param>
        /// <returns>int countResult</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountByLanguageName(string languageName)
        {
            try
            {
                return (int)_tabLanguageTableAdapter.SelectCountByLanguageName(languageName);
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
        /// Update register from TabLanguage.
        /// </summary>
        /// <param name="languageName">string languageName</param>
        /// <param name="languageID">int languageID</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">Exception</exception>
        public int UpdateLanguage(string languageName, int languageID)
        {
            try
            {
                return (int)_tabLanguageTableAdapter.UpdateLanguage(languageName, languageID);
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }
    }
}
