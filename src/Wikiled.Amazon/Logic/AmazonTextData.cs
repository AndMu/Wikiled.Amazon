﻿using ProtoBuf;

namespace Wikiled.Amazon.Logic
{
    [ProtoContract]
    public class AmazonTextData
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Summary { get; set; }

        [ProtoMember(3)]
        public string Text { get; set; }
    }
}
