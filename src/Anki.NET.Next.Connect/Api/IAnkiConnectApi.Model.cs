using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Models;
using Anki.NET.Next.Connect.Models.Common;
using Refit;

namespace Anki.NET.Next.Connect.Api;

public partial interface IAnkiConnectApi
{
    // Basic model operations
    [Post("/")]
    Task<AnkiResponse<string[]>> ModelNamesAsync(
        [Body] AnkiRequest<ModelNamesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<Dictionary<string, long>>> ModelNamesAndIdsAsync(
        [Body] AnkiRequest<ModelNamesAndIdsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object[]>> FindModelsByIdAsync(
        [Body] AnkiRequest<FindModelsByIdParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object[]>> FindModelsByNameAsync(
        [Body] AnkiRequest<FindModelsByNameParams> request,
        CancellationToken ct = default
    );

    // Model field operations
    [Post("/")]
    Task<AnkiResponse<string[]>> ModelFieldNamesAsync(
        [Body] AnkiRequest<ModelFieldNamesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<string[]>> ModelFieldDescriptionsAsync(
        [Body] AnkiRequest<ModelFieldDescriptionsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<Dictionary<string, ModelFieldFont>>> ModelFieldFontsAsync(
        [Body] AnkiRequest<ModelFieldFontsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<Dictionary<string, string[][]>>> ModelFieldsOnTemplatesAsync(
        [Body] AnkiRequest<ModelFieldsOnTemplatesParams> request,
        CancellationToken ct = default
    );

    // Model template operations
    [Post("/")]
    Task<AnkiResponse<Dictionary<string, ModelTemplate>>> ModelTemplatesAsync(
        [Body] AnkiRequest<ModelTemplatesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<ModelStyling>> ModelStylingAsync(
        [Body] AnkiRequest<ModelStylingParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> CreateModelAsync(
        [Body] AnkiRequest<CreateModelParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> UpdateModelTemplatesAsync(
        [Body] AnkiRequest<UpdateModelTemplatesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> UpdateModelStylingAsync(
        [Body] AnkiRequest<UpdateModelStylingParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<int>> FindAndReplaceInModelsAsync(
        [Body] AnkiRequest<FindAndReplaceInModelsParams> request,
        CancellationToken ct = default
    );

    // Model template management
    [Post("/")]
    Task<AnkiResponse<object>> ModelTemplateRenameAsync(
        [Body] AnkiRequest<ModelTemplateRenameParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelTemplateRepositionAsync(
        [Body] AnkiRequest<ModelTemplateRepositionParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelTemplateAddAsync(
        [Body] AnkiRequest<ModelTemplateAddParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelTemplateRemoveAsync(
        [Body] AnkiRequest<ModelTemplateRemoveParams> request,
        CancellationToken ct = default
    );

    // Model field management
    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldRenameAsync(
        [Body] AnkiRequest<ModelFieldRenameParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldRepositionAsync(
        [Body] AnkiRequest<ModelFieldRepositionParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldAddAsync(
        [Body] AnkiRequest<ModelFieldAddParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldRemoveAsync(
        [Body] AnkiRequest<ModelFieldRemoveParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldSetFontAsync(
        [Body] AnkiRequest<ModelFieldSetFontParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object>> ModelFieldSetFontSizeAsync(
        [Body] AnkiRequest<ModelFieldSetFontSizeParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool>> ModelFieldSetDescriptionAsync(
        [Body] AnkiRequest<ModelFieldSetDescriptionParams> request,
        CancellationToken ct = default
    );
}
