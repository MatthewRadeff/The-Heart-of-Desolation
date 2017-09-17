using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// code by: Matthew C. Radeff

public class ButtonScript : MonoBehaviour
{

    // passes a string into load scene, which goes to that specific scene
    public void ChangeScene(string m_sceneName)
    {
        SceneManager.LoadScene(m_sceneName);
    }


    // shuts the application down
    public void QuitGame()
    {
        Application.Quit();

    }


}
