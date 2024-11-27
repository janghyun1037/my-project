using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-------------Audio Source------------")]
    [SerializeField] AudioSource musicSource;

    [Header("-------------Audio Clip------------")]
    public AudioClip MainTHeme;     //������ �ΰ����� ���� �߿��ϱ��� �ٵ� �׷��ٰ� �����׸��� �����⿣ �Ʊ��.....
    public AudioClip inGameTheme;   //�������� �����? �̰� ������� ������ ������? ����.......

    private void Start()
    {
        musicSource.clip = MainTHeme;
        musicSource.Play();
    }
}
