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

    return products is not null ? Results.Ok(products)
                            : Results.BadRequest();

}).WithTags("Products Endpoint");



app.MapPost("/purchase", async ([FromBody] CartDto customerCart) =>
{
    if (customerCart is null)
    {
        return Results.BadRequest("Invalid request..");
    }

    var purchasedItems = await CartRepository.PurchaseOrderAsync(customerCart);


    return purchasedItems.success
        ? Results.Ok(new PurchasedItemResponseDto
        {
            Success = true,
            Message = purchasedItems.message
        })
        : Results.BadRequest(new PurchasedItemResponseDto
        {
            Success = false,
            Message = purchasedItems.message,
        });
}).WithTags("Purchase Endpoint");


// start bootstraping
app.Run();
