using System.Globalization;

namespace LootHub.Client.Mvc.Helpers;

public static class ProductDisplay
{
    public static string Price(decimal price)
    {
        return price.ToString("N2", new CultureInfo("tr-TR" )) + " ₺";
    }

    public static string StockLabel(int stock) => stock switch
    {
        <= 0 => "Tükendi",
        <= 5 => $"Son {stock} ürün",
        _ => "Stokta"
    };

    public static string StockCss(int stock) => stock switch
    {
        <= 0 => "lh-stock-out",
        <= 5 => "lh-stock-low",
        _ => "lh-stock-in"
    };

    public static string CategoryImage(string categoryName) => categoryName.ToLowerInvariant() switch
    {
        "mouse" => "/img/mouse.svg",
        "klavye" or "keyboard" => "/img/keyboard.svg",
        "kulaklık" or "headset" =>  "/img/headset.svg",
        "monitör" or "monitor" => "/img/monitor.svg",
        _ => "/img/mouse.svg"
    };

    public static string CategoryIcon(string categoryName) => categoryName.ToLowerInvariant() switch
    {
        "mouse" => "bi-mouse",
        "klavye" or "keyboard" => "bi-keyboard",
        "kulaklık" or "headset" => "bi-headset",
        "monitör" or "monitor" => "bi-display",
        _ => "bi-tag"
    };
}
