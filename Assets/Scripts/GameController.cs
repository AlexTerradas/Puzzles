using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController m_Instance;

    [SerializeField]
    GameControllerUI m_GameControllerUI;

    [Header("Logic Puzzles")]
    [SerializeField]
    private bool m_GameWellDone;
    [SerializeField]
    private PlayerMovement m_PlayerMovement;

    [Header("Logic Paintings")]
    [SerializeField]
    private List<int> m_PaintingOrder;

    [SerializeField]
    private List<int> m_PaintingOrderResult = new List<int> { 1, 3, 4, 2 };

    [Header("Logic Paintings")]
    [SerializeField]
    private List<int> m_BooksOrder;

    [SerializeField]
    private List<int> m_BooksOrderResult = new List<int> { 5, 1, 4, 2 };

    [Header("Logic Library")]
    [SerializeField]
    private InputFieldScript m_InputFields; 

    [Header("Logic Armory")]
    [SerializeField]
    private List<int> m_PuzzleSwordStart = new List<int>();

    [SerializeField]
    private List<GameObject> m_SwordMinigame;

    [SerializeField]
    private List<int> m_PuzzleSwordCompleted;

    private void Awake()
    {
        if(m_Instance==null)
            m_Instance=this;
    }

    // Getters and Setters
    public bool GetGameWellDone()
    {
        return m_GameWellDone;
    }

    // Custom 
    public void AddPainting(int NumberOfPainting)
    {
        if (m_PaintingOrder.Count < m_PaintingOrderResult.Count)
            if (!m_PaintingOrder.Contains(NumberOfPainting))
                m_PaintingOrder.Add(NumberOfPainting);
    }

    public void AddBook(int NumberOfPainting)
    {
        if (m_BooksOrder.Count < m_BooksOrderResult.Count)
            if (!m_BooksOrder.Contains(NumberOfPainting))
                m_BooksOrder.Add(NumberOfPainting);
    }

    public bool CheckArraysGameSalaPrincipal()
    {
        bool l_Result = false;

        for (int i = 0; i < m_PaintingOrderResult.Count; ++i)
        {
            if (m_PaintingOrder[i] != m_PaintingOrderResult[i])
                l_Result = false;
            else
                l_Result = true;
        }

        return l_Result;
    }

    public bool CheckArraysGameLlibreria()
    {
        bool l_Result = false;

        for (int i = 0; i < m_BooksOrderResult.Count; ++i)
        {
            if (m_BooksOrder[i] != m_BooksOrderResult[i])
                l_Result = false;
            else
                l_Result = true;
        }

        return l_Result;
    }

    public void Reset()
    {
        m_GameWellDone = false;
        m_PaintingOrder = new List<int>();
        m_BooksOrder = new List<int>();
    }

    public void ActivatePlayerMovement(bool activate)
    {
        m_PlayerMovement.horizontalMove=0.0f;
        m_PlayerMovement.controller.m_Rigidbody2D.velocity=Vector2.zero;
        m_PlayerMovement.animator.SetFloat("Speed", 0.0f);
        m_PlayerMovement.enabled=activate;
    }

    public void ResetSwordRotation()
    {
        if(m_PuzzleSwordStart.Count==0)
            m_PuzzleSwordStart = new List<int> { 0, 315, 45, 180, 180, 0, 180, 180, 0, 180, 180, 225, 145 };

        Debug.Log("a "+ m_PuzzleSwordStart.Count);
        Debug.Log("b "+ m_SwordMinigame.Count);

        for (int i = 0; i < m_PuzzleSwordStart.Count; i++)
            m_SwordMinigame[i].GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, m_PuzzleSwordStart[i]);
    }

    // Start and Update
    void Start()
    {
        m_GameWellDone = false;
        m_PaintingOrder = new List<int>();
        m_BooksOrder = new List<int>();
        m_PuzzleSwordCompleted = new List<int>();
        m_PuzzleSwordStart = new List<int>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            m_GameControllerUI.GetInGameMenuCanvas().SetActive(true);

        if(m_GameControllerUI.m_CurrentCanvas!=null)
        {
            switch (m_GameControllerUI.m_CurrentCanvas.name)
            {
                case "CentreSala":
                    if(m_PaintingOrder.Count==m_PaintingOrderResult.Count)
                    {
                        if (CheckArraysGameSalaPrincipal())
                            m_GameControllerUI.ShowGameWellDone(true);
                        else
                        {
                            m_GameControllerUI.ShowGameWellDone(false);
                            Reset();
                        }
                    }
                    break;
                case "Llibreria":
                    if(m_InputFields.GetWordsObtained()&&!m_InputFields.GetBeaten())
                    {
                        m_GameControllerUI.SetWordsMinigame(true);
                        m_InputFields.SetBeaten(true);
                        m_GameControllerUI.ShowGameWellDone(true);
                    }
                    if (m_BooksOrder.Count == m_BooksOrderResult.Count)
                    {
                        m_GameControllerUI.SetWordsMinigame(false);
                        if (CheckArraysGameLlibreria())
                            m_GameControllerUI.ShowGameWellDone(true);
                        else
                        {
                            m_GameControllerUI.ShowGameWellDone(false);
                            Reset();
                        }
                    }
                    break;
                case "Armeria":
                    break;
            }
        }
    }
}
