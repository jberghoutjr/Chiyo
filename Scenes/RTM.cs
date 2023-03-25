using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RTM : MonoBehaviour
{
    public void OnReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}
