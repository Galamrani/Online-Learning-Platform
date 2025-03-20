using System.Text.Json.Serialization;

namespace OnlineLearning.API;

public static class JsonExtensions
{
    public static void AddJsonConfiguration(this IMvcBuilder builder)
    {
        builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
    }
}
