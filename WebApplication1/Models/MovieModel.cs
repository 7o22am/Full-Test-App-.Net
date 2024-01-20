namespace WebApplication1.Models
{
    public class MovieModel
{
    public int Page { get; set; }
    public List<MovieResult>? Results { get; set; }
}

public class MovieResult
{

    public int Id { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string? poster_path { get; set; }
    public string? release_date { get; set; }
    public string? Title { get; set; }
    public double vote_average { get; set; }
    public string vote_count { get; set; }
}
}
