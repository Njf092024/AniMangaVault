public class AnimeMangaService
{
    private List<AnimeMangaItem> items = new List<AnimeMangaItem>();

    public void AddNewAnimeMangaItem(AnimeMangaItem item)
    {
        items.Add(item);
    }

    public void ListAnimeMangaItems()
    {
        if (items.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No items available.[/]");
            return;
        }
    }
}
