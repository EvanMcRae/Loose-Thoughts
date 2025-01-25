using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject selected;
    public static MenuManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Menu singleton
        if (instance != this && instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(this);

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
}
