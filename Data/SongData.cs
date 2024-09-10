using TunaPiano.Models;

namespace TunaPiano.Data
{
    public class SongData
    {
        public static List<Song> Songs = new List<Song>
        {
            new Song
            {
                Id = 1,
                Title = "Whiskey on the Wind",
                ArtistId = 1,
                Album = "Highway to Home",
                Length = 225,
            },

            new Song
            {
                Id = 2,
                Title = "Small Town Sundown",
                ArtistId =1,
                Album = "American Dreamer",
                Length = 242,
            },

            new Song
            {
                Id = 3,
                Title = "Lone Star Night",
                ArtistId = 2,
                Album = "Texas Heart",
                Length = 230,
            },

            new Song
            {
                Id = 4,
                Title = "Dust on My Boots",
                ArtistId = 2,
                Album = "Honky-Tonk Heartbeat",
                Length = 250,
            },

            new Song
            {
                Id = 5,
                Title = "Echoes in the Rain",
                ArtistId = 3,
                Album = "Broken Horizons",
                Length = 260,
            },

            new Song
            {
                Id = 6,
                Title = "Neon Nights",
                ArtistId = 3,
                Album = "Under the Bridge",
                Length = 238,
            },

            new Song
            {
                Id = 7,
                Title = "Shimmering Lights",
                ArtistId = 4,
                Album = "Neon Glow",
                Length = 210,
            },

            new Song
            {
                Id = 8,
                Title = "Starlight City",
                ArtistId = 4,
                Album = "Cosmic Beat",
                Length = 220,
            },

            new Song
            {
                Id = 9,
                Title = "River of Sorrow",
                ArtistId = 5,
                Album = "Midnight Blues",
                Length = 315,
            },

            new Song
            {
                Id = 10,
                Title = "Broken Strings",
                ArtistId = 5,
                Album = "Deep Waters",
                Length = 365,
            },
        };
    }
}