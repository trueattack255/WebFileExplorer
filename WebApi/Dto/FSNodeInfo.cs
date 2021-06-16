using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Core.Objects;

namespace WebApi.Dto
{
    public class FSNodeInfo : FSNodeBaseInfo, IHasChildren<FSNodeInfo>
    {
        [JsonPropertyName("leaf")]
        public bool IsLeaf { get; set; }
        public IList<FSNodeInfo> Children { get; set; }

        public static Func<FSNode, FSNodeInfo> Projection => (directory) => new FSNodeInfo
        {
            Name = directory.Name,
            Path = directory.Path,
            Type = directory.Type,
            Children = new List<FSNodeInfo>(),
            IsLeaf = directory.IsLeaf
        };
    }
}