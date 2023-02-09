using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer glower; // the sprite we make glow
    [SerializeField] Color black, glow; // the black and color we want to glow
    [SerializeField] KeyCode assignedKey; // our assigned key
    [SerializeField] AudioSource audioSource; // the audio source that is playing our looped sound
    [SerializeField] float changeRate; // what is the rate of change?

    private void Start()
    {
        // set everything to 0

    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        // glow when we press a key
        if (Input.GetKey(assignedKey))
        {
            glower.color = Color.Lerp(glower.color, glow, Time.fixedDeltaTime * changeRate);
            audioSource.volume = Mathf.Lerp(audioSource.volume, 1, Time.fixedDeltaTime * changeRate);
        }

        // reduce glow when we are not pressing a key
        if (!Input.GetKey(assignedKey))
        {
            glower.color = Color.Lerp(glower.color, black, Time.fixedDeltaTime * changeRate);
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, Time.fixedDeltaTime * changeRate*2);
        }
    }
}
