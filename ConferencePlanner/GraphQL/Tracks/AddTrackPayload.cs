using GraphQL.Common;
using GraphQL.Data;
using System.Collections.Generic;

namespace GraphQL.Tracks
{
    public class AddTrackPayload : TrackPayloadBase
    {
        public AddTrackPayload(Track track) : base(track)
        {
        }

        public AddTrackPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}
