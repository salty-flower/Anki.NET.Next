using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Api;
using Anki.NET.Next.Connect.Json;
using Anki.NET.Next.Connect.Models.Actions.Cards;
using Anki.NET.Next.Connect.Models.Actions.Decks;
using Anki.NET.Next.Connect.Models.Actions.Models;
using Anki.NET.Next.Connect.Models.Actions.Notes;
using Anki.NET.Next.Connect.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.NET.Core.Models.Protocol.Client.Responses;
using ModelContextProtocol.NET.Core.Models.Protocol.Common;
using ModelContextProtocol.NET.Core.Models.Protocol.Shared.Content;
using ModelContextProtocol.NET.Server.Features.Tools;
using ModelContextProtocol.NET.Server.Hosting;
using Refit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMcpServer(
    new Implementation { Name = "AnkiConnectMCP", Version = "0.0.1" },
    mcpBuilder =>
    {
        mcpBuilder.AddStdioTransport();
        mcpBuilder
            .Services.AddRefitClient<IAnkiConnectApi>(
                new RefitSettings
                {
                    ContentSerializer = new SystemTextJsonContentSerializer(
                        AnkiJsonContext.Default.Options
                    ),
                }
            )
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:18765"));

        // notes - basic operations
        mcpBuilder.Tools.AddHandler<GenericHandler<FindNotesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<NotesInfoParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<AddNoteParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<AddNotesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<DeleteNotesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<CanAddNotesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<NotesModTimeParams>>();

        // notes - modification
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateNoteFieldsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateNoteParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateNoteModelParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<RemoveEmptyNotesParams>>();

        // notes - tags
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateNoteTagsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<GetNoteTagsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<AddTagsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<RemoveTagsParams>>();

        // cards - information
        mcpBuilder.Tools.AddHandler<GenericHandler<CardsInfoParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<CardsModTimeParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<CardsToNotesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<FindCardsParams>>();

        // cards - suspension
        mcpBuilder.Tools.AddHandler<GenericHandler<SuspendCardsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<UnsuspendCardsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<SuspendedParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<AreSuspendedParams>>();

        // cards - scheduling
        mcpBuilder.Tools.AddHandler<GenericHandler<AreDueParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<GetEaseFactorsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<SetEaseFactorsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<SetSpecificValueOfCardParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<GetIntervalsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ForgetCardsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<RelearnCardsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<AnswerCardsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<SetDueDateParams>>();

        // decks - basic operations
        mcpBuilder.Tools.AddHandler<GenericHandler<DeckNamesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<DeckNamesAndIdsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<DeckStatsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<DeckConfigParams>>();

        // models - basic operations
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelNamesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelNamesAndIdsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<FindModelsByIdParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<FindModelsByNameParams>>();

        // models - field operations
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldNamesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldDescriptionsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldFontsParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldsOnTemplatesParams>>();

        // models - template operations
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelTemplatesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelStylingParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<CreateModelParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateModelTemplatesParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<UpdateModelStylingParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<FindAndReplaceInModelsParams>>();

        // models - template management
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelTemplateRenameParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelTemplateRepositionParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelTemplateAddParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelTemplateRemoveParams>>();

        // models - field management
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldRenameParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldRepositionParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldAddParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldRemoveParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldSetFontParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldSetFontSizeParams>>();
        mcpBuilder.Tools.AddHandler<GenericHandler<ModelFieldSetDescriptionParams>>();
    }
);

var app = builder.Build();
await app.RunAsync();

class GenericHandler<TParams>(IAnkiConnectApi api) : ToolHandlerBase<TParams>(tool)
    where TParams : AnkiRequestParamsBase
{
    static GenericHandler()
    {
        var paramClassName = typeof(TParams).FullName!.Split('.').Last().Replace("Params", "");
        try
        {
            var typeInfo =
                (JsonTypeInfo<TParams>)(
                    AnkiJsonContext.Default.GetTypeInfo(typeof(TParams))
                    ?? throw new ArgumentNullException(typeof(TParams).FullName)
                );

            tool = new()
            {
                Name = paramClassName,
                Description = paramClassName,
                InputSchema = (typeInfo).GetToolSchema()!,
            };
        }
        catch (Exception ex)
        {
            throw ex.InnerException!;
        }
    }

    private static readonly Tool tool;
    public override JsonTypeInfo JsonTypeInfo =>
        ((JsonTypeInfo<TParams>)AnkiJsonContext.Default.GetTypeInfo(typeof(TParams))!);

    protected override async Task<CallToolResult> HandleAsync(
        TParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        var res = await api.GenericAsync(parameters);
        return new CallToolResult
        {
            IsError = res?.Error != null,
            Content = (TextContent)(
                res?.Error
                ?? JsonSerializer.Serialize(res?.Result, AnkiJsonContext.Default.JsonElement)
            ),
        };
    }
}
