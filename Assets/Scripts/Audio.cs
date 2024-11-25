using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audios;
    [SerializeField] private AudioSource audiod;
    public bool audio2;
    public bool audio3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(audio2 == true)
        {
            audio2 = false;
            audios.Play();
        }
        if(audio3 == true)
        {
            audio3 = false;
            audiod.Play();
        }
    }
}
