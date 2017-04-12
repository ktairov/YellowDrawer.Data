using YellowDrawer.Data.Common;

namespace YellowDrawer.Data.NH.SoftDeletion
{
    public interface IDeletable<T> : IIdentifiable<T>, IDeletable where T : struct
    {
        new T? DeletedKey { get; set; }
    }

    public interface IDeletable : IIdentifiable
    {
        object DeletedKey { get; set; }
    }
}
