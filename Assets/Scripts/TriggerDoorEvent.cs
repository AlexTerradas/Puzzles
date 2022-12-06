using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoorEvent : MonoBehaviour
{
    public bool m_PreviousDoorCleared;
    public bool m_DisableCharacter;
    public TriggerDoorEvent m_NextDoor;
    bool m_IsCharacterInside;
    public GameObject m_ObjectToSetactive;
    public UnityEvent m_Event;

    // Update is called once per frame
    void Update()
    {
        if(m_IsCharacterInside && Input.GetKeyDown(KeyCode.E) && m_PreviousDoorCleared)
        {
            m_ObjectToSetactive.SetActive(true);
            m_NextDoor.m_PreviousDoorCleared=true;
            if (m_DisableCharacter)
                GameController.m_Instance.ActivatePlayerMovement(false);
            if (m_Event != null)
                m_Event.Invoke();
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_IsCharacterInside = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_IsCharacterInside = false;
    }

}
