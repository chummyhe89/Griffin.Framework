﻿using System.Data;

namespace Griffin.Data.Mapper
{
    /// <summary>
    /// Mapping for a class property
    /// </summary>
    public interface IPropertyMapping
    {
        /// <summary>
        /// Can write to property (i.e. update it from the table column)
        /// </summary>
        bool CanWrite { get; }

        /// <summary>
        /// Can read from the property (i.e. create UPDATE/INSERT queries)
        /// </summary>
        bool CanRead { get; }

        /// <summary>
        /// Used when fetching items
        /// </summary>
        bool IsPrimaryKey { get; set; }

        /// <summary>
        ///     Used to convert the database value to the type used by the property
        /// </summary>
        ValueHandler ColumnToPropertyAdapter { get; set; }


        /// <summary>
        ///     Used to convert the property to the type used by the column.
        /// </summary>
        ValueHandler PropertyToColumnAdapter { get; set; }


        /// <summary>
        ///     Name of the property in the entity
        /// </summary>
        string PropertyName { get; set; }

        /// <summary>
        ///     Set if the column name is different from the property name
        /// </summary>
        string ColumnName { get; set; }

        /// <summary>
        ///     Convert the value in the specified record and assign it to the property in the specified instance
        /// </summary>
        /// <param name="source">Database record</param>
        /// <param name="destination">Entity instance</param>
        /// <remarks>
        /// <para>Will exit the method without any assignment if the value is <c>DBNull.Value</c>.</para>
        /// </remarks>
        void Map(IDataRecord source, object destination);

        /// <summary>
        /// Get property value
        /// </summary>
        /// <param name="entity">Entity to retrieve value from</param>
        /// <returns>Property value</returns>
        object GetValue(object entity);

        /// <summary>
        /// Set property value by specifying a column value (i.e. use the <c>ColumnToPropertyAdapter</c> when assigning the value)
        /// </summary>
        /// <param name="entity">Entity to retrieve value from</param>
        /// <param name="value">Column value</param>
        /// <returns>Property value</returns>
        void SetColumnValue(object entity, object value);
    }
}