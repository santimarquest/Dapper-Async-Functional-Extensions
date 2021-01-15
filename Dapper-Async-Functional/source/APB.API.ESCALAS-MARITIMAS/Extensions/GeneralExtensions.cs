using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APB.API.ESCALAS_MARITIMAS.Extensions
{
    public static class GeneralExtensions
    {
        public static T Execute<T>(this T @this, Action<T> action)
        {
            action(@this);
            return (@this);
        }

        public static T AddCondition<T, T1>(this T @this,
          T1 param,
          Func<T, T1, T> fn)
        {
            return fn(@this, param);
        }

        public static T AddCondition<T, T1, T2>(this T @this,
         T1 param1,
         T2 param2,
         Func<T, T1, T2, T> fn)
        {
            return fn(@this, param1, param2);
        }
    }
}