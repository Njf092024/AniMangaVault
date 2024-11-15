namespace AniMangaVault;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        AnimeMangaService service = new AnimeMangaService();
        int idCounter = 1;
        bool exit = false;
        
        while (!exit)
        {
            Console.Clear();
            var prompt = new SelectionPrompt<string>()
            .Title("[bold yellow]Anime/Manga Menu[/]")
            .PageSize(10)
            .AddChoices("Add new Anime/Manga", "List all Anime/Manga", "Update Rating", "Delete Anime/Manga", "Exit");

            var selectedOption = AnsiConsole.Prompt(prompt);

            switch (selectedOption)
            {
                case "Add New Anime/Manga":
                AddNewAnimeMangaItems(service, ref idCounter);
                break;
                case "List All Anime/Manga":
                ListAnimeMangaItems(service, ref idCounter);
                break;
                case "Update Rating":
                UpdateAnimeMangaRating(service, ref idCounter);
                break;
                case "Delete Anime/Manga":
                DeleteAnimeMangaItem(service, ref idCounter);
                break;
                case "Exit":
                exit = true;
                break;
            }
        }
    }

    static void AddNewAnimeMangaItems(AnimeMangaService service, ref int idCounter)
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Add a new Anime/Manga[/]");
        string title = AnsiConsole.Ask<string>("Enter the title: ");
        string type = AnsiConsole.Ask<string>("Enter type (Anime/Manga): ");
        string description = AnsiConsole.Ask<string>("Enter description: ");
        int rating = AnsiConsole.ask<string>("Enter rating (1-6): ");
        string notes = AnsiConsole.ask<string>(" Enter notes: ");

        var newItem = new AnimeMangaItem
        {
            Id = idCounter++,
            Title = title,
            Type = type,
            Description = description,
            Rating = rating,
            Notes = notes, 
        };

        service.AddNewAnimeMangaItem(newItem);

        AnsiConsole.MarkupLine("[Green]Anime/Manga added sucessfully![/]");
        AnsiConsole.MarkupLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void ListAnimeMangaItems(AnimeMangaService service)
}
