using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void play(){
        Debug.Log("Loading scene...");
        /*
            Use LoadSceneMode.Additive as second argument to load the new scene without replacing the current one.
            SceneManager.LoadScene() // replaces the current scene instead of adding it to new one, take it in mind.
        */
        SceneManager.LoadScene(Utils.Scenes.GameScene.ToString());
    }

    public void exit(){
        Debug.Log("Exit");
        Application.Quit();
    }
}
