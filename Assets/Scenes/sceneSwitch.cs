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
            if (PlayerPrefs.GetInt("isLearnt", 0) == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
	
	public void QuitButton()
	{
		Debug.LogWarning("Application Quit");
		Application.Quit();
	}

}
