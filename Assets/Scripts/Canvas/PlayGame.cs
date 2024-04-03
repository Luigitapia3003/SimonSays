using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject CanvasToDeactivate;
    public GameObject UIGame;
    public GameObject GameManagerRef;


    public void StartGame()
    {
        CanvasToDeactivate.SetActive(false);
        UIGame.SetActive(true);
        GameManagerRef.GetComponent<GameManager>().StartGame();
        Time.timeScale = 1f;

    }
}
