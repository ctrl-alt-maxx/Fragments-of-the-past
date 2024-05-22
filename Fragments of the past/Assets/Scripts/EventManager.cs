using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    /////////////////////////////////////
    //INSÉRER ÉVÈNEMENTS POSSIBLES ICI
    /////////////////////////////////////
    public enum PossibleEvent
    {
        eAfficher = 0,
        eLightFire = 1,
        eChangerNbCle = 2,
        //Nb éléments
        eMAX
    }
    /////////////////////////////////////

    private List<UnityEvent<object>> eventList;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventList == null)
        {
            eventList = new List<UnityEvent<object>>();
            for (int i = 0; i < (int)PossibleEvent.eMAX; i++)
            {
                eventList.Add(new UnityEvent<object>());
            }
        }
    }

    public static void StartListening(PossibleEvent eventEnum, UnityAction<object> listener)
    {
        instance.eventList[(int)eventEnum].AddListener(listener);
    }

    public static void StopListening(PossibleEvent eventEnum, UnityAction<object> listener)
    {
        instance.eventList[(int)eventEnum].RemoveListener(listener);
    }

    public static void TriggerEvent(PossibleEvent eventEnum, object data)
    {
        instance.eventList[(int)eventEnum].Invoke(data);
    }
}