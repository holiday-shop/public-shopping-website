using System;
using System.Data.SqlClient;

namespace dotnetcore_city_info.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static T GetNullableValue<T>(this SqlDataReader reader, int columnIndex) 
        {
            var value = reader[columnIndex];

            if (value == DBNull.Value)
            {
                return default(T);
            }

            return (T) value;
        }

        public static T GetNullableValue<T>(this SqlDataReader reader, int? columnIndex)
        {
            return columnIndex.HasValue ? GetNullableValue<T>((SqlDataReader) reader, columnIndex.Value) : default(T);
        }

        public static T GetNullableValue<T>(this SqlDataReader reader, string columnName)
        {
            return GetNullableValue<T>((SqlDataReader) reader, reader.GetOrdinal(columnName));
        }

        public static int? GetOptionalOrdinal(this SqlDataReader reader, string columnName)
        {
            for (var col = 0; col < reader.FieldCount; col++)
            {
                if (reader.GetName(col).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return col;
                }
            }

            return null;
        }

        public static T GetValue<T>(this SqlDataReader reader, string columnName)
        {
            var value = reader[columnName];

            if (value == DBNull.Value)
                return default(T);

            return (T) value;
        }
    }
}