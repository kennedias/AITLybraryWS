/* Exception used with Book data
 * 
 * Project: Assignment 2 - AIT
 * Developer: Kennedy Oliveira - ID 5399
 * Data of release: 14/09/2016
 * Version: 1.0 - Release
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    /// <summary>
    /// Exceptions related with the Book.
    /// </summary>
    public class BusinessLogicException: Exception
    {
        /// <summary>
        /// Exception from Book.
        /// </summary>
        /// <param name="message">string message</param>
        public BusinessLogicException(string message)
            : base(message)
        {
        }
    }

}
