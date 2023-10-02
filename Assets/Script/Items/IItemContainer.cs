

public interface IItemContainer
{
    bool ContainsItem(ItemData item);
    bool RemoveItem(ItemData item);
    bool AddItem(ItemData item);
    bool IsFull();
}
