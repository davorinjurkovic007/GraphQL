using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Speakers
{
    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker) : base(speaker)
        {
        }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}
