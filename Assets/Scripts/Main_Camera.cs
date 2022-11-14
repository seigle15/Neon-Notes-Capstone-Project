using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform rhythmObject;
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 1, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, transform.position.z);
        rhythmObject.position = player.transform.position + new Vector3(0, 4.5f, rhythmObject.position.z);
    }
}
