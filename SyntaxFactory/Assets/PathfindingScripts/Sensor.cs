using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
   // lista con todos los objetos detectables que actualmente estan tocando el colisionador de este sensor
  public List<Detectable> detectedObjects = new List<Detectable>();
public void AddDetectable(Detectable detectable)
{
    if (!detectedObjects.Contains(detectable))
    {
        detectedObjects.Add(detectable);   
    }
}

public void RemoveDetectable(Detectable detectable)
{
    if (detectedObjects.Contains(detectable))
    {
        detectedObjects.Remove(detectable);   
    }
}

  private void OnTriggerEnter(Collider other) {
    // si el trigger toca un objeto detectable, lo añade a la lista de detectados
    Detectable detected = other.GetComponent<Detectable>();
    if(detected){
        AddDetectable(detected);

    }
  }

  private void OnTriggerExit(Collider other) {
     // si el trigger deja de tocar el trigger, lo remueve de la lista de detectados
    Detectable detected = other.GetComponent<Detectable>();
    if (detected){
        RemoveDetectable(detected);
    }
  }
}
