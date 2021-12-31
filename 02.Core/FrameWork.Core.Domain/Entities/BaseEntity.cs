using System;

namespace FrameWork.Core.Domain.Entities
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get;  set; }        
    }
}
