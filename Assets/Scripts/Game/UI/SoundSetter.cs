using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetter : MonoBehaviour
{
    Scrollbar selfScrollbar;
    void Start()
    {
        Beatmaker.volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        selfScrollbar = GetComponent<Scrollbar>();
        selfScrollbar.value = Beatmaker.volume;
    }

    public void SetVolume() {
        Beatmaker.volume = selfScrollbar.value;
        PlayerPrefs.SetFloat("Volume", selfScrollbar.value);
        PlayerPrefs.Save();
    }
}
