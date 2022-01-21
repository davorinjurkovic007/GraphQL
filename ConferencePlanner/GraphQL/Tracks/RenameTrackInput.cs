using GraphQL.Data;

namespace GraphQL.Tracks
{
    public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
}
