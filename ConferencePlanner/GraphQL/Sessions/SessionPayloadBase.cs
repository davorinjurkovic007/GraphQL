using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Sessions
{
    public class SessionPayloadBase : Payload
    {
        public SessionPayloadBase(Session session)
        {
            Session = session;
        }

        public SessionPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }

        public Session? Session { get; }
    }
}
