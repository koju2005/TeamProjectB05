

public interface IItemContainer
{
    bool ContainItem(ItemObject item);
    void RemoveItem(ItemObject item);
    void AddItem(ItemObject item);
    int ItemCount(ItemObject item);
}
