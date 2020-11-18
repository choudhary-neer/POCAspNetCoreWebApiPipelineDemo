using System;

namespace AspNetCoreWebApiPipelineDemo.Models
{
    public static class CustomEvent<T>
    {
        public static EventGridEvent CreateCustomEvent(T obj)
        {
            return new EventGridEvent()
            {
                Id = Guid.NewGuid().ToString(),
                EventTime = DateTime.UtcNow,
                EventType = "MyCustomEventType",
                Subject = "MyCustomEventSubject",
                Data = obj
            };
        }
    }

}
