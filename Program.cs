using quandomeutimejoga_server.Data;
using quandomeutimejoga_server.Models;
using quandomeutimejoga_server.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/v1/teams", (AppDbContext context) =>
{
    var teams = context.Teams;
    return teams is not null ? Results.Ok(teams) : Results.NotFound();
}).Produces<Team>();

app.MapPost("/v1/teams", (AppDbContext context, CreateTeamViewModel model) =>
{
    var team = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.Teams.Add(team);
    context.SaveChanges();

    return Results.Created($"/v1/teams/{team.Id}", team);
});

app.UseHttpsRedirection();

app.Run();