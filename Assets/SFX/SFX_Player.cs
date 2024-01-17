using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Player : MonoBehaviour
{

    ParticleSystem ps;
    AudioSource asrc;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        asrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {

            StartCoroutine(timer());
            
        }
    }

    IEnumerator timer()
    {

        if (!asrc.isPlaying)
        {
            asrc.Play();
        }

        yield return new WaitForSeconds(0.5f);

        StopAllCoroutines();

    }
}
