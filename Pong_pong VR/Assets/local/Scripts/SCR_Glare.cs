using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Glare : MonoBehaviour
{
    public GameObject player;
    public GvrReticlePointer pointer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pointer= GameObject.FindObjectOfType<GvrReticlePointer>();
    }

    // Update is called once per frame
    public void BounceEnter()
    {
        //pointer.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void BounceExit()
    {
        //pointer.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
