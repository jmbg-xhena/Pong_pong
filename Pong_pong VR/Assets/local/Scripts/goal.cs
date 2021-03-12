using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public checkpoint[] checkpoints;
    public GameObject player;
    public LevelManager LM;
    public ball_launcher BL;
    public ui_cont UIcont;
    public AudioSource aud;
    public Renderer rend;
    public Color color;
    public float LerpTime = 0.0f;
    public bool won=false;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        won = false;
        color = rend.material.GetColor("_EmissionColor");
        particles = gameObject.transform.parent.gameObject.GetComponentInChildren<ParticleSystem>();
        particles.Stop();
        aud = this.gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        checkpoints = gameObject.GetComponentInParent<Animator>().gameObject.GetComponentsInChildren<checkpoint>();
        BL = player.GetComponentInChildren<Camera>().gameObject.GetComponent<ball_launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        //cambiar color del bote cuando se gana el nivel, reiniciar el color al original cuando se saca de nuevo el nivel
        if (LerpTime < 1&&won)
        {
            LerpTime += 0.05f;

        }
        if (LerpTime > 0 && !won)
        {
            LerpTime -= 0.05f;

        }

        rend.material.SetColor("_EmissionColor", Color.Lerp(color, new Color(0, 64, 0, 0) * 0f, LerpTime));
        rend.material.color = Color.Lerp(Color.white, Color.cyan, LerpTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //chacar si se han tocado todas las platafromas, si no, reiniciar el tiro de la pelota
        if (collision.transform.CompareTag("pelota")) {
            for (int i = 0; i < checkpoints.Length; i++) {
                if (!checkpoints[i].touched) {
                    collision.gameObject.transform.position = new Vector3(0, -20, 0);
                    return;
                }
            }
            print("you win");
            particles.Play();
            won = true;
            Invoke("unWon", 2.5f);
            aud.PlayOneShot(aud.clip);
            //traer la pantalla de siguente  nivel
            UIcont.fade_in_NL();
            LM.poolOut();
            Destroy(BL.instance);
        }
    }

    //reiniciar nivel y detener el efecto de particulas
    public void unWon() {
        won = false;
        particles.Stop();
    }
}
