﻿using ProtoBuf;

namespace Wikiled.Amazon.Logic
{
    [ProtoContract]
    public class UserData
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
