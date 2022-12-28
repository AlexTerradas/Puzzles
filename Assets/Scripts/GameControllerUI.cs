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

    public GameObject m_CurrentCanvas;

    [SerializeField]
    private GameObject m_PuzzleResultLibrary1;
    [SerializeField]
    private GameObject m_PuzzleResultLibrary2;
    [SerializeField]
    private GameObject m_PuzzleLibrary;
    [SerializeField]
    private InputFieldScript m_InputFields;

    [SerializeField]
    private GameObject m_PuzzleResultArmory;
    [SerializeField]
    private GameObject m_PuzzleArmory;

    [SerializeField]
    private GameObject m_PuzzleResultCentreSala;
    [SerializeField]
    private GameObject m_PuzzleCentreSala;
    [SerializeField]
    private GameObject m_PuzzleCentreSalaFinishedText;

    private bool m_WordsMinigame;

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

    public void SetWordsMinigame(bool Minigame)
    {
        m_WordsMinigame = Minigame;
    }

    // Custom

    public void ReturnToMainMenu()
    {
        m_CurrentCanvas.SetActive(false);
    }

    public void ShowGameWellDone(bool Result)
    {
        switch (m_CurrentCanvas.name)
        {
            case "CentreSala":
                m_PuzzleResultCentreSala.SetActive(true);
                ChangeTextOnResult(m_PuzzleResultCentreSala, Result, true);
                if(Result)
                    m_PuzzleCentreSalaFinishedText.SetActive(true);
                m_GameController.Reset();
                break;
            case "Llibreria":
                if (m_WordsMinigame)
                {
                    m_PuzzleResultLibrary1.SetActive(true);
                    ChangeTextOnResult(m_PuzzleResultLibrary1, Result, false);
                    m_InputFields.Reset();
                }
                else
                {
                    m_PuzzleResultLibrary2.SetActive(true);
                    ChangeTextOnResult(m_PuzzleResultLibrary2, Result, true);
                    m_GameController.Reset();
                }
                break;
            case "Armeria":
                m_PuzzleResultArmory.SetActive(true);
                ChangeTextOnResult(m_PuzzleResultArmory, Result, true);
                break;
        }
    }

    public void ChangeTextOnResult(GameObject Canvas, bool Result, bool listener)
    {
        Text l_text = Canvas.GetComponentInChildren<Text>();

        if (Result)
        {
            l_text.color = Color.green;
            l_text.text = "Well   Played!";
            if(listener)
                Canvas.GetComponent<Button>().onClick.AddListener(m_ReturnToMainMenuUnityAction);
        }
        else
        {
            l_text.color = Color.red;
            l_text.text = "Wrong!";
            if(listener)
                Canvas.GetComponent<Button>().onClick.RemoveListener(m_ReturnToMainMenuUnityAction);
        }
    }

    public void ChangeToPaintingMinigame()
    {
        SetCurrentCanvas(m_PuzzleCentreSala);
    }

    public void ChangeToBookMinigame()
    {
        SetCurrentCanvas(m_PuzzleLibrary);
    }

    public void ChangeToSwordMinigame()
    {
        SetCurrentCanvas(m_PuzzleArmory);
        m_GameController.ResetSwordRotation();
    }

    // Start && Update

    private void Start()
    {
        Cursor.visible = true;
        m_ReturnToMainMenuUnityAction = new UnityEngine.Events.UnityAction(ReturnToMainMenu);
    }
}
