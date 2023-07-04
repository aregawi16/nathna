using NatnaAgencyDigitalSystem.Core.Models.Common;

namespace NatnaAgencyDigitalSystem.Data.Pagination.Binders
{
    public class PageableBinderConfig
    {
        public const string DefaultPageParameter = "page";

        public const string DefaultSizeParameter = "size";

        public const string DefaultPrefix = "";

        public const string DefaultQualifierDelimiter = "_";

        public const int DefaultMaxPageSize = 20;

        public static readonly Pageable DefaultPageable = Pageable.Of(0, 20);

        public Pageable FallbackPageable { get; set; } = DefaultPageable;
        public string PageParameterName { get; set; } = DefaultPageParameter;
        public string SizeParameterName { get; set; } = DefaultSizeParameter;
        public string Prefix { get; set; } = DefaultPrefix;
        public string QualifierDelimiter { get; set; } = DefaultQualifierDelimiter;
        public int MaxPageSize { get; set; } = DefaultMaxPageSize;
    }
}
