using GamesStoreApp.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(
        1,
        "X-Com 1",
        "Strategy",
        21.12M,
        new DateOnly(1995,10,11)
    ),
    new (
        2,
        "X-Com 2",
        "Strategy",
        25.99M,
        new DateOnly(1998,01,21)
    ),
    new(
        3,
        "GTA 3",
        "Roleplay",
        35.99M,
        new DateOnly(2000,05,01)
    ), 
    new(
        4,
        "Pinze Panze",
        "Alma y daddy being silly",
        100000.55M,
        new DateOnly(2024,09,13)
    )
];

app.MapGet("games", () => games);

app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

app.MapPost("games", (CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
});

app.Run();
