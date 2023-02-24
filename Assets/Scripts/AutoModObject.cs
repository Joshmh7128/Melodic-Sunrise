using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Beat; 

public class AutoModObject : MonoBehaviour
{
    public string order;
    [SerializeField] TMP_InputField input;
    [SerializeField] int place; // where are we in the order?

    [SerializeField] List<AudioSource> sources = new List<AudioSource>();

    [SerializeField]
    Clock clock;

    [SerializeField]
    Beat.TickValue tickValue;

    [SerializeField] int currentBeat;

    public bool addAnother;

    private void Start()
    {
        BringInInstrument();
    }

    // brings in an instrument
    void BringInInstrument()
    {
        // if we are at a beat that is entirely divisible by 8, set the next volume to 1
        int i = Int32.Parse(order[place].ToString()) - 1;
        Debug.Log(i);
        sources[i].gameObject.GetComponent<Renderer>().enabled = true;
        sources[i].volume = 1;
        place++;
    }

    // reset
    void ResetMachine()
    {
        order = input.text.ToString();

        place = 0;

        foreach (AudioSource source in sources)
        {
            source.volume = 0;
            source.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    #region Delegate

    private void OnEnable()
    {
        clock.Beat += OnBeat;
        clock.Eighth += OnBeat;
    }
    private void OnDisable()
    {
        clock.Beat -= OnBeat;
        clock.Eighth -= OnBeat;
    }

    void OnBeat(Args beatArgs)
    {
        if (tickValue == beatArgs.BeatVal)
        {
            ReactAction();
        }
    }

    #endregion


    void ReactAction()
    {
        // count up our beats
        currentBeat++;

        if (currentBeat % 16 == 0)
        {
            addAnother = true;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetMachine();
        }

        if (addAnother)
        {
            addAnother = false;
            try { BringInInstrument(); } catch { }
        }
    }
}
