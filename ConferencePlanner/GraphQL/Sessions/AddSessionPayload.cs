using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Sessions
{
    public class AddSessionPayload : SessionPayloadBase
    {
        public AddSessionPayload(UserError erorr) : base(new[] { erorr })
        {
        }

        public AddSessionPayload(Session session) : base(session)
        {
        }

        public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}
