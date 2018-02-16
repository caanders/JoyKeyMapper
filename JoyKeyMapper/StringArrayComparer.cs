using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JoyKeyMapper
{
    class StringArrayComparer<T> : EqualityComparer<T>
    {
        public override bool Equals(T x, T y)
        {
            if (x.GetType() == (new string[0]).GetType()
                && y.GetType() == (new string[0]).GetType())
            {
                string[] xArray = x as string[];
                string[] yArray = y as string[];
                DeepCompare.DeepComparer test = new DeepCompare.DeepComparer();
                return test.Compare(xArray, yArray);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(T obj)
        {
            if (obj.GetType() == (new string[0]).GetType())
            {
                string complete = "";
                string[] stringArray = obj as string[];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    complete += stringArray[i];
                }
                return complete.GetHashCode();
            }
            else
            {
                return obj.GetHashCode();
            }
        }
    }
}
