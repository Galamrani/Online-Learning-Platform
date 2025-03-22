using System.Text.Json.Serialization;

namespace OnlineLearning.API;

public static class JsonExtensions
{
    public static void AddJsonConfiguration(this IMvcBuilder builder)
    {
        // Configure JSON serialization options to handle circular references and null values.
        // - ReferenceHandler.IgnoreCycles: Prevents infinite loops during serialization caused by circular object references.
        // - JsonIgnoreCondition.WhenWritingNull: Excludes properties with null values from the JSON output for cleaner and smaller responses.

        builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
    }
}
