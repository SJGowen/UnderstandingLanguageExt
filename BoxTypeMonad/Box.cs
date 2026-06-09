using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTypeMonad;

/// <summary>
/// A box can hold a thing only
/// </summary>
/// <typeparam name="T">The type of the thing</typeparam
public class Box<T>
{
    public Box(T newItem)
    {
        Item = newItem;
        IsEmpty = false;
    }

    public Box() { }

    private T _item;

    public T Item
    {
        get => _item;
        set
        {
            _item = value;
            IsEmpty = false;
        }
    }

    public bool IsEmpty = true;
}
