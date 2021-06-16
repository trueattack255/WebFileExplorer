using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Core.Objects;

namespace WebApi.Dto
{
    public class FSNodeExtendedInfo : FSNodeBaseInfo, IHasChildren<FSNodeExtendedInfo>
    {
        public string Extension { get; set; }
        public long Size { get; set; }
        
        [JsonPropertyName("leaf")]
        public bool IsLeaf { get; set; }
        public IList<FSNodeExtendedInfo> Children { get; set; }
        
        public static Func<FSNode, FSNodeExtendedInfo> Projection => (directory) => new FSNodeExtendedInfo
        {
            Name = directory.Name,
            Path = directory.Path,
            Type = directory.Type,
            Size = directory.Size,
            Extension = directory.Extension,
            Children = new List<FSNodeExtendedInfo>(),
            IsLeaf = directory.IsLeaf
        };
    }
}