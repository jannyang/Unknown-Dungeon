using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public int sceneNum = 0;

    public void SceneLoad()
    {
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
    }
}
