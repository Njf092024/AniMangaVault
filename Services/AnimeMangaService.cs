namespace AniMangaVault.Services
{
using AniMangaVault.Models;
using Spectre.Console;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class AnimeMangaService
{
    private List<AnimeMangaItem> items = new List<AnimeMangaItem>();
    private const string FileName = "animeMangaData.json";
    private int idCounter = 1;

    public AnimeMangaService()
    {
        LoadData();
    }

    public void AddNewAnimeMangaItem(AnimeMangaItem item)
    {
        item.Id = GetNextId();
        items.Add(item);
        SaveData();
    }

    public void ListAnimeMangaItems()
    {
        if (!items.Any())
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
            var confirmation = AnsiConsole.Prompt
            (new ConfirmationPrompt($"[red]Are you sure you want to delete [bold]{item.Title}[/]?")
            .AddChoice("Yes")
            .AddChoice("No"));

            if (confirmation)
            {
                items.Remove(item);
                ReorderItemIds();
                SaveData();
                AnsiConsole.MarkupLine("[green]Item deleted succesfully![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[yellow]Deletion canceled.[/]");
            }
    }
    else
    {
        AnsiConsole.MarkupLine("[red]Item not fuond.[/]");
    }

    AnsiConsole.MarkupLine("Press any key to return to the main menu...");
    Console.ReadKey();
    
    private int GetNextId()
    {
        return items.Any() ? items.Max(item => item.Id) + 1 : 1;
    }

    public bool HasItems()
    {
        return items.Any();
    }

    public List<AnimeMangaItem> GetAnimeMangaItems()
    {
        return items;
    }


    private void SaveData()
    {
        var data = new
        {
            items = items,
            idCounter = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1
        };

        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(FileName, json);
    }

    private void LoadData()
    {
        if (File.Exists(FileName))
        {
            var json = File.ReadAllText(FileName);
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            if (data is JObject)
            {
            items = data?.items.ToObject<List<AnimeMangaItem>>() ?? new List<AnimeMangaItem>();
        }       
    }
}

private void ReorderItemIds()
{
    for (int i = 0; i < items.Count; i++)
    {
        items[i].Id = i + 1;
    }
}
}
}