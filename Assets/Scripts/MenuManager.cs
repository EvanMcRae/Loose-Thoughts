using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject selected;
    public static bool busy = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(startButton);
        selected = startButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != selected)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(selected);
            else
                selected = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void StartGame()
    {
        if (!busy)
        {
            Crossfade.current.StartFadeWithAction(Play);
            busy = true;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        busy = false;
    }

    public void Settings()
    {
        // TODO
        Debug.Log("open settings");
    }

    public void Credits()
    {
        // TODO
        Debug.Log("open credits");
    }

    public void QuitGame()
    {
        if (!busy)
        {
            Crossfade.current.StartFadeWithAction(ExitGame);
        }
        busy = true;
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnApplicationQuit()
    {
        // SettingsManager.SaveSettings();
    }
}
