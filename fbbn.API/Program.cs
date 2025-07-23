using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon;
using Amazon.S3;
using fbbn.API.Services;
using fbbn.API.Repositories;
using Amazon.DynamoDBv2.DataModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IImovelService, ImovelService>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IS3Service, S3Service>();

// AWS
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddAWSService<IAmazonDynamoDB>(); 
builder.Services.AddScoped<DynamoDBContext>();
builder.Services.AddDefaultAWSOptions(new AWSOptions
{
    Region = RegionEndpoint.SAEast1,
    Credentials = new BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    )
}
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPublic",
        policy => policy.WithOrigins("https://fbbnimoveis.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader());

    options.AddPolicy("AllowAdmin",
        policy => policy.WithOrigins("https://admin.fbbnimoveis.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "fbbn API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseCors("AllowPublic");
app.UseCors("AllowAdmin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
