using System;

namespace Anki.Net;

internal static class IdFactory
{
    public static long Create() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}
