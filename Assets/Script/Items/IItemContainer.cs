

public interface IItemContainer
{
    bool ContainItem(ItemSlot item);
    void RemoveItem(int index);
    void AddItem(ItemObject item);
    int ItemCount(ItemObject item);
}
