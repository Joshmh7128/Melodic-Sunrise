using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPX : MonoBehaviour
{
    PXStrax pXStrax;

    // our variables
    [SerializeField] float key;

    // our vertices
    [SerializeField] List<Transform> controllers = new List<Transform >();
    [SerializeField] List<Transform> controllersY = new List<Transform >();
    [SerializeField] List<Transform> controllersZ = new List<Transform >();
    /// <summary>
    /// 0 = key control
    /// 1 = key multiplier
    /// 2 = cutoff
    /// 3 = resonance
    /// 4 = envelope
    /// 5 = harmonic
    /// 6 = distortion
    /// 7 = attack
    /// 8 = release
    /// 9 = amp
    /// 10 = rate
    /// </summary>

    private void Start()
    {
        // get our px script
        pXStrax = GetComponent<PXStrax>();

        // what we're going to shuffle
        foreach (Transform t in controllers)
        {
            controllersY.Add(t);
            controllersZ.Add(t);
        }

        // randomize controllers
        controllers.Shuffle();
        controllersY.Shuffle();
        controllersZ.Shuffle();
        // play a note
        StartCoroutine(PlayToneEverySecond());
    }

    IEnumerator PlayToneEverySecond()
    {
        yield return new WaitForSecondsRealtime(1);
        pXStrax.KeyOn(key);
        yield return new WaitForSecondsRealtime(1);
        pXStrax.KeyOff();
        // start the coroutine again
        StartCoroutine(PlayToneEverySecond());
    }

    private void FixedUpdate()
    {
        SynthControl();
    }

    void SynthControl()
    {
        // set key 
        key = VecVal(0) * VecVal(1);
        // set cutoff
        pXStrax.cutoff = VecVal(2) / 10;
        // set resonance
        pXStrax.resonance = VecVal(3) * 10;
        // envelope
        pXStrax.envelope = VecVal(4) / 100;
        // harmonic
        pXStrax.harmonic = VecVal(5) / 2;
        // distortion
        pXStrax.distortion = VecVal(6) / 10;
        // attack
        pXStrax.attack = VecVal(7) / 10;
        // release
        pXStrax.release = VecVal(8) / 10;
        // amp
        pXStrax.lfoAmp = VecVal(9) / 10;
        // rate
        pXStrax.lfoRate = VecVal(10);
    }

    float VecVal(int vec)
    {
        return (controllers[vec].position.x + controllersY[vec].position.y + controllersZ[vec].position.z);
    }
    
}


public static class ExtMethod
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
