using System;

namespace Sebo.Core.IntegrationEvents
{
    public class ImageResponseIntegrationEvent
    {
        public bool Success { get; set; }
        public Guid ChapterId { get; set; }
        public string Message { get; set; }
    }
}
