using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TunaPiano;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDBContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Songs 
// Create Song
app.MapPost("/songs", (TunaPianoDBContext db, Song song) =>
{
    // Check if the artist exists
    var artistExists = db.Artists.Any(a => a.Id == song.ArtistId);
    if (!artistExists)
    {
        return Results.BadRequest("Artist not found.");
    }

    // Add song if the artist exists
    db.Songs.Add(song);
    db.SaveChanges();
    return Results.Created($"/songs/{song.Id}", song);
});


//Delete Song
app.MapDelete("/songs/{id}", (TunaPianoDBContext db, int id) =>
{
    var song = db.Songs.FirstOrDefault(s => s.Id == id);
    if (song == null) return Results.NotFound();

    db.Songs.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
});

//Update Song
app.MapPut("/songs/{id}", (TunaPianoDBContext db, int id, Song updatedSong) =>
{
    var song = db.Songs.FirstOrDefault(s => s.Id == id);
    if (song == null) return Results.NotFound();

    song.Title = updatedSong.Title;
    song.ArtistId = updatedSong.ArtistId;
    song.Album = updatedSong.Album;
    song.Length = updatedSong.Length;

    db.SaveChanges();
    return Results.Ok(song);
});

// View all Songs
app.MapGet("/songs", (TunaPianoDBContext db) =>
{
    return Results.Ok(db.Songs.ToList());
});

// Details of Songs 
app.MapGet("/songs/{id}", (TunaPianoDBContext db, int id) =>
{
    var song = db.Songs
        .Include(s => s.Genres)
        .Include(s => s.ArtistId)
        .FirstOrDefault(s => s.Id == id);

    if (song == null) return Results.NotFound();
    return Results.Ok(song);
});

// Artist
// Create Artist
app.MapPost("/artists", (TunaPianoDBContext db, Artist artist) =>
{
    db.Artists.Add(artist);
    db.SaveChanges();
    return Results.Created($"/artists/{artist.Id}", artist);
});

// Delete Artist
app.MapDelete("/artists/{id}", (TunaPianoDBContext db, int id) =>
{
    var artist = db.Artists.FirstOrDefault(a => a.Id == id);
    if (artist == null)
    {
        return Results.NotFound();
    }

    db.Artists.Remove(artist);
    db.SaveChanges();
    return Results.NoContent();
});

//Update Artist
app.MapPut("/artists/{id}", (TunaPianoDBContext db, int id, Artist updatedArtist) =>
{
    var artist = db.Artists.FirstOrDefault(a => a.Id == id);
    if (artist == null)
    {
        return Results.NotFound();
    }

    artist.Name = updatedArtist.Name;
    artist.Age = updatedArtist.Age;
    artist.Bio = updatedArtist.Bio;

    db.SaveChanges();
    return Results.Ok(artist);
});

// View all Artist
app.MapGet("/artists", (TunaPianoDBContext db) =>
{
    return db.Artists.ToList();
});

// Artist Details
app.MapGet("/artists/{id}", async (TunaPianoDBContext db, int id) =>
{
    var artist = await db.Artists
        .Include(a => a.Songs)  
        .FirstOrDefaultAsync(a => a.Id == id);

    if (artist == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artist);
});

//Genres
//Create Genre
app.MapPost("/genres", (TunaPianoDBContext db, Genre genre) =>
{
    db.Genres.Add(genre);
    db.SaveChanges();
    return Results.Created($"/genres/{genre.Id}", genre);
});

//Delete Genre
app.MapDelete("/genres/{id}", (TunaPianoDBContext db, int id) =>
{
    var genre = db.Genres.FirstOrDefault(g => g.Id == id);
    if (genre == null)
    {
        return Results.NotFound();
    }

    db.Genres.Remove(genre);
    db.SaveChanges();
    return Results.NoContent();
});

//Update Genre
app.MapPut("/genres/{id}", (TunaPianoDBContext db, int id, Genre updatedGenre) =>
{
    var genre = db.Genres.FirstOrDefault(g => g.Id == id);
    if (genre == null)
    {
        return Results.NotFound();
    }

    genre.Description = updatedGenre.Description;

    db.SaveChanges();
    return Results.Ok(genre);
});

// View all Genre
app.MapGet("/genres", (TunaPianoDBContext db) =>
{
    return db.Genres.ToList();
});

// Genre Details
app.MapGet("/genres/{id}", async (TunaPianoDBContext db, int id) =>
{
    var genre = await db.Genres
        .Include(g => g.Songs)  
        .FirstOrDefaultAsync(g => g.Id == id);

    if (genre == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(genre);
});


app.Run();
