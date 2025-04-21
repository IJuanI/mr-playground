using System.Collections.Generic;
using UnityEngine;

public class AudioSourceMultiClip : MonoBehaviour
{
    [SerializeField]bool useFadeVolume = false;
    [SerializeField]float timingFade;
    [SerializeField]AudioSource source;
    [SerializeField]List<AudioClip> listOfClips = new();
    

    public void Play(int index)
    {
        source.PlayOneShot(listOfClips[index]);
    }

    void Update()
    {
        if(useFadeVolume)
        {
            source.volume += Time.deltaTime/timingFade;
        }
    }
}
