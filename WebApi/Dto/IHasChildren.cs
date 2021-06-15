using System.Collections.Generic;

namespace WebApi.Dto
{
    public interface IHasChildren<T> where T : FSNodeBaseInfo
    {
        bool IsLeaf { get; set; }
        IList<T> Children { get; set; }
    }
}