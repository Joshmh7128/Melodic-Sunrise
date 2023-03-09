using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DapperReceiver : MonoBehaviour
{
    // add ourselves to the dapper manager
    public void Start()
    { try { DapperManager.instance.dapperReceivers.Add(this); } catch { Debug.LogError("No DapperManager Instance Found!"); } }

    private void OnDestroy() => DapperManager.instance.dapperReceivers.Remove(this);
    // class exists to run virtual functions

    public virtual void OnBeat() { }    // runs on the FMOD beat function
    public virtual void ExampleMarker() { } // runs when a marker is named ExampleMarker
    public virtual void SetRed() { } // runs whenever a marker is named SetRed

    // moods
    public virtual void LowMood() { } // our low mood
    public virtual void MidMood() { } // our low mood
    public virtual void HighMood() { } // our low mood

    // our notes
    public virtual void SendNoteL() { } // when we call note L


}
