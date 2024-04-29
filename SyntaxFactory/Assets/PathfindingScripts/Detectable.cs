using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectable : MonoBehaviour
{
    // string usado para separar los objetos detectables en grupos de tipos
    public string type;
    public void OnEnable(){
        //anade este objeto en la lista manager cuando se habilite
        DetectionManager.AddDetectable(this);
    }

     public void OnDisable(){
        //remueve este objeto en la lista manager cuando se deshabilite
        DetectionManager.RemoveDetectable(this);
    }
}
