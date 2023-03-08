using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : DapperReceiver
{
    // all the renderers we'll be controlling
    [SerializeField] List<Renderer> renderers = new List<Renderer>();

    public float currentEmission, popEmit, reSpeed; // our multiplier of 

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
            renderer.material.SetColor("_EmissionColor", renderer.material.color * currentEmission);
        }

    }

    // request a glow
    public override void OnBeat()
    {
        currentEmission = popEmit;

        foreach (Renderer renderer in renderers)
        {
            renderer.material.SetColor("_EmissionColor", renderer.material.color * currentEmission);
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

}
