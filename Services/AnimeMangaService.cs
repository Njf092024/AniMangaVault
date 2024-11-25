namespace AniMangaVault.Services
{
using AniMangaVault.Models;
using Spectre.Console;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


public class AnimeMangaService
{
    private List<AnimeMangaItem> items = new List<AnimeMangaItem>();
    private const string FileName = "animeMangaData.json";

    public AnimeMangaService()
    {
        LoadData();
    }

    public void AddNewAnimeMangaItem(AnimeMangaItem item)
    {
        items.Add(item);
        SaveData();
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
            AnsiConsole.MarkupLine($"[cyan]ID:[/] {item.Id}, [bold]{item.Title}[/], [green]Rating:[/] {item.Rating}, [blue]Type:[/] {item.Type}");
        }
    }

    public void UpdateRating(int id, int newRating)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.Rating = newRating;
            SaveData();
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Item not found.[/]");
        }
    }

    public void DeleteAnimeMangaItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            items.Remove(item);
            SaveData();
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Item not found.[/]");
        }
    }

    private void SaveData()
    {
        var json = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText(FileName, json);
    }

    private void LoadData()
    {
        if (File.Exists(FileName))
        {
            var json = File.ReadAllText(FileName);
            items = JsonConvert.DeserializeObject<List<AnimeMangaItem>>(json) ?? new List<AnimeMangaItem>();
        }
    }
}
}