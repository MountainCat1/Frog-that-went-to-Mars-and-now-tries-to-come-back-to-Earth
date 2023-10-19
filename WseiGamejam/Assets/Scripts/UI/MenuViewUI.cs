using UnityEngine;
using UnityEngine.EventSystems;

public class MenuViewUI : MonoBehaviour
{
    [SerializeField] private GameObject defaultSelected;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(defaultSelected);
    }
}
