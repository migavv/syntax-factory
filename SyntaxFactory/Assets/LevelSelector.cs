using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string menu; // The name of the next scene to load when the level is completed
    public Button[] levelButtons; // Array de botones de los niveles

    private void Start()
    {
        // Asignamos un listener a cada botón en el array
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Asignar nivel según el índice, empezando desde 1
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    // Método que carga la escena correspondiente al nivel
    void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level_" + levelIndex);
    }


    public void MainMenu(){
        SceneManager.LoadScene(menu);
    }



}
