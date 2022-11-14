using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CommandType
{
    VectorX = 1,
    VectorY = 2,
    VectorZ = 3,
    WaitMilliseconds = 4,
}
public class CommandModel 
{
    public CommandType commandType;
    public Guid commandId;
    public float value;
    public int background;
    public CommandModel()
    {

    }
    public CommandModel(CommandType commandType, Guid commandId, float value, int background)
    {
        this.commandType = commandType;
        this.commandId = commandId;
        this.value = value;
        this.background = background;
    }
}
