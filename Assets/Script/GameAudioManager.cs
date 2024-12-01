using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    [Header("-------------Audio Source------------")]
    [SerializeField] AudioSource musicSource;

    [Header("-------------Audio Clip------------")]
    public AudioClip MainTheme;     //������ �ΰ����� ���� �߿��ϱ��� �ٵ� �׷��ٰ� �����׸��� �����⿣ �Ʊ��.....
    public AudioClip inGameTheme;   //�������� �����? �̰� ������� ������ ������? ����.......

    private void Start()
    {
        musicSource.Stop();
        musicSource.clip = inGameTheme;
        musicSource.Play();
    }
}
