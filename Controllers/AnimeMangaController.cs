using Microsoft.AspNetCore.Mvc;
using AniMangaVault.Models;
using AniMangaVault.Services;

[ApiController]
[Route("api/[animemanga]")]

public class AnimeMangaController : ControllerBase
{
    private readonly AnimeMangaService _service;

    public AnimeMangaController()
    {
        _Service = new AnimeMangaService();
    }

    [HttpGet]
    public IActionResult GetAllItems()
    {
        var items = _service.GetAnimeMangaItems();
        return Ok(items);
    }

    [HttpGet("[id]")]
    public IActionResult GetItemById(int id)
    {
        var item = _service.GetAnimeMangaItems().FirstOrDefault(i => i.Id == id);
        if (item == null) return NotFound($"Item with ID {id} not found.");
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateItem([FromBody] AnimeMangaItem newItem)
    _service.AddNewAnimeMangaItem(newItem);
    return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);
}

[HttpPut("{id}")]
public IActionResult UpdateRating(int id, [FromBody] int newRating)
{
    var item = _service.GetAnimeMangaItems().FirstOrDefault(i => i.Id == id);
    if (item == null) return NotFound($"Item with ID {id} not found.");

    -service.UpdateRating(id, newRating);
    return NoContent();
}

[HttpDelete("{id}")]
public IActionResult DeleteItem(int id)
{
    if (!_service.HasItems()) return NotFound("No items available");
    var item = _servie.GetAnimeMangaItems().FirstOrDefault(i => i.Id == id);
    if (item == null) return NotFound($"item with ID {id} not found.");

    _service.DeleteAnimeMangaItem(id);
    return NoContent();
}
