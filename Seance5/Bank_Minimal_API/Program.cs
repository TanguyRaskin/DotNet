var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();


app.MapGet("/tvaProduct/{price}/{country}", (double price, string country) => 
{
    var prix = price;
    var pays = country;
    var tva = 0.2;
    var calcule = 0.0;

    if (country == "BE")
        tva = 0.21;

    return calcule = prix + (prix * tva);

})
.WithName("TvaProduct");

app.Run();
