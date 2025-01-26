using UnityEditor;
using UnityEditor.SceneManagement;
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
    private bool inSettings = false, inCredits = false;

    [SerializeField] private AK.Wwise.Event StartSound, menuBack, menuClick;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inSettings)
            {
                ExitSettings();
            }
            else if (inCredits)
            {
                ExitCredits();
            }
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
            menuClick?.Post(WwiseGlobal);
            Crossfade.current.StartFadeWithAction(Play);
            busy = true;
            StartSound?.Post(WwiseGlobal);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("IntroCutscene");
        busy = false;
    }

    public void Settings()
    {
        if (busy) return;
        inSettings = true;
        menuClick?.Post(WwiseGlobal);
        settingsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsExit);
    }

    public void ExitSettings()
    {
        inSettings = false;
        SettingsManager.SaveSettings();
        settingsPanel.SetActive(false);
        menuBack?.Post(WwiseGlobal);
        panelJustClosed = true;
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }

    public void Credits()
    {
        if (busy) return;
        inCredits = true;
        menuClick?.Post(WwiseGlobal);
        creditsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(creditsExit);
    }

    public void ExitCredits()
    {
        inCredits = false;
        creditsPanel.SetActive(false);
        menuBack?.Post(WwiseGlobal);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void QuitGame()
    {
        if (!busy)
        {
            menuClick?.Post(WwiseGlobal);
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
