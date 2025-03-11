using System.IO;
using System.Threading.Tasks;
using FluentAssertions;

namespace Anki.Net.Tests.Unit;

public class AnkiFileReaderTests
{
    [Fact]
    public async Task WhenRead_ThenNoExceptionIsThrown()
    {
        var action = async () => _ = await AnkiFileReader.ReadFromFileAsync("unknown");
        await action.Should().ThrowExactlyAsync<FileNotFoundException>();
    }
}
