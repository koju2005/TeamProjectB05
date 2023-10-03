

public interface IItemContainer
{
    bool ContainItem(ItemData item);
    void RemoveItem(ItemData item);
    void AddItem(ItemData item);
    int ItemCount(ItemData item);
}
