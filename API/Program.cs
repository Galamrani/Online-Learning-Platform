using OnlineLearning.API;

var builder = WebApplication.CreateBuilder(args);

// Load configuration settings (e.g., JWT, Database)
builder.Services.AddApplicationConfigurations(builder.Configuration);

// Configure Serilog for logging
builder.AddSerilogLogging();

// Enable CORS policy for development
builder.Services.AddCorsPolicy();

// Configure FluentValidation for request validation
builder.Services.AddFluentValidationServices();

// Register application services (e.g., UserService, CourseService)
builder.Services.AddApplicationServices();

// Configure AutoMapper for DTO and entity mapping
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add MVC filters (CatchAllFilter for handling exceptions)
builder.Services.AddMvc(options => options.Filters.Add<CatchAllFilter>());

// Configure JWT authentication & authorization
builder.Services.AddJwtAuthentication(builder.Configuration);

// Configure JSON serialization settings on the controllers
builder.Services.AddControllers().AddJsonConfiguration();

var app = builder.Build();

app.UseCors("DevelopmentCorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();


app.Run();

