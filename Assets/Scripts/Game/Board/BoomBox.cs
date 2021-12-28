using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BoomBox : MonoBehaviour
{
    public List<AudioClip> clips;
    public List<float> lengths;

    public AudioClip GetClip(int index) {
        if (index < 0) {
            return clips[0];
        }
        if (index >= clips.Count) {
            return clips[clips.Count - 1];
        }
        return clips[index];
    }

    public float GetLength(int index) {
        if (index < 0) {
            return lengths[0];
        }
        if (index >= clips.Count) {
            return lengths[lengths.Count - 1];
        }
        return lengths[index];
    }
}
