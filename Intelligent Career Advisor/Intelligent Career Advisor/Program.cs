
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
//}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
