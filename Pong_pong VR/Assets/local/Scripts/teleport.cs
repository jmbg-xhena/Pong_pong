using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player;
    public GvrReticlePointer pointer;
    public Transform goal;
    public ParticleSystem effect;

    bool isTeleporting;
    // Start is called before the first frame update
    void Start()
    {
        effect.Stop();
    }

    // Update is called once per frame
    public void TeleportEnter()
    {
        pointer.GetComponent<MeshRenderer>().material.color = Color.blue;
        effect.Play();
    }

    public void TeleportClick() {
        if (!isTeleporting) {
            isTeleporting = true;
            StartCoroutine(IETeleport());
        }
    }

    public void TeleportExit() {
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
        effect.Stop();
    }

    IEnumerator IETeleport() {
        SRC_Fade.instance.Fading();
        yield return new WaitForSeconds(SRC_Fade.instance.FadeDUration);
        player.transform.position = goal.transform.position;
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
        gameObject.SetActive(false);
        isTeleporting = false;
    }
}
