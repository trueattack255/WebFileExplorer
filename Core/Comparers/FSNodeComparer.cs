#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Enums;
using Core.Enums;
using Core.Objects;

namespace Core.Comparers
{
    public class FSNodeComparer : IComparer<FSNode>
    {
        private readonly SortMode _sortMode;
        private readonly SortDirection _sortDirection;

        private readonly CultureInfo _culture;

        private const string One = "1";
        private const string Two = "2";
        
        public FSNodeComparer() : this(SortMode.Size, SortDirection.Ascending)
        { }
        
        public FSNodeComparer(SortMode mode) : this(mode, SortDirection.Ascending)
        { }

        public FSNodeComparer(SortMode mode, SortDirection direction)
        {
            _sortMode = mode;
            _sortDirection = direction;
            
            _culture = CultureInfo.InvariantCulture;
        }
        
        public int Compare(FSNode? x, FSNode? y)
        {
            var result = 0;
            
            switch (_sortMode) {
                case SortMode.Name:
                    result = CompareName(x, y);
                    break;
                case SortMode.Modified:
                    result = CompareLastChange(x, y);
                    break;
                case SortMode.Type:
                    result = CompareType(x, y);
                    break;
                case SortMode.Size:
                    result = Math.Sign(x!.Size - y!.Size);
                    break;
            }

            if (_sortDirection == SortDirection.Descending)
                result = -result;

            return result;
        }

        private int CompareName(FSNode? x, FSNode? y)
        {
            var firstString = $"{(x?.Type != FSObjectType.File ? One : Two)}{x?.Name}";
            var secondString = $"{(y?.Type != FSObjectType.File ? One : Two)}{y?.Name}";
            
            return String.Compare(firstString,secondString);
        }
        
        private int CompareLastChange(FSNode? x, FSNode? y)
        {
            var firstString = $"{(x?.Type != FSObjectType.File ? One : Two)}{x?.LastWriteTime:s}";
            var secondString = $"{(y?.Type != FSObjectType.File ? One : Two)}{y?.LastWriteTime:s}";
            
            return String.Compare(firstString,secondString);
        }
        
        private int CompareType(FSNode? x, FSNode? y)
        {
            return String.Compare(
                x?.Type == FSObjectType.File
                    ? Two + x.Extension.ToLower(_culture) + x.Name
                    : One + x?.Name,
                y?.Type == FSObjectType.File
                    ? Two + y.Extension?.ToLower(_culture) + y.Name
                    : One + y?.Name
            );
        }
    }
}