using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StageA");
    }
}
