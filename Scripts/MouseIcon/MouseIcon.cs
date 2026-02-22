using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScpMouseIcon : MonoBehaviour
{
    public RectTransform cursorUI; // arraste sua Image aqui
    
    private void Awake()
    {
        ShowCustomMouse();
    }

    void Update()
    {
        ControlMousePosition();
    }
    private void ShowCustomMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
    private void ControlMousePosition()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            cursorUI.parent as RectTransform,
            Mouse.current.position.ReadValue(),
            null, // ou Camera.main se Canvas não for Overlay
            out mousePos
        );
        cursorUI.localPosition = mousePos;
    }
}
