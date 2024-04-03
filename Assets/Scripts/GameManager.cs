using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequenceList = new List<int>();

    public List<List<Color32>> buttonColors = new List<List<Color32>>();

    public List<Button> ClickeableButtons;

    public CanvasGroup buttons;

    void Start()
    {
        buttonColors.Add(new List<Color32> { new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255) }); // red        
        buttonColors.Add(new List<Color32> { new Color32(255, 187, 109, 255), new Color32(255, 136, 0, 255) }); // orange  
        buttonColors.Add(new List<Color32> { new Color32(162, 255, 124, 255), new Color32(72, 248, 0, 255) }); // green       
        buttonColors.Add(new List<Color32> { new Color32(57, 111, 255, 255), new Color32(0, 70, 255, 255) }); // blue
        for (int i = 0; i < buttonColors.Count; i++)
        {
            ClickeableButtons[i].GetComponent<Image>().color = buttonColors[i][0];
        }
    }
    
    public void AddToPlayerSequenceList(int buttonID)
    {
        playerSequenceList.Add(buttonID);
        StartCoroutine(HighlightButtons(buttonID));
        for (int i = 0; i < playerSequenceList.Count; i++)
        {
            if (playerTaskList[i] == playerSequenceList[i])
            {
                continue;
            }
            else
            {
                StartCoroutine(LostGame());
                return;
            }
        }
        if (playerSequenceList.Count == playerTaskList.Count)
        {
            StartCoroutine(StartNextRound());
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartNextRound());
    }

    public IEnumerator HighlightButtons(int buttonID)
    {
        ClickeableButtons[buttonID].GetComponent<Image>().color = buttonColors[buttonID][1];
        yield return new WaitForSeconds(0.5f);
        ClickeableButtons[buttonID].GetComponent<Image>().color = buttonColors[buttonID][0];
    }

    public IEnumerator LostGame()
    {
        playerSequenceList.Clear();
        playerTaskList.Clear();
        yield return new WaitForSeconds(1f);
        Debug.Log("Conectar con Menú de inicio");
    }

    public IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0, ClickeableButtons.Count));
        foreach(int index in playerTaskList)
        {
            yield return StartCoroutine(HighlightButtons(index));
        }
        buttons.interactable = true;
        yield return null;
    }
}
