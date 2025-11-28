
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(o =>
{

});
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Custom Middleware: Incoming Request");
    await next.Invoke();
    Console.WriteLine("Custom Middleware: Outgoing Response");
});
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "this is the hello endpoint");

app.Run();
