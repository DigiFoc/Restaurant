using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public void SwitchScene(string name)
    {
        if (name == "main")
        {
            SceneManager.LoadScene(0);
        }
        if (name == "game")
        {
            SceneManager.LoadScene(1);
        }
    }
	
	public void QuitButton()
	{
		Debug.LogWarning("Application Quit");
		Application.Quit();
	}

}
