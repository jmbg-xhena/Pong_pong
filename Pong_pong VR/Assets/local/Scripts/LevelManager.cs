using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float bounce = 1;
    public float force = 10;
    public PhysicMaterial PHmat;
    public ball_launcher BL;
    public Animator[] levels;
    public int levelIndex=-1;
    public int max_level;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("level", 0);
        max_level =PlayerPrefs.GetInt("level");
        PHmat.bounciness = bounce;
    }

    // Update is called once per frame
    void Update()
    {
        //actualizar en tiempo real el valor de rebote del material físico de las pelotas
        bounce_check();
    }

    public void reset_levels() {
        if (levelIndex != -1)
        {
            levels[levelIndex].SetTrigger("pool_out");
        }
        levelIndex =-1;
    }

    public void next_level()
    {
        //checa que el nivel sea valido el nivel que se va a sacar
        if (levelIndex != -1)
        {
            levels[levelIndex].SetTrigger("pool_out");
        }
        levelIndex += 1;
        if (levelIndex > max_level) {
            max_level = levelIndex;
            PlayerPrefs.SetInt("level", max_level);
        }
        levels[levelIndex].ResetTrigger("pool_out");
        levels[levelIndex].SetTrigger("pool_in");
        level_change();
    }

    public void Retry() {
        //reiniciar los valores del nivel
        level_change();
    }

    //iniciar el juego en el primer nivel
    public void Start_game() {
        levelIndex = -1;
        next_level();
    }

    //sacar nivel actual
    public void poolOut() {
        if (levelIndex >= 0)
        {
            levels[levelIndex].SetTrigger("pool_out");
        }
        else {
            levelIndex += 1;
            poolOut();
        }
    }

    //meter nivel actual
    public void poolIn()
    {
        if (levelIndex >= 0)
        {
            levels[levelIndex].SetTrigger("pool_in");
            level_change();
        }
        else
        {
            levelIndex += 1;
            poolIn();
        }
    }

    //meter nivel específico válido
    public void poolInLevel(int lvl) {
        if (lvl >= 0)
        {
            levelIndex = lvl;
            levels[lvl].SetTrigger("pool_in");
            level_change();
        }
        else
        {
            poolInLevel(lvl + 1);
        }
    }

    //actualizar los valores del nivel cargado
    public void level_change() {
        if (levelIndex==0)
        {
            bounce = 0.3f;
            BL.launch_speed = 23;
            BL.No_balls = 10;
        }
        if (levelIndex == 1)
        {
            bounce = 0.8f;
            BL.launch_speed = 24f;
            BL.No_balls = 10;
        }
        if (levelIndex == 2)
        {
            bounce = 1f;
            BL.launch_speed = 22f;
            BL.No_balls = 10;
        }
        if (levelIndex == 3)
        {
            bounce = 1f;
            BL.launch_speed = 24f;
            BL.No_balls = 10;
        }

    }

    public void bounce_check()
    {
        if (bounce > 1)
        {
            bounce = 1;
        }
        if (bounce < 0)
        {
            bounce = 0;
        }
        if (PHmat.bounciness != bounce)
        {
            PHmat.bounciness = bounce;
        }
    }
}
