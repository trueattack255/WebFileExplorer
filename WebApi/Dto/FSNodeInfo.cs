using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Core.Implementations.Containers;

namespace WebApi.Dto
{
    public class FSNodeInfo : FSNodeBaseInfo, IHasChildren<FSNodeInfo>
    {
        [JsonPropertyName("leaf")]
        public bool IsLeaf { get; set; }
        public IList<FSNodeInfo> Children { get; set; }

        public static Func<FSDirectory, FSNodeInfo> Projection => (directory) =>
        {
            var children = directory.Objects
                .Select(x => new FSNodeInfo
                {
                    Name = x.Name,
                    Path = x.Path,
                    Type = x.Type,
                    Children = new List<FSNodeInfo>(),
                    IsLeaf = x.IsLeaf
                })
                .ToArray();

            return new FSNodeInfo
            {
                Name = directory.Name,
                Path = directory.Path,
                Type = directory.Type,
                Children = children,
                IsLeaf = !children.Any()
            };
        };
    }
}