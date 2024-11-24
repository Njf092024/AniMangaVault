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

        foreach (var item in items)
        {
            AnsiConsole.MarkupLine($"[cyan]ID:[/] {item.Id}, [bold]{item.Title}[/], [green]Rating:[/] {item.Rating}, [blue]Type:[/] [item.Type]");
        }
    }
}
