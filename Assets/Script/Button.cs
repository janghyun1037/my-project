using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���� �Ѿ�� ���� using

public class Button : MonoBehaviour
{   public void onClickNewGame()
    {
        SceneManager.LoadScene("In Game");//�� �Ѿ�� �ڵ�
    }
}
