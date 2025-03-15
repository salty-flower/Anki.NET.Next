using System.Collections.Generic;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record UpdateModelTemplatesModel
{
    public required string Name { get; init; }
    public required Dictionary<string, ModelTemplate> Templates { get; init; }
}
