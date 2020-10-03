using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 WithZ(this Vector3 original, in float z)
    {
        return new Vector3(original.x, original.y, z);
    }

    public static T GetRandomAndRemove<T>(this List<T> list)
    {
        T obj = list[UnityEngine.Random.Range(0, list.Count)];
        list.Remove(obj);
        return obj;
    }

    public static Color WithAlpha(this Color original, in float alpha)
    {
        Color color = original;
        color.a = alpha;
        return color;
    }
}
