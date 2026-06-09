using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTypeMonad;

public static class BoxMethods
{
    /// <summary>
    /// Transforms the contents of a Box, in a user defined way
    /// </summary>
    /// <typeparam name="TA">The type of the thing in the box to start with</typeparam>
    /// <typeparam name="TB">The result type that the transforming function transforms to</typeparam>
    /// <param name="box">The Box that the extension method with work on</param>
    /// <param name="map">User defined way to transform the contents of the box</param>
    /// <returns>The results of the transformation, put back into a box</returns>
    public static Box<TB> Select<TA, TB>(this Box<TA> box, Func<TA, TB> map)
    {
        if (box.IsEmpty)
        {
            return new Box<TB>();
        }

        TB transformedItem = map(box.Item);
        return new Box<TB>(transformedItem);
    }
}
