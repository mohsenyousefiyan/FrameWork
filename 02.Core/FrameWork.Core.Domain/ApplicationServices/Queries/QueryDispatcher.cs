using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Domain.ApplicationServices.Queries
{
    public sealed class QueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public QueryResult<TResult> Dispatch<TResult>(IQuery query)
        {
            Type type = typeof(QueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            QueryResult<TResult> result = handler.Handle((dynamic)query);
            return result;
        }
    }
}
