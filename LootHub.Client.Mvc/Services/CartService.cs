using LootHub.Client.Mvc.Models;
using System.Text.Json;

namespace LootHub.Client.Mvc.Services;

public class CartService(IHttpContextAccessor httpContextAccessor) : ICartService
{
    private const string SessionKey = "cart";
    private const int MaxQuantity = 10;
    private ISession Session => httpContextAccessor.HttpContext!.Session;

    public List<CartItem> GetItems()
    {
        var items = Session.GetString(SessionKey);
        if (items is null)
            return [];

        return JsonSerializer.Deserialize<List<CartItem>>(items) ?? [];
    }

    private void Save(List<CartItem> items)
    {
        var json = JsonSerializer.Serialize(items);
        Session.SetString(SessionKey, json);
    }

    public void Add(CartItem item)
    {
        var items = GetItems();
        var existing = items.FirstOrDefault(x => x.ProductId == item.ProductId);
        if (existing is not null)
        {
            existing.Quantity = Math.Min(existing.Quantity + item.Quantity, Math.Min(MaxQuantity, existing.Stock));
        }
        else
        {
            item.Quantity = Math.Min(item.Quantity, Math.Min(MaxQuantity, item.Stock));
            items.Add(item);
        }

        Save(items);
    }

    public void UpdateQuantity(Guid productId, int quantity)
    {
        var items = GetItems();
        var item = items.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
            return;
        if (quantity <= 0)
            items.Remove(item);
        else
            item.Quantity = Math.Min(quantity, Math.Min(MaxQuantity, item.Stock));

        Save(items);
    }

    public void Remove(Guid productId)
    {
        var items = GetItems();
        items.RemoveAll(x => x.ProductId == productId);
        Save(items);
    }

    public void Clear() => Session.Remove(SessionKey);

    public int Count() => GetItems().Sum(x => x.Quantity);


}
