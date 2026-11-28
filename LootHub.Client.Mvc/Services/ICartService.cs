using LootHub.Client.Mvc.Models;

namespace LootHub.Client.Mvc.Services;

public interface ICartService
{
    List<CartItem> GetItems();
    void Add(CartItem item);
    void UpdateQuantity(Guid productId, int quantity);
    void Remove(Guid productId);
    void Clear();
    int Count();
}
