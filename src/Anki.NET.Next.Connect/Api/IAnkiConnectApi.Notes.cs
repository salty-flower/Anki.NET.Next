using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Notes;
using Anki.NET.Next.Connect.Models.Common;
using HttpClientFillerAttribute;

namespace Anki.NET.Next.Connect.Services;

public partial interface IAnkiConnectApi
{
    [Post(" ")]
    Task<AnkiResponse<long>> AddNoteAsync(
        [Body] AnkiRequest<AddNoteParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<long[]>> AddNotesAsync(
        [Body] AnkiRequest<AddNotesParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<long[]>> FindNotesAsync(
        [Body] AnkiRequest<FindNotesParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<NoteInfo[]>> NotesInfoAsync(
        [Body] AnkiRequest<NotesInfoParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<object?>> DeleteNotesAsync(
        [Body] AnkiRequest<DeleteNotesParams> request,
        CancellationToken ct = default
    );
}
