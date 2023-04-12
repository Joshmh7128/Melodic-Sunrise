using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSender : DapperReceiver
{
    public GameObject note, beatObject; // our prefabs
    [SerializeField] Transform rightSpawnRight, rightSpawnLeft, leftSpawnRight, leftSpawnLeft, topSpawnRight, topSpawnLeft, beatSpawn; // our beat spawns

    bool lastLR, lastRR, lastUR;

    public override void OnBeat()
    {
        // spawn in a beat object
        GameObject beat = Instantiate(beatObject, beatSpawn);
        GlowController.instance.renderers.Add(beat.transform.GetChild(0).gameObject.GetComponent<Renderer>());
    }

    
    // sending a note left
    public override void SendNoteL()
    {
        if (!lastLR)
        {
            Instantiate(note, leftSpawnRight);
            lastLR = true;
        } else if (lastLR)
        {
            Instantiate(note, leftSpawnLeft);
            lastLR = false;
        }
    }

    // sending a note right
    public override void SendNoteR()
    {
        if (!lastRR)
        {
            Instantiate(note, rightSpawnRight);
            lastRR = true;
        }
        else if (lastRR)
        {
            Instantiate(note, rightSpawnLeft);
            lastRR = false;
        }
    }

    // sending a note right
    public override void SendNoteU()
    {
        Debug.Log("Drop Top");

        if (!lastUR)
        {
            Instantiate(note, topSpawnRight);
            lastUR = true;
        }
        else if (lastUR)
        {
            Instantiate(note, topSpawnLeft);
            lastUR = false;
        }
    }
}
