using CommandGQLNet6.Models;

namespace CommandGQLNet6.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}
