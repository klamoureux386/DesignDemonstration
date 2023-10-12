using DesignDemonstration.Entities;
using System.Diagnostics;
using System.Globalization;

namespace DesignDemonstration
{
    public static class DbInitializer
    {

        //Initializes in-memory SqlLite DB.
        public static void Initialize(DataContext context)
        {
            AddUsers(context);

            AddBands(context);

            Band NoKnife = context.Bands.First(b => b.Id == 1);
            Band RivalSchools = context.Bands.First(b => b.Id == 2);

            AddAlbums(context);

            AddMusicians(context);

            AddSongs(context);

            AddFeaturedArtists(context);


            void AddUsers(DataContext context)
            {
                if (context.Users.Any())
                {
                    return; // DB has been seeded
                }

                var users = new List<User>();

                users.AddRange(new List<User>() {
                    new User() { Id = 1, Username = "Halifex", Email = "klamoureux386@gmail.com", Type = "Staff", DisplayName = "Kyle Lamoureux", isAdmin = true }
                });

                context.AddRange(users);
                context.SaveChanges();
            }

            void AddBands(DataContext context)
            {
                // Look for any Bands.
                if (context.Bands.Any())
                {
                    return;
                }

                var bands = new List<Band>()
                {
                    new Band{ Id = 1, Name = "No Knife" },
                    new Band{ Id = 2, Name = "Rival Schools" },
                    new Band{ Id = 3, Name = "Shiner" },
                };

                context.Bands.AddRange(bands);
                context.SaveChanges();
            }

            void AddAlbums(DataContext context)
            {
                if (context.Albums.Any())
                {
                    return;
                }

                var albums = new List<Album>();

                //No Knife
                albums.AddRange(new List<Album>
                {
                    new Album { Id = 1, Title = "Drunk on the Moon", Bands = new List<Band> { NoKnife } },
                    new Album { Id = 2, Title = "Hit Man Dreams", Bands = new List<Band> { NoKnife } },
                    new Album { Id = 3, Title = "Fire in the City of Automatons", Bands = new List<Band> { NoKnife } },
                    new Album { Id = 4, Title = "Riot for Romance", Bands = new List<Band> { NoKnife } },
                });

                //Rival Schools
                albums.AddRange(new List<Album>
                {
                    new Album { Id = 5, Title = "United by Fate", Bands = new List<Band> { RivalSchools } },
                    new Album { Id = 6, Title = "Pedals", Bands = new List<Band> { RivalSchools } },
                    new Album { Id = 7, Title = "Found", Bands = new List<Band> { RivalSchools } },
                });

                context.AddRange(albums);
                context.SaveChanges();
            }

            void AddMusicians(DataContext context)
            {
                if (context.Musicians.Any())
                {
                    return;
                }

                var musicians = new List<Musician>();

                //No Knife
                Album drunkOnTheMoon = context.Albums.First(a => a.Title == "Drunk on the Moon" && a.Bands.Any(b => b.Id == NoKnife.Id));
                Album hitManDreams = context.Albums.First(a => a.Title == "Hit Man Dreams" && a.Bands.Any(b => b.Id == NoKnife.Id));
                Album fireInTheCity = context.Albums.First(a => a.Title == "Fire in the City of Automatons" && a.Bands.Any(b => b.Id == NoKnife.Id));
                Album riotForRomance = context.Albums.First(a => a.Title == "Riot for Romance" && a.Bands.Any(b => b.Id == NoKnife.Id));

                musicians.AddRange(new List<Musician>
                {
                    new Musician{ Id = 1, FirstName = "Mitch", LastName = "Wilson", Instruments = "Guitar, vocals", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { drunkOnTheMoon, hitManDreams, fireInTheCity, riotForRomance } },
                    new Musician{ Id = 2, FirstName = "Brian", LastName = "Desjean", Instruments = "Bass", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { drunkOnTheMoon, hitManDreams, fireInTheCity, riotForRomance } },
                    new Musician{ Id = 3, FirstName = "Ryan", LastName = "Ferguson", Instruments = "Guitar, vocals", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { hitManDreams, fireInTheCity, riotForRomance } },
                    new Musician{ Id = 4, FirstName = "Chris", LastName = "Prescott", Instruments = "Drums", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { fireInTheCity, riotForRomance } },
                    new Musician{ Id = 5, FirstName = "Ike", LastName = "Zaremba", Instruments = "Drums", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { drunkOnTheMoon, hitManDreams } },
                    new Musician{ Id = 6, FirstName = "Aaron", LastName = "Mancini", Instruments = "Guitar, vocals", Bands = new List<Band> { NoKnife }, Albums = new List<Album> { drunkOnTheMoon } },
                });

                //Rival Schools
                Album unitedByFate = context.Albums.First(a => a.Title == "United by Fate" && a.Bands.Any(b => b.Id == RivalSchools.Id));
                Album pedals = context.Albums.First(a => a.Title == "Pedals" && a.Bands.Any(b => b.Id == RivalSchools.Id));
                Album found = context.Albums.First(a => a.Title == "Found" && a.Bands.Any(b => b.Id == RivalSchools.Id));

                musicians.AddRange(new List<Musician>
                {
                    new Musician{ Id = 7, FirstName = "Walter", LastName = "Schreifels", Bands = new List<Band> { RivalSchools }, Albums = new List<Album> { unitedByFate, pedals, found } },
                    new Musician{ Id = 8, FirstName = "Cache", LastName = "Tolman", Bands = new List<Band> { RivalSchools }, Albums = new List<Album> { unitedByFate, pedals, found } },
                    new Musician{ Id = 9, FirstName = "Sam", LastName = "Siegler", Bands = new List<Band> { RivalSchools }, Albums = new List<Album> { unitedByFate, pedals, found } },
                    new Musician{ Id = 10, FirstName = "Ian", LastName = "Love", Bands = new List<Band> { RivalSchools }, Albums = new List<Album> { unitedByFate, pedals, found } },
                    new Musician{ Id = 11, FirstName = "Chris", LastName = "Traynor", Bands = new List<Band> { RivalSchools } }
                });

                context.AddRange(musicians);
                context.SaveChanges();
            }

            void AddSongs(DataContext context)
            {
                if (context.Songs.Any())
                {
                    return;
                }

                AddNoKnifeSongs(context);
                AddRivalSchoolsSongs(context);
            }

            void AddFeaturedArtists(DataContext context)
            {
                var featuredArtists = new List<FeaturedArtist>();

                featuredArtists.AddRange(new List<FeaturedArtist>
                {
                    new FeaturedArtist {
                        BandId = 1,//No Knife
                        AlbumId = 3, //Fire in the City
                        Description = "This is the featured artist description for No Knife's Fire in the City of Automatons.",
                        StartDate = new DateTime(2023, 9, 30),
                        ImgSrc = "assets/no-knife-fire.jpg",
                    },

                    new FeaturedArtist {
                        BandId = 2, //Rival Schools
                        AlbumId = 5, //United by Fate
                        Description = "This is the featured artist description for Rival Schools's United by Fate.",
                        StartDate = new DateTime(2023, 9, 30),
                        ImgSrc = "assets/rival-schools-united.jpg",
                    },

                    new FeaturedArtist {
                        BandId = 1, //No Knife
                        AlbumId = 5, //Riot for Romance
                        Description = "This is the featured artist description for No Knife's Riot for Romance.",
                        StartDate = new DateTime(2023, 9, 30),
                        ImgSrc = "assets/no-knife-riot.jpg",
                    }

                });

                context.FeaturedArtists.AddRange(featuredArtists);
                context.SaveChanges();

            }

            //Prototype function for adding Songs which belong only to 1 album without features where all musicians contribute all of their instruments.
            void AddSimpleSongList(DataContext context, Band band, Album album, IEnumerable<(string title, string length)> songInfo)
            {
                var musiciansOnAlbum = context.Musicians.Where(m => m.Albums.Any(a => a.Id == album.Id) && m.Bands.Any(b => b.Id == band.Id)).ToList();

                var currentSongId = context.Songs.Any() ? context.Songs.Max(s => s.Id) + 1 : 1;
                var currentAlbumSongJoinId = context.AlbumSongs.Any() ? context.AlbumSongs.Max(s => s.Id) + 1 : 1;
                var currentMusicianSongJoinId = context.MusicianSongs.Any() ? context.MusicianSongs.Max(s => s.Id) + 1 : 1;

                var allSongs = new List<Song>();

                var allAlbumSongJoins = new List<AlbumSongs>();
                var allMusicianSongJoins = new List<MusicianSongs>();

                foreach (var song in songInfo)
                {
                    allSongs.Add(new Song { Id = currentSongId, Title = song.title, Bands = new List<Band> { band } });
                    //Add additional per-album info about song in join table
                    allAlbumSongJoins.Add(new AlbumSongs { Id = currentAlbumSongJoinId, SongId = currentSongId, Album = album, Length = ConvertToSeconds(song.length) });

                    foreach (var musician in musiciansOnAlbum) {
                        allMusicianSongJoins.Add(new MusicianSongs { Id = currentMusicianSongJoinId, MusicianId = musician.Id, SongId = currentSongId, Instruments = musician.Instruments });

                        currentMusicianSongJoinId++;
                    }

                    currentSongId++;
                    currentAlbumSongJoinId++;

                }

                context.AddRange(allSongs);
                context.AddRange(allMusicianSongJoins);
                context.AddRange(allAlbumSongJoins);
                context.SaveChanges();
            }

            int ConvertToSeconds(string time)
            {
                try
                {
                    return Convert.ToInt32(TimeSpan.ParseExact(time, @"mm\:ss", CultureInfo.InvariantCulture).TotalSeconds);
                }
                catch
                {
                    Console.WriteLine($"An error occurred attempting to parse time: \"{time}\"");
                    throw;
                }
            }

            /*
             * "Take the following list of songs, add quotations around the song title, replace the "-" with ",", add quotations around the times, format the times as mm:ss, wrap the entirety of each line in parentheses, then add a comma at the end of the line."
             * 
             *  -ChatGPT prompt for formatting a track listing section (Wikipedia, RYM, etc.) into the below tuple list.
             */

            void AddNoKnifeSongs(DataContext context) 
            {
                var drunkOnTheMoon = NoKnife.Albums.First(a => a.Title == "Drunk on the Moon");
                var drunkOnTheMoonSongs = new (string title, string length)[]
                {
                    ("Be Mini", "04:05"),
                    ("Ginger Vitus", "04:30"),
                    ("Habits", "04:46"),
                    ("Punch 'n' Judy", "05:07"),
                    ("At the Heart of the Terminal", "04:31"),
                    ("Kiss Your Killer", "03:38"),
                    ("Ephedrine", "05:18"),
                    ("Small of My Back", "05:29"),
                    ("...If I Could Float...", "03:10"),
                    ("Titanic", "01:02"),
                    ("Daniels", "01:48")
                };

                AddSimpleSongList(context, NoKnife, drunkOnTheMoon, drunkOnTheMoonSongs);

                var hitManDreams = NoKnife.Albums.First(a => a.Title == "Hit Man Dreams");
                var hitManDreamsSongs = new (string title, string length)[]
                {
                    ("Your Albatross", "04:13"),
                    ("Charades", "03:50"),
                    ("Hit Man Dreams", "05:17"),
                    ("Jackboots", "03:34"),
                    ("Testing the Model", "02:03"),
                    ("Median", "02:45"),
                    ("Rebuilding Jericho", "04:09"),
                    ("Bad Landing", "06:44"),
                    ("Roped In – Lock On", "03:31"),
                    ("Lex Hit Reset", "04:06"),
                    ("Sweep Away My Shadow", "03:59"),
                };

                AddSimpleSongList(context, NoKnife, hitManDreams, hitManDreamsSongs);

                var fireInTheCity = NoKnife.Albums.First(a => a.Title == "Fire in the City of Automatons");
                var fireInTheCitySongs = new (string title, string length)[]
                {
                    ("Academy Fight Song", "03:18"),
                    ("Minus One", "04:19"),
                    ("Secret Handshake", "03:31"),
                    ("Heavy Weather", "04:21"),
                    ("K-241", "00:54"),
                    ("The Spy", "06:37"),
                    ("Charming", "04:20"),
                    ("Angel Bomb", "04:36"),
                    ("Short Term Memory", "02:10"),
                    ("Under The Moon", "02:28"),
                    ("Mission Control", "05:17"),
                    ("If It Moves Kiss It", "04:51")
                };

                AddSimpleSongList(context, NoKnife, fireInTheCity, fireInTheCitySongs);

                var riotForRomance = NoKnife.Albums.First(a => a.Title == "Riot for Romance");
                var riotForRomanceSongs = new (string title, string length)[]
                {
                    ("Riot For Romance!", "03:35"),
                    ("Permanent For Now", "03:44"),
                    ("Swinging Lovers", "03:14"),
                    ("Parting Shot", "04:50"),
                    ("Feathers And Furs", "07:46"),
                    ("The Red Bedroom", "04:25"),
                    ("Brush Off", "02:38"),
                    ("May I Call You Doll?", "04:19"),
                    ("Flechette", "02:54"),
                    ("This Moonlife", "05:56")
                };

                AddSimpleSongList(context, NoKnife, riotForRomance, riotForRomanceSongs);

            }

            void AddRivalSchoolsSongs(DataContext context) 
            {
                return;
            }
        }
    }
}
