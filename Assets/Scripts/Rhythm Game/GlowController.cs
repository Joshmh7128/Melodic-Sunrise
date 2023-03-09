using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : DapperReceiver
{
    // all the renderers we'll be controlling
    public List<Renderer> renderers = new List<Renderer>();

    public float currentEmission, popEmit, reSpeed; // our multiplier of 

    public enum moods { low, mid, high}

    public moods mood;

    public static GlowController instance;
    private void Awake() => instance = this;


    public void FixedUpdate()
    {
        GlowLerp();
    }

    void GlowLerp()
    {
        currentEmission = Mathf.Lerp(currentEmission, 0f, Time.fixedDeltaTime * reSpeed);
        // then set
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
                renderer.material.SetColor("_EmissionColor", renderer.material.color * currentEmission);
        }

    }

    // request a glow
    public override void OnBeat()
    {
        currentEmission = popEmit;
        try
        {
            foreach (Renderer renderer in renderers)
            {
                if (renderer != null)
                {
                    renderer.material.SetColor("_EmissionColor", renderer.material.color * currentEmission);
                }

                if (renderer == null)
                {
                    for (int i = 0; i < renderers.Count; i++)
                    {
                        if (renderers[i] == null)
                            renderers.Remove(renderers[i]);
                    }
                }
            }
        } 
        catch
        {
            // we dont care if something leaves the collection cus we dont care if something that doesnt exist doesnt glow!@!!!! :>
        }
    }

    public override void ExampleMarker()
    {
        Debug.Log("ExampleMarker Triggered");
    }

    public override void SetRed()
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Color.red;
        }
    }

    public override void LowMood()
    {
        Debug.Log("running");
        reSpeed = 1f;
        popEmit = 1f;
        mood = moods.low;
    }  
    
    public override void MidMood()
    {
        reSpeed = 2f;
        popEmit = 2f;
        mood = moods.mid;
    }

    public override void HighMood()
    {
        reSpeed = 2f;
        popEmit = 3f;
        mood = moods.high;
    }

}
