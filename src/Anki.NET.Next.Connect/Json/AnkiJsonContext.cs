using System.Collections.Generic;
using System.Text.Json;
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
// Note operations
[JsonSerializable(typeof(AnkiRequest<AddNoteParams>))]
[JsonSerializable(typeof(AnkiRequest<AddNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<NotesInfoParams>))]
[JsonSerializable(typeof(AnkiRequest<FindNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<CanAddNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<NotesModTimeParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateNoteFieldsParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateNoteParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateNoteModelParams>))]
[JsonSerializable(typeof(AnkiRequest<RemoveEmptyNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateNoteTagsParams>))]
[JsonSerializable(typeof(AnkiRequest<GetNoteTagsParams>))]
[JsonSerializable(typeof(AnkiRequest<AddTagsParams>))]
[JsonSerializable(typeof(AnkiRequest<RemoveTagsParams>))]
[JsonSerializable(typeof(AnkiRequest<DeleteNotesParams>))]
[JsonSerializable(typeof(AddNoteParams))]
[JsonSerializable(typeof(AddNotesParams))]
[JsonSerializable(typeof(NotesInfoParams))]
[JsonSerializable(typeof(FindNotesParams))]
[JsonSerializable(typeof(CanAddNotesParams))]
[JsonSerializable(typeof(NotesModTimeParams))]
[JsonSerializable(typeof(UpdateNoteFieldsParams))]
[JsonSerializable(typeof(UpdateNoteParams))]
[JsonSerializable(typeof(UpdateNoteModelParams))]
[JsonSerializable(typeof(RemoveEmptyNotesParams))]
[JsonSerializable(typeof(UpdateNoteTagsParams))]
[JsonSerializable(typeof(GetNoteTagsParams))]
[JsonSerializable(typeof(AddTagsParams))]
[JsonSerializable(typeof(RemoveTagsParams))]
[JsonSerializable(typeof(DeleteNotesParams))]
// Card operations
[JsonSerializable(typeof(AnkiRequest<CardsInfoParams>))]
[JsonSerializable(typeof(AnkiRequest<CardsModTimeParams>))]
[JsonSerializable(typeof(AnkiRequest<CardsToNotesParams>))]
[JsonSerializable(typeof(AnkiRequest<FindCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<SuspendCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<UnsuspendCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<SuspendedParams>))]
[JsonSerializable(typeof(AnkiRequest<AreSuspendedParams>))]
[JsonSerializable(typeof(AnkiRequest<AreDueParams>))]
[JsonSerializable(typeof(AnkiRequest<GetEaseFactorsParams>))]
[JsonSerializable(typeof(AnkiRequest<SetEaseFactorsParams>))]
[JsonSerializable(typeof(AnkiRequest<SetSpecificValueOfCardParams>))]
[JsonSerializable(typeof(AnkiRequest<GetIntervalsParams>))]
[JsonSerializable(typeof(AnkiRequest<ForgetCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<RelearnCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<AnswerCardsParams>))]
[JsonSerializable(typeof(AnkiRequest<SetDueDateParams>))]
[JsonSerializable(typeof(CardsInfoParams))]
[JsonSerializable(typeof(CardsModTimeParams))]
[JsonSerializable(typeof(CardsToNotesParams))]
[JsonSerializable(typeof(FindCardsParams))]
[JsonSerializable(typeof(SuspendCardsParams))]
[JsonSerializable(typeof(UnsuspendCardsParams))]
[JsonSerializable(typeof(SuspendedParams))]
[JsonSerializable(typeof(AreSuspendedParams))]
[JsonSerializable(typeof(AreDueParams))]
[JsonSerializable(typeof(GetEaseFactorsParams))]
[JsonSerializable(typeof(SetEaseFactorsParams))]
[JsonSerializable(typeof(SetSpecificValueOfCardParams))]
[JsonSerializable(typeof(GetIntervalsParams))]
[JsonSerializable(typeof(ForgetCardsParams))]
[JsonSerializable(typeof(RelearnCardsParams))]
[JsonSerializable(typeof(AnswerCardsParams))]
[JsonSerializable(typeof(SetDueDateParams))]
// Deck operations
[JsonSerializable(typeof(AnkiRequest<DeckNamesParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckNamesAndIdsParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckStatsParams>))]
[JsonSerializable(typeof(AnkiRequest<DeckConfigParams>))]
[JsonSerializable(typeof(DeckNamesParams))]
[JsonSerializable(typeof(DeckNamesAndIdsParams))]
[JsonSerializable(typeof(DeckStatsParams))]
[JsonSerializable(typeof(DeckConfigParams))]
// Model operations
[JsonSerializable(typeof(AnkiRequest<ModelNamesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelNamesAndIdsParams>))]
[JsonSerializable(typeof(AnkiRequest<FindModelsByIdParams>))]
[JsonSerializable(typeof(AnkiRequest<FindModelsByNameParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldNamesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldDescriptionsParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldFontsParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldsOnTemplatesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplatesParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelStylingParams>))]
[JsonSerializable(typeof(AnkiRequest<CreateModelParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateModelTemplatesParams>))]
[JsonSerializable(typeof(AnkiRequest<UpdateModelStylingParams>))]
[JsonSerializable(typeof(AnkiRequest<FindAndReplaceInModelsParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplateRenameParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplateRepositionParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplateAddParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelTemplateRemoveParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldRenameParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldRepositionParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldAddParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldRemoveParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldSetFontParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldSetFontSizeParams>))]
[JsonSerializable(typeof(AnkiRequest<ModelFieldSetDescriptionParams>))]
[JsonSerializable(typeof(ModelNamesParams))]
[JsonSerializable(typeof(ModelNamesAndIdsParams))]
[JsonSerializable(typeof(FindModelsByIdParams))]
[JsonSerializable(typeof(FindModelsByNameParams))]
[JsonSerializable(typeof(ModelFieldNamesParams))]
[JsonSerializable(typeof(ModelFieldDescriptionsParams))]
[JsonSerializable(typeof(ModelFieldFontsParams))]
[JsonSerializable(typeof(ModelFieldsOnTemplatesParams))]
[JsonSerializable(typeof(ModelFieldsParams))]
[JsonSerializable(typeof(ModelTemplatesParams))]
[JsonSerializable(typeof(ModelStylingParams))]
[JsonSerializable(typeof(CreateModelParams))]
[JsonSerializable(typeof(UpdateModelTemplatesParams))]
[JsonSerializable(typeof(UpdateModelStylingParams))]
[JsonSerializable(typeof(FindAndReplaceInModelsParams))]
[JsonSerializable(typeof(ModelTemplateRenameParams))]
[JsonSerializable(typeof(ModelTemplateRepositionParams))]
[JsonSerializable(typeof(ModelTemplateAddParams))]
[JsonSerializable(typeof(ModelTemplateRemoveParams))]
[JsonSerializable(typeof(ModelFieldRenameParams))]
[JsonSerializable(typeof(ModelFieldRepositionParams))]
[JsonSerializable(typeof(ModelFieldAddParams))]
[JsonSerializable(typeof(ModelFieldRemoveParams))]
[JsonSerializable(typeof(ModelFieldSetFontParams))]
[JsonSerializable(typeof(ModelFieldSetFontSizeParams))]
[JsonSerializable(typeof(ModelFieldSetDescriptionParams))]
// Response types
[JsonSerializable(typeof(AnkiResponse<long>))]
[JsonSerializable(typeof(AnkiResponse<long[]>))]
[JsonSerializable(typeof(AnkiResponse<string>))]
[JsonSerializable(typeof(AnkiResponse<string[]>))]
[JsonSerializable(typeof(AnkiResponse<NoteInfo[]>))]
[JsonSerializable(typeof(AnkiResponse<CardInfo[]>))]
[JsonSerializable(typeof(AnkiResponse<CardModTime[]>))]
[JsonSerializable(typeof(AnkiResponse<bool>))]
[JsonSerializable(typeof(AnkiResponse<bool[]>))]
[JsonSerializable(typeof(AnkiResponse<bool?[]>))]
[JsonSerializable(typeof(AnkiResponse<int[]>))]
[JsonSerializable(typeof(AnkiResponse<object>))]
[JsonSerializable(typeof(AnkiResponse<object[]>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, long>>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, DeckStats>>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, ModelFieldFont>>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, string[][]>>))]
[JsonSerializable(typeof(AnkiResponse<Dictionary<string, ModelTemplate>>))]
[JsonSerializable(typeof(AnkiResponse<JsonElement>))]
[JsonSerializable(typeof(AnkiResponse<ModelStyling>))]
[JsonSerializable(typeof(AnkiResponse<DeckNameId[]>))]
// Model types
[JsonSerializable(typeof(NoteInfo))]
[JsonSerializable(typeof(CardInfo))]
[JsonSerializable(typeof(CardModTime))]
[JsonSerializable(typeof(CardAnswer))]
[JsonSerializable(typeof(DeckStats))]
[JsonSerializable(typeof(DeckNameId))]
[JsonSerializable(typeof(ModelFieldFont))]
[JsonSerializable(typeof(ModelTemplate))]
[JsonSerializable(typeof(ModelStyling))]
[JsonSerializable(typeof(CreateModelTemplate))]
[JsonSerializable(typeof(UpdateModelTemplatesModel))]
[JsonSerializable(typeof(UpdateModelStylingModel))]
[JsonSerializable(typeof(FindAndReplaceInModelsModel))]
[JsonSerializable(typeof(JsonElement))]
// Note types
[JsonSerializable(typeof(NoteData))]
[JsonSerializable(typeof(UpdateNoteData))]
[JsonSerializable(typeof(UpdateNoteWithTagsData))]
[JsonSerializable(typeof(UpdateNoteModelData))]
[JsonSerializable(typeof(NoteModTime))]
public partial class AnkiJsonContext : JsonSerializerContext { }
