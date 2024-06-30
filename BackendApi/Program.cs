using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackendApi.Models;
using BackendApi.Database;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("postgres") ?? "Data Source=players.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(
   options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
);


// builder.Services.AddNpgsql<ApplicationDbContext>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BackendApi API",
        Description = "Handling Backend Shit",
        Version = "v1"
    });
});

// 1) define a unique string
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 2) define allowed domains, in this case "http://example.com" and "*" = all
//    domains, for testing purposes only.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "http://example.com", "*");
      });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendApi API V1");
    });
}

// 3) use the capability
app.UseCors(MyAllowSpecificOrigins);


// ENDPOINTS
app.MapGet("/", () => "Hello World!");
app.MapGet("/player", async (ApplicationDbContext db) => await db.Player.ToListAsync());
app.MapPost("/player", async (ApplicationDbContext db, Player player) =>
{
    await db.Player.AddAsync(player);
    await db.SaveChangesAsync();
    return Results.Created($"/player/{player.Id}", player);
});
app.MapGet("/player/{id}", async (ApplicationDbContext db, int id) => await db.Player.FindAsync(id));
app.MapPut("/player/{id}", async (ApplicationDbContext db, Player updateplayer, int id) =>
{
    var player = await db.Player.FindAsync(id);
    if (player is null) return Results.NotFound();
    player.Name = updateplayer.Name;
    player.Description = updateplayer.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/player/{id}", async (ApplicationDbContext db, int id) =>
{
    var player = await db.Player.FindAsync(id);
    if (player is null)
    {
        return Results.NotFound();
    }
    db.Player.Remove(player);
    await db.SaveChangesAsync();
    return Results.Ok();
});


app.MapGet("/game", async (ApplicationDbContext db) => await db.Game.ToListAsync());
app.MapPost("/game", async (ApplicationDbContext db, Game game) =>
{
    await db.Game.AddAsync(game);
    await db.SaveChangesAsync();
    return Results.Created($"/game/{game.Id}", game);
});
app.MapGet("/game/{id}", async (ApplicationDbContext db, int id) => await db.Game.FindAsync(id));
app.MapPut("/game/{id}", async (ApplicationDbContext db, Game updategame, int id) =>
{
    var game = await db.Game.FindAsync(id);
    if (game is null) return Results.NotFound();
    game.Name = updategame.Name;
    game.Os = updategame.Os;
    game.Resets = updategame.Resets;
    game.FlagNum = updategame.FlagNum;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/game/{id}", async (ApplicationDbContext db, int id) =>
{
    var game = await db.Game.FindAsync(id);
    if (game is null)
    {
        return Results.NotFound();
    }
    db.Game.Remove(game);
    await db.SaveChangesAsync();
    return Results.Ok();
});


app.Run();
