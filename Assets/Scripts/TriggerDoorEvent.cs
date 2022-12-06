using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoorEvent : MonoBehaviour
{
    bool m_IsCharacterInside;
    bool m_AlreadyCleared;

    public bool m_DisableCharacter;
    public bool m_PreviousDoorCleared;
    public TriggerDoorEvent m_NextDoor;
    public GameObject m_ObjectToSetActive;
    public GameObject m_LockedWarning;
    public UnityEvent m_Event;

    // Update is called once per frame
    void Update()
    {
        if(m_IsCharacterInside && Input.GetKeyDown(KeyCode.E) && !m_AlreadyCleared)
        {
            if (m_PreviousDoorCleared)
            {
                if(m_ObjectToSetActive!=null)
                  m_ObjectToSetActive.SetActive(true);
                m_AlreadyCleared=true;
                if(m_NextDoor!=null)
                    m_NextDoor.m_PreviousDoorCleared=true;
                if(m_DisableCharacter)
                    GameController.m_Instance.ActivatePlayerMovement(false);
                if(m_Event!=null)
                    m_Event.Invoke();
            }
            else
            {
                m_LockedWarning.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(Disable());
            }
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
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.0f);
        m_LockedWarning.SetActive(false);
    }
}
