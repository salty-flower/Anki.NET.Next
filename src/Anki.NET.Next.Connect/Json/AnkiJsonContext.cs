using System.Collections.Generic;
using System.Text.Json.Serialization;
using Anki.NET.Next.Connect.Models.Actions.Cards;
using Anki.NET.Next.Connect.Models.Actions.Decks;
using Anki.NET.Next.Connect.Models.Actions.Models;
using Anki.NET.Next.Connect.Models.Actions.Notes;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Json;

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
)]
[JsonSerializable(typeof(AnkiRequest<AddNoteParams>))]
[JsonSerializable(typeof(AnkiRequest<AddNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<FindNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<NotesInfoParams>))]
[JsonSerializable(typeof(AnkiRequest<DeleteNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<CardsInfoParams>))]
[JsonSerializable(typeof(AnkiRequest<SuspendCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<UnsuspendCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<FindCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelNamesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldsParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplatesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelStylingParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckNamesParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckNamesAndIdsParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckStatsParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckConfigParams>))]
[JsonSerializable(typeof(AnkiResponse<long>))]
[JsonSerializable(typeof(AnkiResponse<long[]>))]
[JsonSerializable(typeof(AnkiResponse<string>))]
[JsonSerializable(typeof(AnkiResponse<string[]>))]
[JsonSerializable(typeof(AnkiResponse<NoteInfo[]>))]
[JsonSerializable(typeof(AnkiResponse<CardInfo[]>))]
[JsonSerializable(typeof(AnkiResponse<object>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, DeckStats>>))]
[JsonSerializable(typeof(AnkiResponse<DeckNameId[]>))]
[JsonSerializable(typeof(NoteInfo))]
[JsonSerializable(typeof(CardInfo))]
[JsonSerializable(typeof(DeckStats))]
[JsonSerializable(typeof(DeckNameId))]
public partial class AnkiJsonContext : JsonSerializerContext { }
