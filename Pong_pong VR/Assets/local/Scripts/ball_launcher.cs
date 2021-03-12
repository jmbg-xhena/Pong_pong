using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_launcher : MonoBehaviour
{
    public int No_balls=5;
    public int max_balls;
    public GameObject ball;
    public GameObject instance;
    public float launch_speed;
    public Transform spawn_pos;
    public bool disparado = false;
    public bool iniciar = false;
    public GvrReticlePointer pointer;
    public ui_cont UIC;
    public LevelManager LM;
    public AudioSource aud;

    public Text balls_text;

    // Start is called before the first frame update
    void Start()
    {
        pointer = GameObject.FindObjectOfType<GvrReticlePointer>();
        aud = this.gameObject.GetComponent<AudioSource>();
        max_balls = No_balls;
    }

    // Update is called once per frame
    void Update()
    {
        shoot_check();
        balls_text.text = "X" + No_balls.ToString();
    }


    public void shoot_check() {
        //checa si una pelota fué disparada y si está habilitado el disparo y cambia el color de la retícula dependiendo
        if (disparado)
        {
            if (iniciar)
            {
                pointer.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else {
                pointer.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        else
        {
            //si está disponible lanzar una pelota, si hay al menos una pelota en el cargador y si se hizo el imput de disparo: se dispara una pelota
            if (No_balls > 0)
            {
                pointer.GetComponent<MeshRenderer>().material.color = Color.green;

                if ((Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began)||Input.GetMouseButtonDown(0))
                {
                    disparado = true;
                    No_balls--;
                    aud.PlayOneShot(aud.clip);
                    instance = Instantiate(ball, transform);
                    instance.transform.position = spawn_pos.position;
                    instance.transform.rotation = transform.rotation;
                    instance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * launch_speed, ForceMode.VelocityChange);
                    instance.transform.parent = null;
                }
            }
        }

        //si la pelota está fuera de los límites del juego, se destruye y se habilita el disparo de una nueva
        if (instance)
        {
            if (instance.transform.position.y < -7)
            {
                Destroy(instance);
                disparado = false;
                if (No_balls <= 0)
                {
                    UIC.fade_in_lf();
                    LM.poolOut();
                }
            }
        }
    }
}
