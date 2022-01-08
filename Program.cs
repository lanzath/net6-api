var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new { message = "Hello World!" });

app.MapGet("/name/{name}", (string name) =>
{
    // {name} é um query param, retorna um JSON com status code 200 (Ok).
    return Results.Ok(new { message = $"Hello {name}" });
});

app.MapPost("/", (User user) =>
{
    return Results.Created("/", user);
});

app.Run();

public class User
{
    // Constructor gera o Id.
    public User() => Id = Guid.NewGuid();

    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}
