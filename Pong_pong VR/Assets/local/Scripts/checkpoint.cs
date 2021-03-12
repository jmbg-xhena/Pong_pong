using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject player;
    public ball_launcher BL;
    public bool touched;
    public Renderer rend;
    public Color color;
    public float LerpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        LerpTime = 0.0f;
        rend = this.gameObject.GetComponent<Renderer>();
        color= rend.material.GetColor("_EmissionColor");
        player = GameObject.FindGameObjectWithTag("Player");
        BL = player.GetComponentInChildren<Camera>().gameObject.GetComponent<ball_launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        //si no se logró ganar con la pelota lanzada, se reincia lentamente el valor del color al original
        if (!BL.disparado) {
            if (LerpTime > 0) { 
                LerpTime-=0.05f;
            }
            touched = false;
            print("untouch");
        }

        //si la plataforma fue tocada, se cambia de froma lenta el color
        if (BL.disparado && touched) {
            if (LerpTime < 1)
            {
                LerpTime += 0.05f;
            }
        }
        rend.material.SetColor("_EmissionColor", Color.Lerp(color, new Color(0, 64, 0, 0) * 0f, LerpTime));
        rend.material.color = Color.Lerp(Color.white, Color.cyan, LerpTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("pelota"))
        {
            print("touched");
            touched = true;
        }
    }
}
