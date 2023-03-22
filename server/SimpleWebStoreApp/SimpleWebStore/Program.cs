using Microsoft.AspNetCore.Mvc;

using SimpleWebStore.DTOs.customerCart;
using SimpleWebStore.DTOs.product;
using SimpleWebStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.WithOrigins("http://localhost:7282")
            .AllowAnyOrigin();
            //.AllowCredentials();
        });
});

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

// apply cors policy
app.UseCors("CORSPolicy");


app.MapGet("/products", async () =>
{
    var products = await ProductRepository.GetProductsAsync();
    if (products is null)
    {
        return Results.BadRequest();
    }

    //var testRating = products.Select(p => p.Ratings)

    var productDtos = products.Select(p => new ProductDto
    {
        Id = p.Id,
        Name = p.Name,
        Description = p.Description,
        ImageSrc = p.ImageSrc,
        Quantity = p.Quantity,
        Price = p.Price,
        Ratings = p.AverageRatings
    }).ToList();

    return productDtos is not null ? Results.Ok(productDtos)
                            : Results.BadRequest();

}).WithTags("Products Endpoint");


app.MapPost("/product/purchases", async ([FromBody] CartDto customerCart) =>
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


app.MapPost("/products/{productId:int}/ratings", async ([FromRoute] int productId, [FromBody] RatingDto rating) =>
{
    var result = await ProductRepository.AddRating(productId, rating);

    return result ? Results.Ok() : Results.BadRequest();
}).WithTags("Ratings Endpoing");


app.MapPost("/products/{productId:int}", async ([FromRoute] int productId) =>
{
    var product = await ProductRepository.GetProductByIdAsync(productId);
    return Results.Ok(product);


}).WithTags("Ratings Endpoing");


// start bootstraping
app.Run();
