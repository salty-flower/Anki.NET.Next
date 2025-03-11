using Anki.Net.CollectionFile.Database.Model;
using Anki.Net.CollectionFile.Model;

namespace Anki.Net.CollectionFile.Mapper;

internal static class GraveMapper
{
    public static Grave FromDb(grave grave)
    {
        return new Grave(grave.usn, grave.oid, (GraveType)grave.type);
    }

    public static grave ToDb(Grave grave)
    {
        return new grave(grave.UpdateSequenceNumber, grave.OriginalId, (long)grave.Type);
    }
}
