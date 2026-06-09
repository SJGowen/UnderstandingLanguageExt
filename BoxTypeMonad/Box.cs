using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTypeMonad;

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
