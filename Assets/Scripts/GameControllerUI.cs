using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerUI : MonoBehaviour
{
    [SerializeField]
    GameController m_GameController;

    [Header("Canvas")]
    [SerializeField]
    private GameObject m_InGameMenuCanvas;

    private GameObject m_CurrentCanvas;

    [SerializeField]
    private GameObject m_PuzzleResultLibrary = null;

    [SerializeField]
    private GameObject m_PuzzleResultArmory;

    [SerializeField]
    private GameObject m_PuzzleResultCentreSala;

    private UnityEngine.Events.UnityAction m_ReturnToMainMenuUnityAction;

    // Setters and Getters
    public void SetCurrentCanvas(GameObject Canvas)
    {
        m_CurrentCanvas = Canvas;
    }
    public GameObject GetCurrentCanvas()
    {
        return m_CurrentCanvas;
    }
    public GameObject GetInGameMenuCanvas()
    {
        return m_InGameMenuCanvas;
    }

    // Custom

    public void ReturnToMainMenu()
    {
        m_CurrentCanvas.SetActive(false);
        m_CurrentCanvas.SetActive(true);

    }

    public void ShowGameWellDone(bool Result)
    {
        switch (m_CurrentCanvas.name)
        {
            case "CentreSala":
                m_PuzzleResultCentreSala.SetActive(true);
                ChangeTextOnResult(m_PuzzleResultCentreSala, Result);
                m_GameController.Reset();

                break;
            case "Llibreria":
                m_PuzzleResultLibrary.SetActive(true);
                ChangeTextOnResult(m_PuzzleResultLibrary, Result);
                m_GameController.Reset();
                break;
        }
    }

    public void ChangeTextOnResult(GameObject Canvas, bool Result)
    {
        Text l_text = Canvas.GetComponentInChildren<Text>();

        if (Result)
        {
            l_text.color = Color.green;
            l_text.text = "Well   Played!";
            Canvas.GetComponent<Button>().onClick.AddListener(m_ReturnToMainMenuUnityAction);
        }
        else
        {
            l_text.color = Color.red;
            l_text.text = "Wrong!";
            Canvas.GetComponent<Button>().onClick.RemoveListener(m_ReturnToMainMenuUnityAction);
        }
    }

    public void ChangeToPaintingMinigame()
    {

    }

    public void ChangeToBookMinigame()
    {

    }

    public void ChangeToSwordMinigame()
    {
        m_GameController.ResetSwordRotation();
        SetCurrentCanvas(m_PuzzleResultArmory);
    }

    // Start && Update

    private void Start()
    {
        Cursor.visible = true;
        m_ReturnToMainMenuUnityAction = new UnityEngine.Events.UnityAction(ReturnToMainMenu);
    }
}
