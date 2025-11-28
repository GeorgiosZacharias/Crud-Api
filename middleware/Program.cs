
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(o =>
{

});
var app = builder.Build();

app.UseHttpLogging();
app.MapGet("/", () => "Hello World!");

app.Run();
