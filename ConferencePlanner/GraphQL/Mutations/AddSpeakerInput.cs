namespace GraphQL.Mutations
{
    public record AddSpeakerInput(
        string Name,
        string? Bio,
        string? WebSite
        );
}
