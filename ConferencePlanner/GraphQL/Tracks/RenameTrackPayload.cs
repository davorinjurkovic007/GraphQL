using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Tracks
{
    public class RenameTrackPayload : TrackPayloadBase
    {
        public RenameTrackPayload(Track track) : base(track)
        {
        }

        public RenameTrackPayload(IReadOnlyList<UserError> error) : base(error)
        {
        }
    }
}
