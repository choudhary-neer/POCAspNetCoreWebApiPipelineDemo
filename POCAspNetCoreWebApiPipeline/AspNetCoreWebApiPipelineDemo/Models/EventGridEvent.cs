﻿using System;

namespace AspNetCoreWebApiPipelineDemo.Models
{
    public class EventGridEvent
    {
        public string Id { get; set; }
        public string EventType { get; set; }
        public string Subject { get; set; }
        public DateTime EventTime { get; set; }
        public object Data { get; set; }
    }

}