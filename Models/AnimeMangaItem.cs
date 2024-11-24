namespace AniMangaVault.Models
{
public class AnimeMangaItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? Notes { get; set; }
}
}