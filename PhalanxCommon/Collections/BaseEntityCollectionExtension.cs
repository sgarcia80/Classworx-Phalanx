using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public static class BaseEntityCollectionExtension
    {
        public static List<T> CollectionToList<T>(this System.Collections.ICollection other)
        {
            var output = new List<T>(other.Count);

            output.AddRange(other.Cast<T>());

            return output;
        }
    }
}
