using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRC_Fade : MonoBehaviour
{
    public static SRC_Fade instance;
    public Animator crlFade;
    public float FadeDUration;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) {
            instance = this;
        }
    }

    // Update is called once per frame
    public void Fading()
    {
        crlFade.SetTrigger("Fade");
    }
}
