using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionManager : ScriptableObject
{
    //Lista de objetos detectables activos en la escena
  public static List<Detectable> detectableObjects = new List<Detectable>();

public static void AddDetectable(Detectable detectable)
{
    if (!detectableObjects.Contains(detectable))
    {
        detectableObjects.Add(detectable);   
    }
}
public static void RemoveDetectable(Detectable detectable)
{
    if (detectableObjects.Contains(detectable))
    {
        detectableObjects.Remove(detectable);   
    }
}

}
