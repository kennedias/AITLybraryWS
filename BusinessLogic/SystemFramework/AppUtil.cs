using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace SystemFramework
{
    public static class AppUtil
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            // Extract Property information
            PropertyDescriptorCollection propertyCollection = TypeDescriptor.GetProperties(typeof(T));

            // Create Empty DataTable
            DataTable dataTable = new DataTable();
            dataTable.TableName = "wsTable";


            // Add column to empty DataTable
            for (int i = 0; i < propertyCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyCollection[i];
                dataTable.Columns.Add(propertyDescriptor.Name, propertyDescriptor.PropertyType);
            }

            // Insert Data
            object[] rowsList = new object[propertyCollection.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < rowsList.Length; i++)
                {
                    rowsList[i] = propertyCollection[i].GetValue(item);
                }

                dataTable.Rows.Add(rowsList);
            }

            return dataTable;
        }

        public static DataTable ThrowExceptionTable(Exception ex)
        {
            DataTable dt = new DataTable();

            dt.TableName = "Exception";
            dt.Columns.Add("Extype");
            dt.Columns.Add("Exmessage");

            DataRow row = dt.NewRow();
            row["Extype"] = ex.GetType().ToString();
            row["Exmessage"] = ex.Message;

            dt.Rows.Add(row);

            return dt;
        }

      /*  public static DataTable ToDataTable<T>(this int operationResult)
        {
            // Extract Property information
            PropertyDescriptorCollection propertyCollection = TypeDescriptor.GetProperties(typeof(T));

            // Create Empty DataTable
            DataTable dataTable = new DataTable();
            dataTable.TableName = "wsTable";


            // Add column to empty DataTable
            for (int i = 0; i < propertyCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyCollection[i];
                dataTable.Columns.Add(propertyDescriptor.Name, propertyDescriptor.PropertyType);
            }

            // Insert Data
            object[] rowsList = new object[propertyCollection.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < rowsList.Length; i++)
                {
                    rowsList[i] = propertyCollection[i].GetValue(item);
                }

                dataTable.Rows.Add(rowsList);
            }

            return dataTable;
        } */
    }
}
