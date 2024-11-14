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
        }
    }
}
