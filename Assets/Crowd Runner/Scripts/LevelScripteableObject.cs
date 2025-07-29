using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level", order = 0)]
public class LevelScripteableObject : ScriptableObject
{
    public Chunk[] chunks;
}
