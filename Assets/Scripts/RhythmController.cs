using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool beatCheck;
    public Animator RhythmAnimator; 
    void Start()
    {
        //beatCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            beatCheck = true;
        }
        else
        {
            beatCheck = false;
        }
    }

    public bool OnBeat()
    {
        if (beatCheck)
        {
            return true;
            Debug.Log("Hit");
        }
        else
        {
            return false;
        }
    }
}
