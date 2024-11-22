using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{

    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);   //-40에서 -80으로 가는 이유는 소리를 없애기 위해
        }
        else
        {
            masterMixer.SetFloat("BGM", sound); //그외의 조건들은 소리에 맞게 조정
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
