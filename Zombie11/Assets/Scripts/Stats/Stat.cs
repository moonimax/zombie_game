using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    private float baseValue;

    private List<float> values = new List<float>();

    public void SetBaseValue(float value)
    {
        baseValue = value;
    }

    public float GetValue()
    {
        float result = baseValue;

        foreach (var value in values)
        {
            result += value;
        }

        return result;
    }

    public void AddValue(float value)
    {
        if (value == 0)
            return;

        values.Add(value);
    }

    public void RemoveValue(float value)
    {
        if (value == 0)
            return;

        values.Remove(value);
    }
}
