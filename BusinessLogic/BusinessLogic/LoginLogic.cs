/* Contains all business logic of Login 
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
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    /// <summary>
    /// Business logic related with the Login.
    /// </summary>
    public class LoginLogic
    {
       
        // These values are declared in parameters for further improvements in the application,
        // with the uses of constants
        private int passwordMinLenght = 5;
        private int passwordMaxLenght = 10;
        private int passwordMinOfLetters = 3;
        private int passwordMinOfNumbers = 2;
        private string characterExpression = "[a-zA-Z]";    //Verify if there are letter from A to Z, low and upper case
        private string numberExpression = "[0-9]";          //Verify if there are numbers from 0 to 9
        private string messageOfValidation = "";

        /// <summary>
        /// This method valid the password format acoording with the business rules for password.
        /// The message of validation is avaiable in the attribute messageOfValidation.
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>Boolean</returns>
        /// <exception cref="ex">BusinessException</exception>
        /// <exception cref="ex">Exception</exception>
        public Boolean passwordFormatValidation(string password)
        {
            try
            {
                Boolean passwordFormatIsValid = false;
                messageOfValidation = "";

                // Rule for verify if the password contains at least one letter, lowcase or uppercase. 
                // The mask should go further for constants
                Regex regexContainLetter = new Regex(characterExpression);

                // Rule for verify if the password contains at least one number.
                // The mask should go further for constants
                Regex regexContainNumber = new Regex(numberExpression);

                if (password.Length < passwordMinLenght)
                {
                    passwordFormatIsValid = false;
                    messageOfValidation = "Password format invalid. It must have at least " + passwordMinLenght + " characters.";
                    throw new BusinessLogicException(messageOfValidation);
                }
                else if (password.Length > passwordMaxLenght)
                {
                    passwordFormatIsValid = false;
                    messageOfValidation = "Password format invalid. It must have at most " + passwordMaxLenght + " characters.";
                    throw new BusinessLogicException(messageOfValidation);
                }
                else if (regexContainLetter.Matches(password).Count < passwordMinOfLetters)
                {
                    passwordFormatIsValid = false;
                    messageOfValidation = "Password format invalid. It must have at least" + passwordMinOfLetters + " letters.";
                    throw new BusinessLogicException(messageOfValidation);
                }
                else if (regexContainNumber.Matches(password).Count < passwordMinOfNumbers)
                {
                    passwordFormatIsValid = false;
                    messageOfValidation = "Password format invalid. It must have at least" + passwordMinOfNumbers + " numbers.";
                    throw new BusinessLogicException(messageOfValidation);
                }
                else //login format is valid
                {
                    passwordFormatIsValid = true;
                    messageOfValidation = "";
                }

                return passwordFormatIsValid;
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
        /// Get messagem of validation
        /// </summary>
        public string MessageOfValidation
        {
            get { return messageOfValidation; }
        } 

     }
}
