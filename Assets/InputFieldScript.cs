using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{
    [SerializeField]
    private InputField m_InputField1;
    [SerializeField]
    private InputField m_InputField2;
    [SerializeField]
    private InputField m_InputField3;
    [SerializeField]
    private InputField m_InputField4;

    bool m_CorrectWord1=false;
    bool m_CorrectWord2=false;
    bool m_CorrectWord3=false;
    bool m_CorrectWord4=false;

    bool m_WordsObtained=false;
    bool m_Beaten = false;

    // Update is called once per frame
    void Update()
    {
        if(m_InputField1.textComponent.text.ToLower()=="poetica")
        {
            m_InputField1.textComponent.color = Color.green;
            m_CorrectWord1=true;
        }
        else
        {
            m_InputField1.textComponent.color = Color.red;
            m_CorrectWord1=false;
        }
        if(m_InputField2.textComponent.text.ToLower()=="violetes")
        {
            m_InputField2.textComponent.color = Color.green;
            m_CorrectWord2 = true;
        }
        else
        {
            m_InputField2.textComponent.color = Color.red;
            m_CorrectWord2 = false;
        }
        if (m_InputField3.textComponent.text.ToLower() == "centum")
        {
            m_InputField3.textComponent.color = Color.green;
            m_CorrectWord3 = true;
        }
        else
        {
            m_InputField3.textComponent.color = Color.red;
            m_CorrectWord3 = false;
        }
        if (m_InputField4.textComponent.text.ToLower() == "sanctus")
        {
            m_InputField4.textComponent.color = Color.green;
            m_CorrectWord4 = true;
        }
        else
        {
            m_InputField4.textComponent.color = Color.red;
            m_CorrectWord4 = false;
        }

        if (m_CorrectWord1 && m_CorrectWord2 && m_CorrectWord3 && m_CorrectWord4)
            m_WordsObtained = true;
        else
            m_WordsObtained = false;
    }

    public bool GetWordsObtained()
    {
        return m_WordsObtained;
    }
    public bool GetBeaten()
    {
        return m_Beaten;
    }
    public void SetBeaten(bool Bool)
    {
        m_Beaten = Bool;
    }
    public void Reset()
    {
        m_InputField1.textComponent.text="";
        m_InputField2.textComponent.text="";
        m_InputField3.textComponent.text="";
        m_InputField4.textComponent.text="";
        m_CorrectWord1 = false;
        m_CorrectWord2 = false;
        m_CorrectWord3 = false;
        m_CorrectWord4 = false;
        m_WordsObtained = false;
    }
}
