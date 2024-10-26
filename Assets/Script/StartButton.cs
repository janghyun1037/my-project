using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬을 넘어가기 위한 using

public class StartButton : MonoBehaviour
{   public void onClickNewGame()
    {
        SceneManager.LoadScene("In Game");//씬 넘어가는 코드
    }
}
