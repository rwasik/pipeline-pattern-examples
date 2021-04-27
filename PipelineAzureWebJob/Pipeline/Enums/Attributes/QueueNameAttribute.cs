using System;

namespace PipelineAzureWebJob.Pipeline.Enums.Attributes
{
    public class QueueNameAttribute : Attribute
    {
        public string Name { get; }

        public QueueNameAttribute(string name)
        {
            Name = name;
        }
    }
}
