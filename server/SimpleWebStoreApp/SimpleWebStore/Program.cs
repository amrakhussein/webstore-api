using Microsoft.AspNetCore.Mvc;

using SimpleWebStore.DTOs;
using SimpleWebStore.Repositories;

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


app.MapGet("/products", async () =>
{
    var products = await ProductRepository.GetProductsAsync();

    return products != null ? Results.Ok(products)
                            : Results.BadRequest();

}).WithTags("Products Endpoint");



app.MapPost("/purchase", async ([FromBody] CartDto customerCart) =>
{
    var purchasedItems = await CartRepository.PurchaseOrderAsync(customerCart);


    return purchasedItems != null ? Results.Ok(purchasedItems)
                                  : Results.BadRequest();
}).WithTags("Purchase Endpoint");


// start bootstraping
app.Run();