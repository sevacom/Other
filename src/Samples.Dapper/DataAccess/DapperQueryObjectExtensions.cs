﻿using System.Collections.Generic;
using System.Data;
using Dapper;
using Samples.Dapper.DataAccess.Query;

namespace Samples.Dapper.DataAccess
{
    /// <summary>
    ///     Dapper + QueryObject extensions
    /// </summary>
    public static class DapperQueryObjectExtensions
    {
        /// <summary>
        ///     Dapper + QueryObject extension for Query
        /// </summary>
        public static IEnumerable<T> Query<T>(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Query<T>(queryObject.Sql, queryObject.Params, transaction, buffered, commandTimeout, commandType);
        }

        /// <summary>
        ///     Dapper + QueryObject extension for Execute
        /// </summary>
        public static int Execute(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Execute(queryObject.Sql, queryObject.Params, transaction, commandTimeout, commandType);
        }
    }
}