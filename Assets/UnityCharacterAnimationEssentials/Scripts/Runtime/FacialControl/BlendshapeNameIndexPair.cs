using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlendshapeNameIndexMaxValuePair
{
    public string Name;

    public bool isMouth = false;
    
    [Range(0f, 100f)]
    public float MaxValue;

    public int IndexCategory { get; set; } = 0;
    public int Index { get; set; } = -1;

}
