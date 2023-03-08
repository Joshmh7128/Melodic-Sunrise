using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSender : MonoBehaviour
{
    public GameObject note; // our note prefab
    [SerializeField] Transform rightSpawnA, rightSpawnB;
    [SerializeField] Transform leftSpawnA, leftSpawnB;

    bool lastLA, lastRA;

    public void SendNoteL()
    {
        if (lastLA)
        {
            Instantiate(note, leftSpawnA.position, Quaternion.identity, null); 
            lastLA = true;
        }
        if (!lastLA)
        {
            Instantiate(note, leftSpawnB.position, Quaternion.identity, null);
            lastLA = false;
        }
    }
}
