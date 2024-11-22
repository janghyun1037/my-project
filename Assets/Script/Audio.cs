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
            masterMixer.SetFloat("BGM", -80);   //-40���� -80���� ���� ������ �Ҹ��� ���ֱ� ����
        }
        else
        {
            masterMixer.SetFloat("BGM", sound); //�׿��� ���ǵ��� �Ҹ��� �°� ����
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
