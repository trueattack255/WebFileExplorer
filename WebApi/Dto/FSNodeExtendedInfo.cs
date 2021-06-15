using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Core.Implementations.Containers;

namespace WebApi.Dto
{
    public class FSNodeExtendedInfo : FSNodeBaseInfo, IHasChildren<FSNodeExtendedInfo>
    {
        public string Extension { get; set; }
        public long Size { get; set; }
        
        [JsonPropertyName("leaf")]
        public bool IsLeaf { get; set; }
        public IList<FSNodeExtendedInfo> Children { get; set; }
        
        public static Func<FSDirectory, FSNodeExtendedInfo> Projection => (directory) =>
        {
            var children = directory.Objects
                .Select(x => new FSNodeExtendedInfo
                {
                    Name = x.Name,
                    Path = x.Path,
                    Type = x.Type,
                    Size = x.Size,
                    Extension = x.Extension,
                    Children = new List<FSNodeExtendedInfo>(),
                    IsLeaf = x.IsLeaf
                })
                .ToArray();

            return new FSNodeExtendedInfo
            {
                Name = directory.Name,
                Path = directory.Path,
                Type = directory.Type,
                Size = directory.Size,
                Extension = directory.Extension,
                Children = children,
                IsLeaf = !children.Any()
            };
        };
    }
}