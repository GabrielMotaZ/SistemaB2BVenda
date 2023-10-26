

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaVendas.Configurations;

internal sealed class ConversorDeDatasJson : JsonConverter<DateTime>
{
    private readonly string _formato;

    public ConversorDeDatasJson(string formato)
    {
        _formato = formato;
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DateTime.Parse(reader.GetString() ?? string.Empty);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(_formato));
}
