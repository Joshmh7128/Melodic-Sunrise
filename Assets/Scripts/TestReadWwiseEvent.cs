using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK; // using wwise

public class TestReadWwiseEvent : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event beatEvent;


    private void Start()
    {
        // setup our event
        beatEvent.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, CallbackFunction);
    }

    // any callback requires these overloads
    void CallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)
    {
        Debug.Log("works");
    }

}
