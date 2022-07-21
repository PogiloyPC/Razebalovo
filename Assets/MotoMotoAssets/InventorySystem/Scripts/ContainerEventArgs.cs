using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEventArgs
{
    // Сообщение
    public string Message { get; }
    public int Index { get; }
    public ContainerEventArgs(string message, int index)
    {
        Message = message;
        Index = index;
    }
}
