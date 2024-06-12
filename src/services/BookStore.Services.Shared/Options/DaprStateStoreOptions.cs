namespace BookStore.Services.Shared.Options;

public class DaprStateStoreOptions
{
    public const string DaprStateStore = "Dapr:StateStore";

    public string StateStoreName { get; set; } = default!;
}
