using UnityEngine;
using UnityEngine.EventSystems;

public interface IMenuButton
{
    void OnMouseHoverOrExit();
    void OnClicked();
}
