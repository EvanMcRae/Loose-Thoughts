using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerMoveHandler
{
    public GameObject marker;
    public GameObject WwiseGlobal;
    [SerializeField] private AK.Wwise.Event MenuNav;
    private bool selected;

    public static bool noSound = false, pleaseNoSound = false;

    public void OnButtonSelect()
    {
        if (noSound || pleaseNoSound)
        {
            noSound = false;
            return;
        }
        if (MenuManager.firstopen && !MenuManager.busy)
        {
            MenuNav?.Post(WwiseGlobal);
        }
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
        if (selected || MenuManager.panelJustClosed) return;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (eventData.hovered.Contains(gameObject) && EventSystem.current.currentSelectedGameObject != gameObject)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
