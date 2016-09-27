/* Exception used for DataAccessLayer
 * 
 * Project: Assignment 2 - AIT
 * Developer: Kennedy Oliveira - ID 5399
 * Data of release: 07/09/2016
 * Version: 1.0 - Release
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    /// <summary>
    /// Exception used for DataAccessLayer
    /// </summary>
    public class DataAccessLayerException: Exception
    {
        /// <summary>
        /// Exception from DataAccessLayer.
        /// </summary>
        /// <param name="message">string message</param>
        public DataAccessLayerException(string message)
        : base(message)
        {
        }
    }
}
