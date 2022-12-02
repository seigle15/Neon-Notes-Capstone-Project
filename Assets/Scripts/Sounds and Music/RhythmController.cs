using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool beatCheck;
    public bool hit;
    public const float timeCheck = 5f;
    private float beatWaitTime;
    public Animator RhythmAnimator;
    [SerializeField] private float speed;
    [SerializeField] public Conductor _conductor;

    
    private void Awake()
    {
        
        //speed = _conductor.songBpm;
        //RhythmAnimator.SetFloat("Speed", _conductor.secPerBeat);
        
        RhythmAnimator.speed = _conductor.secPerBeat;
        Debug.Log(RhythmAnimator.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && beatCheck)
        {
            hit = true;
        }

        if (Input.GetMouseButtonDown(0) && !beatCheck)
        {
            hit = false;
        }
    }

    public bool getBeat()
    {
        return hit;
    }

    public void setBeat(bool set)
    {
        hit = set;
    }

    public void OnBeat()
    {
        beatCheck = true;
    }

    public void OffBeat()
    {
        beatCheck = false;
    }
    
}
