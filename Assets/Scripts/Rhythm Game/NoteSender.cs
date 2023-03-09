using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSender : DapperReceiver
{
    public GameObject note, beatObject; // our prefabs
    [SerializeField] Transform rightSpawnRight, rightSpawnLeft, leftSpawnRight, leftSpawnLeft, topSpawnRight, topSpawnLeft, beatSpawn; // our beat spawns

    bool lastLR, lastRR;

    public override void OnBeat()
    {
        // spawn in a beat object
        GameObject beat = Instantiate(beatObject, beatSpawn);
        GlowController.instance.renderers.Add(beat.transform.GetChild(0).gameObject.GetComponent<Renderer>());
    }

    /*
    public override void SendNoteL()
    {
        if (lastLR)
        {
            Instantiate(note, leftSpawnRight.position, Quaternion.identity, null);
            lastLR = true;
        }
        if (!lastLR)
        {
            Instantiate(note, leftSpawnLeft.position, Quaternion.identity, null);
            lastLR = false;
        }
    }*/
}
