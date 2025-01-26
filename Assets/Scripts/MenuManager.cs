using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject settingsButton, settingsExit, settingsPanel;
    public GameObject creditsButton, creditsExit, creditsPanel;
    private GameObject selected;
    public static bool busy = false, panelJustClosed = true;
    [SerializeField] private AK.Wwise.Event StartSound;
    public GameObject WwiseGlobal;


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

    void LateUpdate()
    {
        panelJustClosed = false;
    }

    public void StartGame()
    {
        if (!busy)
        {
            Crossfade.current.StartFadeWithAction(Play);
            busy = true;
            StartSound?.Post(WwiseGlobal);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        busy = false;
    }

    public void Settings()
    {
        if (busy) return;
        settingsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsExit);
    }

    public void ExitSettings()
    {
        SettingsManager.SaveSettings();
        settingsPanel.SetActive(false);
        panelJustClosed = true;
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }

    public void Credits()
    {
        if (busy) return;
        creditsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsExit);
    }

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(creditsButton);
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
        SettingsManager.SaveSettings();
    }
}
