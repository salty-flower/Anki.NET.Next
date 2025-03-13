using System.Collections.Generic;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record UpdateModelTemplatesParams : AnkiRequestParamsBase
{
    public required UpdateModelTemplatesModel Model { get; init; }
}
