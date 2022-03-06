using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;

namespace Mvp.Foundation.Search.Models
{
    /// <summary>
    /// Publication Search Result Model
    /// </summary>
    public class Publication
    {

        [SimpleField(IsKey = true)]
        [JsonPropertyName("metadata_storage_path")]
        public string MetadataStoragePath { get; set; }

        [SimpleField]
        [JsonPropertyName("metadata_storage_name")]
        public string MetadataStorageName { get; set; }

        [SearchableField]
        [JsonPropertyName("metadata_description")]
        public string MetadataDescription { get; set; }


        [SearchableField]
        [JsonPropertyName("metadata_title")]
        public string MetadataTitle { get; set; }

        [SearchableField]
        [JsonPropertyName("content")]
        public string Content { get; set; }
        
        [SearchableField]
        [JsonPropertyName("people")]
        public string[] People { get; set; }

        [SearchableField]
        [JsonPropertyName("organizations")]
        public string[] Organizations { get; set; }

        [SearchableField]
        [JsonPropertyName("locations")]
        public string[] Locations { get; set; }

        [SearchableField]
        [JsonPropertyName("keyphrases")]
        public string[] KeyPhrases { get; set; }

    }
}
