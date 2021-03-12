using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_cont : MonoBehaviour
{
    public Animator anim;
    public Canvas MainMenu;
    public Canvas NextLevel;
    public Canvas LevelFailed;
    public Canvas selectLevel;
    public ball_launcher BL;
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null)
        {
            anim = this.gameObject.GetComponent<Animator>();
        }
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }

        BL.disparado = true;
        BL.iniciar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.enabled == false) {
            anim.enabled = true;
        }

        if (anim.gameObject.activeSelf == false) {
            anim.gameObject.SetActive(true);
        }
    }

    //funciones para quitar y poner las pantallas de UI del juego

    public void fade_out_Main_menu() {
        anim.SetTrigger("fade-out");
        Invoke("disable_mm", 0.6f);
        //habilitar el disparo de las pelotas
        BL.disparado = false;
        BL.iniciar = true;
    }

    public void fade_in_main() {
        anim.SetTrigger("fade-out");
        Invoke("enable_mm", 0.6f);
        //deshabilitar el disparo de las pelotas
        BL.disparado = true;
        BL.iniciar = false;
    }

    public void fade_out_NL()
    {
        anim.SetTrigger("fade-out");
        Invoke("disable_nl", 0.6f);
        BL.disparado = false;
        BL.iniciar = true;
    }

    public void quit_NL() {
        anim.SetTrigger("fade-out");
        Invoke("disable_nl", 0.6f);
    }

    public void fade_in_NL()
    {
        anim.SetTrigger("fade-out");
        Invoke("enable_nl", 0.6f);
        BL.disparado = true;
        BL.iniciar = false;
    }

    public void fade_out_lf()
    {
        anim.SetTrigger("fade-out");
        Invoke("disable_lf", 0.6f);
        BL.disparado = false;
        BL.iniciar = true;
    }

    public void quit_LF()
    {
        anim.SetTrigger("fade-out");
        Invoke("disable_lf", 0.6f);
    }

    public void fade_in_lf()
    {
        anim.SetTrigger("fade-out");
        Invoke("enable_lf", 0.6f);
        BL.disparado = true;
        BL.iniciar = false;
    }

    public void fade_in_Sl()
    {
        for (int i = 0; i <= BL.LM.max_level; i++)
        {
            levels[i].SetActive(true);
        }
        anim.SetTrigger("fade-out");
        Invoke("enable_sl", 0.6f);
        BL.disparado = true;
        BL.iniciar = false;
    }

    public void fade_out_sl()
    {
        anim.SetTrigger("fade-out");
        Invoke("disable_sl", 0.6f);
        BL.disparado = false;
        BL.iniciar = true;
    }

    //funciones para habilitar o deshabilitar el canvas del UI

    public void disable_mm() {
        MainMenu.enabled = false;
    }

    public void enable_mm()
    {
        MainMenu.enabled = true;
    }

    public void disable_nl()
    {
        NextLevel.enabled = false;
    }

    public void enable_nl()
    {
        NextLevel.enabled = true;
    }

    public void disable_lf()
    {
        LevelFailed.enabled = false;
    }

    public void enable_lf()
    {
        LevelFailed.enabled = true;
    }

    public void disable_sl()
    {
        selectLevel.enabled = false;
    }

    public void enable_sl()
    {
        selectLevel.enabled = true;
    }
}
