using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTypeMonad;

public static class BoxMethods
{
    /// <summary>
    /// Transforms the contents of a Box, in a user defined way
    /// by using the Validate, Extract, Transform and Lift steps.
    /// </summary>
    /// <typeparam name="TA">The type of the thing in the box to start with</typeparam>
    /// <typeparam name="TB">The result type that the transforming function transforms to</typeparam>
    /// <param name="box">The Box that the extension method with work on</param>
    /// <param name="map">User defined way to transform the contents of the box</param>
    /// <returns>The results of the transformation, put back into a box</returns>
    public static Box<TB> Select<TA, TB>(this Box<TA> box, Func<TA, TB> select)
    {
        // Validate
        if (box.IsEmpty) return new Box<TB>();

        // Extract
        var extracted = box.Item;

        // Transform
        TB transformed = select(extracted);

        // Lift
        return new Box<TB>(transformed);
    }

    /// <summary>
    /// Validate, Extract, Tranform and Lift
    /// Check/Validate then transform to T and Lift into Box<t>
    /// </summary>
    public static Box<TB> Bind<TA, TB>(this Box<TA> box, Func<TA, Box<TB>> bind)
    {
        // Validate
        if (box.IsEmpty) return new Box<TB>();

        // Extract
        TA extracted = box.Item;

        // Transform
        Box<TB> transformedAndLifted = bind(extracted);

        // Lift
        return transformedAndLifted;
    }

    /// <summary>
    /// Validate, Extract, Tranform and automatic Lift
    /// </summary>
    public static Box<TB> Map<TA, TB>(this Box<TA> box, Func<TA, TB> map)
    {
        // Validate
        if (box.IsEmpty) return new Box<TB>();

        // Extract
        TA extracted = box.Item;

        // Transform
        TB transformed = map(extracted);

        // Lift
        return new Box<TB>(transformed);
    }
}
