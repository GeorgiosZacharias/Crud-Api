var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog { Title = "First Blog", Content = "This is my first blog post." },
    new Blog { Title = "Second Blog", Content = "This is my second blog post." }
};

app.MapGet("/", () => "I am root");

app.MapGet("/blogs", () => blogs);

app.MapGet("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    return Results.Ok(blogs[id]);
});

app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    //var blog = blogs[id]; you want to grab it and probably return it
    blogs.RemoveAt(id);
    return Results.NoContent();
});

app.Run();

public class Blog
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}