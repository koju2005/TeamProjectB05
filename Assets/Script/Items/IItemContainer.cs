

public interface IItemContainer
{
    bool ContainsItem(ItemObject item);
    bool RemoveItem(ItemObject item);
    bool AddItem(ItemObject item);
    bool IsFull();
}
