using System.Collections.Generic;

namespace GenericImporter.Web.Core.Common
{
    public class UnprocessableEntityResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
