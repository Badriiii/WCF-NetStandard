namespace Travelport.TravelData.Interfaces.SettingsProviders
{
    /// <summary>
    /// This represents the interface for class XmlDictionaryReaderQuotasElementSettings interface.
    /// </summary>
    public interface IXmlDictionaryReaderQuotasElementSettings
    {

        /// <summary>
        /// Gets the MaxDepth.
        /// </summary>
        int MaxDepth { get; set; }

        /// <summary>
        /// Gets the MaxStringContentLength.
        /// </summary>
        int MaxStringContentLength { get; set; }

        /// <summary>
        /// Gets the MaxArrayLength.
        /// </summary>
        int MaxArrayLength { get; set; }

        /// <summary>
        /// Gets the MaxBytesPerRead.
        /// </summary>
        int MaxBytesPerRead { get; set; }

        /// <summary>
        /// Gets the MaxNameTableCharCount.
        /// </summary>
        int MaxNameTableCharCount { get; set; }
    }
}
