using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Tracks
{
    public class TrackPayloadBase : Payload
    {
        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }

        public Track? Track { get; }
    }
}
