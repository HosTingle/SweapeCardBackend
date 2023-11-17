using Microsoft.Extensions.DependencyInjection;
using RealEstate_Dapper.Models.DapperContext;
using RealEstate_Dapper.Respositories.UserRepository;
using SweapCard.ChatGpt;
using SweapCard.Respositories.AvatarRepository;
using SweapCard.Respositories.LanguageRepository;
using SweapCard.Respositories.LearnWordRepository;
using SweapCard.Respositories.ScoreRepository;
using SweapCard.Respositories.WordCounterRepository;
using SweapCard.Respositories.WordRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ChatGptWords>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IWordRepository, WordRepository>();
builder.Services.AddTransient<IWordCounterRepository, WordCounterRepository>();
builder.Services.AddTransient<ILearnWordRepository,LearnWordRepository>();
builder.Services.AddTransient<ILanguageRepository, LanguageRepository>();
builder.Services.AddTransient<IAvatarRepository, AvatarRepository>();
builder.Services.AddTransient<IScoreRepository, ScoreRepository>();
builder.Services.AddControllers();
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
app.UseCors(builder => builder.WithOrigins("http://localhost:40630").AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
