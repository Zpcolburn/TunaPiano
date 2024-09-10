using TunaPiano.Models;

namespace TunaPiano.Data
{
    public class ArtistData
    {
        public static List<Artist> Artists = new List<Artist>
        {
            new Artist
            {
                Id = 1,
                Name = "Jackson Ridge",
                Age = 35,
                Bio = "Hailing from Nashville, Jackson Ridge blends traditional country sounds with a modern twist. Known for his deep, gravelly voice and heartfelt ballads, Jackson's songs about love, heartache, and small-town life have made him a fan favorite in the country music scene.",
            },

            new Artist
            {
                Id = 2,
                Name = "Sadie Mae Walker",
                Age = 27,
                Bio = "Texas native Sadie Mae Walker is a rising star in the country music scene. Her energetic performances and relatable lyrics about southern life have propelled her to the top of country charts. She brings a youthful, modern edge to traditional country sounds.\r\n",
            },

            new Artist
            {
                Id = 3,
                Name = "Milo River",
                Age = 29,
                Bio = "An indie rock artist from Portland, Milo Rivers combines raw guitar riffs with introspective lyrics. His music is known for its emotional depth and unique sound, making him a standout in the underground indie scene.",
            },

            new Artist
            {
                Id = 4,
                Name = "Layla Sky",
                Age = 24,
                Bio = "A pop sensation from Los Angeles, Layla Sky's catchy melodies and upbeat dance tracks have made her a household name. Her infectious energy and glittering stage presence have won over fans around the world, making her one of pop music’s brightest stars.",
            },

            new Artist
            {
                Id = 5,
                Name = "Ezra Cole",
                Age = 42,
                Bio = "Ezra Cole is a seasoned blues artist from Memphis, known for his soulful voice and masterful guitar skills. With roots in traditional Delta blues, his music explores themes of hardship and resilience, capturing the heart of the blues genre.",
            },

        };
    }
}