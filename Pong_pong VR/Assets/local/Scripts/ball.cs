using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public AudioSource aud;
    // Start is called before the first frame update
    private void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        aud.PlayOneShot(aud.clip);
        if (collision.transform.CompareTag("goal")) {
            //congelar la pelota para que no se salga cuando el jugador gane
            gameObject.GetComponent<Rigidbody>().isKinematic=true;
        }
    }
}
