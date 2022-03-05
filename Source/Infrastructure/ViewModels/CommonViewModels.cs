using System.Text.Json.Serialization;

namespace Tawasal.ViewModels
{
    public class CommonViewModels
    {
    }


    public class IndexedDBItem
    {
        public string? Id { get; set; }

        [JsonIgnore] public bool IsUpdating { get; set; }

        [JsonIgnore] public string? NewValue { get; set; }

        public string? Value { get; set; }

    }

}
