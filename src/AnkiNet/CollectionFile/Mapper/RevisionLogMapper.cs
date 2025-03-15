using Anki.Net.CollectionFile.Database.Model;
using Anki.Net.CollectionFile.Model;

namespace Anki.Net.CollectionFile.Mapper;

internal static class RevisionLogMapper
{
    public static RevisionLog FromDb(revLog revLog)
    {
        return new RevisionLog(
            revLog.id,
            revLog.cid,
            revLog.usn,
            revLog.ease,
            revLog.ivl,
            revLog.lastIvl,
            revLog.factor,
            revLog.time,
            (RevisionType)revLog.type
        );
    }

    public static revLog ToDb(RevisionLog revisionLog)
    {
        return new revLog(
            revisionLog.Id,
            revisionLog.CardId,
            revisionLog.UpdateSequenceNumber,
            revisionLog.Ease,
            revisionLog.Interval,
            revisionLog.LastInterval,
            revisionLog.Factor,
            revisionLog.TimeTookMs,
            (long)revisionLog.RevisionType
        );
    }
}
