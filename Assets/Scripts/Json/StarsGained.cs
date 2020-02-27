using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StarsGained
{
    public LevelInfo[] levels;
}

[Serializable]
public class LevelInfo
{
    public string LevelName;
    public int StarsWon;
    public int StarsRequired;
}

