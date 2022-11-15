namespace WebApplication2.Models
{
    public record UrlResponse
    {
        /// <summary>
        /// List of urls.
        /// </summary>
        public string[] Urls { get; set; }
        /// <summary>
        /// Length of list of urls.
        /// </summary>
        public int Length { get; set; }

        public UrlResponse(string[] urls, int length)
        {
            Urls = urls;
            Length = length;
        }
    }
}
