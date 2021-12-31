using FrameWork.Core.Domain.Entities;
using System;

namespace FrameWork.Core.Domain.Data
{
    public interface ICommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {

    }
}
