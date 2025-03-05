using WebApplication1.Models.Abstractions;
using WebApplication1.Models.Implementations;
using WebApplication1.Serializers.Abstractions;
using WebApplication1.Serializers.Implementations;
using WebApplication1.Services.Abstraction;
using WebApplication1.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOutputService, PlainTextOutputService>();
builder.Services.AddTransient<IOutputService, JsonOutputService>();

builder.Services.AddSingleton<IShapeSerializer, JsonShapeSerializer>();
builder.Services.AddSingleton<IShapeSerializer, TxtShapeSerializer>();

builder.Services.AddSingleton<IShapeService, ShapeService>();

var app = builder.Build();

app.MapGet("/display", (HttpContext context, IEnumerable<IOutputService> outputServices) =>
{
    string outputMode = context.Request.Query["output"].ToString().ToLower();
    if (string.IsNullOrEmpty(outputMode))
        outputMode = "plain";

    var outputService = outputServices.FirstOrDefault(s => s.OutputMode == outputMode);
    if (outputService == null)
        return Results.BadRequest($"Output mode '{outputMode}' not found.");

    var shapes = new List<Shape>
    {
        new Circle(5),
        new Square(4),
        new Triangle(6, 7)
    };

    foreach (var shape in shapes)
    {
        outputService.AppendLine($"Name: {shape.Name}");
        outputService.AppendLine($"Drawing: {shape.Draw()}");
    }

    var output = outputService.GetOutput();
    if (outputMode == "plain")
        return Results.Text(output, "text/plain");
    else if (outputMode == "json")
        return Results.Content(output, "application/json");
    else
        return Results.Ok(output);
});

// /save?format=json
app.MapGet("/save", (string format, IShapeService shapeService) =>
{
    var shapes = new List<Shape>
    {
        new Circle(3),
        new Square(2),
        new Triangle(4, 5)
    };

    string folder = "Data";
    if (!Directory.Exists(folder))
        Directory.CreateDirectory(folder);
    string filePath = Path.Combine(folder, $"shapes.{format.ToLower()}");

    try
    {
        shapeService.SaveShapes(shapes, filePath, format);
        return Results.Ok($"Shapes saved to {filePath}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error: {ex.Message}");
    }
});

// /load?format=json
app.MapGet("/load", (string format, IShapeService shapeService) =>
{
    string folder = "Data";
    string filePath = Path.Combine(folder, $"shapes.{format.ToLower()}");
    try
    {
        var shapes = shapeService.LoadShapes(filePath, format);
        return Results.Json(shapes);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error: {ex.Message}");
    }
});


// /download?format=json
app.MapGet("/download", (string format) =>
{
    string folder = "Data";
    string fileName = $"shapes.{format.ToLower()}";
    string filePath = Path.Combine(folder, fileName);
    if (File.Exists(filePath))
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        string contentType = format.Equals("json", StringComparison.OrdinalIgnoreCase)
            ? "application/json" : "text/plain";
        return Results.File(fileBytes, contentType, fileName);
    }
    else
    {
        return Results.NotFound($"File '{fileName}' not found.");
    }
});

app.Run();
