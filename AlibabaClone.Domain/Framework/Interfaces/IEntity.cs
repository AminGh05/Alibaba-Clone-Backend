namespace AlibabaClone.Domain.Framework.Interfaces
{
    interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
