﻿using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Speakers
{
    public class SpeakerPayloadBase : Payload
    {
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }

        public Speaker? Speaker { get; }
    }
}
