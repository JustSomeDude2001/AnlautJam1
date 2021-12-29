using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuBoombox : MonoBehaviour
{

    AudioSource selfSource;
    void Start()
    {
        selfSource = GetComponent<AudioSource>();
    }
    
    private void Update() {
        selfSource.volume = Beatmaker.volume;
    }
}
