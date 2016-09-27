/* Contains all master information logic of Author and Category and Language 
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
    /// Business logic information of Author and Category and Language.
    /// </summary>
    public class MasterLogic
    {
        private MasterDAO _masterDAO;
        private MasterDS.TabAuthorDataTable _tabAuthorDataTable;
        private MasterDS.TabCategoryDataTable _tabCategoryDataTable;
        private MasterDS.TabLanguageDataTable _tabLanguageDataTable;
        private List<TabMasterModel> _listTabMasterModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public MasterLogic()
        {
            try
            {
                _masterDAO = new MasterDAO();
                _tabAuthorDataTable = new MasterDS.TabAuthorDataTable();
                _tabCategoryDataTable = new MasterDS.TabCategoryDataTable();
                _tabLanguageDataTable = new MasterDS.TabLanguageDataTable();
                _listTabMasterModel = new List<TabMasterModel>();
            }
            catch (Exception ex)
            {
                //Error log simulate
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.GetBaseException().ToString());
                throw;
            }
        }

        #region Author

        /// <summary>
        /// Insert author.
        /// </summary>
        /// <param name="authorName">string authorName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int insertAuthor(string authorName)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountAuthorByName(authorName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Author Name already used.");
                }

                resultQuery = _masterDAO.InsertAuthor(authorName);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Author not inserted.");
                }

                return resultQuery;
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
        /// Select Count(*) from Author by Author Name.
        /// </summary>
        /// <param name="authorName">string authorName</param>
        /// <returns>int numbers of registers found</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountAuthorByName(string authorName)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.SelectCountByAuthorName(authorName);
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
        /// Delete author.
        /// </summary>
        /// <param name="authorId">int authorId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteAuthor(int authorId)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.DeleteAuthor(authorId);
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
        /// Update author.
        /// </summary>
        /// <param name="authorId">int authorId</param>
        /// <param name="authorName">string authorName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int updateAuthor(string authorName, int authorId)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountAuthorByName(authorName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Author Name already used.");
                }

                resultQuery = _masterDAO.UpdateAuthor(authorName, authorId);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Author not updated.");
                }

                return resultQuery;
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
        /// Return authors.
        /// </summary>
        /// <returns>List<TabMasterModel></returns>
        /// <exception cref="ex">Exception</exception>
        public List<TabMasterModel> GetAllAuthors()
        {
            try
            {
                _listTabMasterModel = new List<TabMasterModel>();
                _tabAuthorDataTable = _masterDAO.GetAllAuthors();

                foreach (MasterDS.TabAuthorRow row in _tabAuthorDataTable.Rows)
                {
                    _listTabMasterModel.Add(TabMasterModel.Parse(row));
                }

                return _listTabMasterModel;
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

        #region Category

        /// <summary>
        /// Insert Category.
        /// </summary>
        /// <param name="categoryName">string categoryName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int insertCategory(string categoryName)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountCategoryByName(categoryName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Category Name already used.");
                }

                resultQuery = _masterDAO.InsertCategory(categoryName);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Category not inserted.");
                }

                return resultQuery;
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
        /// Select Count(*) from Category by Category Name.
        /// </summary>
        /// <param name="categoryName">string categoryName</param>
        /// <returns>int numbers of registers found</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountCategoryByName(string categoryName)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.SelectCountByCategoryName(categoryName);
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
        /// Delete Category.
        /// </summary>
        /// <param name="categoryId">int categoryId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteCategory(int categoryId)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.DeleteCategory(categoryId);
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
        /// Update Category.
        /// </summary>
        /// <param name="categoryId">int categoryId</param>
        /// <param name="categoryName">string categoryName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int updateCategory(string categoryName, int categoryId)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountCategoryByName(categoryName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Category Name already used.");
                }

                resultQuery = _masterDAO.UpdateCategory(categoryName, categoryId);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Category not updated.");
                }

                return resultQuery;
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
        /// Return Categories.
        /// </summary>
        /// <returns>List<TabMasterModel></returns>
        /// <exception cref="ex">Exception</exception>
        public List<TabMasterModel> GetAllCategories()
        {
            try
            {
                _listTabMasterModel = new List<TabMasterModel>();
                _tabCategoryDataTable = _masterDAO.GetAllCategories();

                foreach (MasterDS.TabCategoryRow row in _tabCategoryDataTable.Rows)
                {
                    _listTabMasterModel.Add(TabMasterModel.Parse(row));
                }

                return _listTabMasterModel;
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

        #region Language

        /// <summary>
        /// Insert Language.
        /// </summary>
        /// <param name="languageName">string languageName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int insertLanguage(string languageName)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountLanguageByName(languageName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Language Name already used.");
                }

                resultQuery = _masterDAO.InsertLanguage(languageName);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Language not inserted.");
                }

                return resultQuery;
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
        /// Select Count(*) from Language by Language Name.
        /// </summary>
        /// <param name="languageName">string languageName</param>
        /// <returns>int numbers of registers found</returns>
        /// <exception cref="ex">Exception</exception>
        public int SelectCountLanguageByName(string languageName)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.SelectCountByLanguageName(languageName);
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
        /// Delete Language.
        /// </summary>
        /// <param name="languageId">int languageId</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int DeleteLanguage(int languageId)
        {
            try
            {
                _masterDAO = new MasterDAO();
                return _masterDAO.DeleteLanguage(languageId);
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
        /// Update Language.
        /// </summary>
        /// <param name="languageId">int languageId</param>
        /// <param name="languageName">string languageName</param>
        /// <returns>int rowsAffected</returns>
        /// <exception cref="ex">BusinessLogicException</exception>
        /// <exception cref="ex">Exception</exception>
        public int updateLanguage(string languageName, int languageId)
        {
            try
            {
                int resultQuery = 0;

                resultQuery = this.SelectCountLanguageByName(languageName);
                if (resultQuery > 0)
                {
                    throw new BusinessLogicException("Language Name already used.");
                }

                resultQuery = _masterDAO.UpdateLanguage(languageName, languageId);
                if (resultQuery == 0)
                {
                    throw new BusinessLogicException("Language not updated.");
                }

                return resultQuery;
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
        /// Return Languages.
        /// </summary>
        /// <returns>List<TabMasterModel></returns>
        /// <exception cref="ex">Exception</exception>
        public List<TabMasterModel> GetAllLanguages()
        {
            try
            {
                _listTabMasterModel = new List<TabMasterModel>();
                _tabLanguageDataTable = _masterDAO.GetAllLanguages();

                foreach (MasterDS.TabLanguageRow row in _tabLanguageDataTable.Rows)
                {
                    _listTabMasterModel.Add(TabMasterModel.Parse(row));
                }

                return _listTabMasterModel;
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
