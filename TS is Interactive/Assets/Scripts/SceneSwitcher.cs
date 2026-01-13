using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private static SceneSwitcher instance;

    public string scene1 = "Scene1";
    public string scene2 = "Scene2";
    public string scene3 = "Scene3";
    public string scene4 = "Scene4";
    public string scene5 = "Scene5";
    public string scene6 = "Scene6";
    public bool switchScene = false;
    Scene currentScene;

    private void Awake()
    {
        // Prevent duplicates when loading new scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(scene1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(scene2);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(scene3);
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene(scene4);
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene(scene6);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }


    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (switchScene)
        {
            if (currentScene.name == scene5)
                LoadScene1();
            else if (currentScene.name == scene1)
                LoadScene2();
            else if (currentScene.name == scene2)
                LoadScene3();
            else if (currentScene.name == scene3)
                LoadScene4();
            else if (currentScene.name == scene4)
                LoadScene5();


        }
        switchScene = false;
    }


}
