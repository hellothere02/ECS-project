using System.Collections.Generic;
using UnityEngine;

public class WheelsData 
{
    private Stack<GameObject> wheels = new Stack<GameObject>();

    public void AddWheel(GameObject _wheel)
    {
        wheels.Push(_wheel);
    }

    public GameObject GetWheel()
    {
        return wheels.Pop();
    }

    public float WheelsCount()
    {
        return (float)wheels.Count;
    }
}
