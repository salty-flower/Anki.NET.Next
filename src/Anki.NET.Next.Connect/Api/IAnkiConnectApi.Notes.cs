using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Notes;
using Anki.NET.Next.Connect.Models.Common;
using Refit;

namespace Anki.NET.Next.Connect.Api;

public partial interface IAnkiConnectApi
{
    // Note creation
    [Post("/")]
    Task<AnkiResponse<long>> AddNoteAsync(
        [Body] AnkiRequest<AddNoteParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<long[]>> AddNotesAsync(
        [Body] AnkiRequest<AddNotesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool[]>> CanAddNotesAsync(
        [Body] AnkiRequest<CanAddNotesParams> request,
        CancellationToken ct = default
    );

    // Note querying
    [Post("/")]
    Task<AnkiResponse<long[]>> FindNotesAsync(
        [Body] AnkiRequest<FindNotesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<NoteInfo[]>> NotesInfoAsync(
        [Body] AnkiRequest<NotesInfoParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<NoteModTime[]>> NotesModTimeAsync(
        [Body] AnkiRequest<NotesModTimeParams> request,
        CancellationToken ct = default
    );

    // Note modification
    [Post("/")]
    Task<AnkiResponse<object?>> UpdateNoteFieldsAsync(
        [Body] AnkiRequest<UpdateNoteFieldsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> UpdateNoteAsync(
        [Body] AnkiRequest<UpdateNoteParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> UpdateNoteModelAsync(
        [Body] AnkiRequest<UpdateNoteModelParams> request,
        CancellationToken ct = default
    );

    // Note deletion
    [Post("/")]
    Task<AnkiResponse<object?>> DeleteNotesAsync(
        [Body] AnkiRequest<DeleteNotesParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> RemoveEmptyNotesAsync(
        [Body] AnkiRequest<RemoveEmptyNotesParams> request,
        CancellationToken ct = default
    );

    // Tag operations
    [Post("/")]
    Task<AnkiResponse<object?>> UpdateNoteTagsAsync(
        [Body] AnkiRequest<UpdateNoteTagsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<string[]>> GetNoteTagsAsync(
        [Body] AnkiRequest<GetNoteTagsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> AddTagsAsync(
        [Body] AnkiRequest<AddTagsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> RemoveTagsAsync(
        [Body] AnkiRequest<RemoveTagsParams> request,
        CancellationToken ct = default
    );
}
