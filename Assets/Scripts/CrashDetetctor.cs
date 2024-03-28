using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetetctor : MonoBehaviour
{
    [SerializeField] float loadTiming = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashOneTime = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !crashOneTime)
        {
            crashOneTime = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadTiming);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
