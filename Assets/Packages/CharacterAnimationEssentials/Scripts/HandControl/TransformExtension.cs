using System;
using UnityEngine;

public static class TransformEx
{
    public static Transform FirstChildOrDefault(this Transform parent, Func<Transform, bool> query)
    {
        Transform result = null;

        if (query(parent))
            result = parent;

        if (result != null)
            return result;

        foreach (Transform child in parent)
        {
            result = FirstChildOrDefault(child, query);

            if (result != null)
                return result;
        }

        return null;
    }



}