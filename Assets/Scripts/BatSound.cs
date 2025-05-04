using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSound : MonoBehaviour
{
    public GameObject emisor;
    public AudioClip snd_hit, snd_swing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                emisor.GetComponent<Transform>().position = hit.point;
                emisor.GetComponent<AudioSource>().clip = snd_swing;
                emisor.GetComponent<ResonanceAudioSource>().audioSource.Play();
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        emisor.GetComponent<AudioSource>().clip = snd_hit;
        emisor.GetComponent<Transform>().position = col.transform.position;
        emisor.GetComponent<ResonanceAudioSource>().audioSource.Play();
    }
}
