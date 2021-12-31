using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Domain.ApplicationServices.Queries
{
    public abstract class QueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        public abstract QueryResult<TResult> Handle(TQuery query);
    }
}
