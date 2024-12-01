using UnityEngine;
using UnityEngine.SceneManagement;

public class MainAudioManager : MonoBehaviour
{
    [Header("-------------Audio Source------------")]
    [SerializeField] AudioSource musicSource;

    [Header("-------------Audio Clip------------")]
    public AudioClip MainTheme;     //������ �ΰ����� ���� �߿��ϱ��� �ٵ� �׷��ٰ� �����׸��� �����⿣ �Ʊ��.....
    public AudioClip inGameTheme;   //�������� �����? �̰� ������� ������ ������? ����.......

    private void Start()
    {
        musicSource.clip = MainTheme;
        musicSource.Play();
    }
}
