using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-------------Audio Source------------")]
    [SerializeField] AudioSource musicSource;

    [Header("-------------Audio Clip------------")]
    public AudioClip MainTHeme;     //솔직히 인게임이 제일 중요하긴해 근데 그렇다고 메인테마를 버리기엔 아까워.....
    public AudioClip inGameTheme;   //선배한테 물어볼까? 이건 물어봐도 ㄱㅊ지 않을까? 쓰읍.......

    private void Start()
    {
        musicSource.clip = MainTHeme;
        musicSource.Play();
    }
}
