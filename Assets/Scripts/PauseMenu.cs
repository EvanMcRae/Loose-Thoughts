using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuContainer, unpauseButton;
    public static bool paused = false, busy = false, inSettings = false;
    public AK.Wwise.Event pause, unpause, stop, menuClick, menuBack;
    public GameObject WwiseGlobal, blurVolume;
    public GameObject settingsButton, settingsExit, settingsPanel;
    private GameObject selected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Crossfade.over && !busy)
        {
            if (paused)
            {
                if (inSettings)
                    ExitSettings();
                else
                    UnPause();
            }
            else
            {
                Pause();
            }
        }
        
        if (paused)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                selected = EventSystem.current.currentSelectedGameObject;
            }
            else 
            {
                EventSystem.current.SetSelectedGameObject(selected);
            }
        }
    }

    void LateUpdate()
    {
        MenuManager.panelJustClosed = false;
    }

    public void UnPause(bool user = false)
    {
        if (busy)
            stop?.Post(WwiseGlobal);
        else
        {
            if (user)
                menuClick?.Post(WwiseGlobal);
            unpause?.Post(WwiseGlobal);
        }
        blurVolume.GetComponent<Volume>().weight = 0;
        Time.timeScale = 1;
        menuContainer.SetActive(false);
        paused = false;
    }

    void Pause()
    {
        if (busy) return;
        pause?.Post(WwiseGlobal);
        blurVolume.GetComponent<Volume>().weight = 1;
        Time.timeScale = 0;
        menuContainer.SetActive(true);
        EventSystem.current.SetSelectedGameObject(unpauseButton);
        paused = true;
    }

    public void Return()
    {
        menuClick?.Post(WwiseGlobal);
        Crossfade.current.StartFadeWithAction(GoToMenu);
        menuContainer.SetActive(false);
        busy = true;
        UnPause();
    }

    void GoToMenu()
    {
        busy = false;
        SceneManager.LoadScene("MainMenu");
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
        menuBack?.Post(WwiseGlobal);
        inSettings = false;
        SettingsManager.SaveSettings();
        settingsPanel.SetActive(false);
        MenuManager.panelJustClosed = true;
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }
}
