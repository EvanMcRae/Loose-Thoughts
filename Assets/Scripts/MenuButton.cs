using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject marker;
    private bool selected;

    public void OnButtonSelect()
    {
        selected = true;
        marker.SetActive(true);
    }

    public void OnButtonDeselect()
    {
        selected = false;
        marker.SetActive(false);
    }

    public void OnPointerEnter()
    {
        if (selected) return;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
