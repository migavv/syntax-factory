using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject InventoryMenu;
    public GameObject robot;
    private bool menuActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && menuActivated){
            Debug.Log("Activado");
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if(Input.GetKeyDown(KeyCode.E) && !menuActivated){
            Debug.Log("Desactivado");
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
}
