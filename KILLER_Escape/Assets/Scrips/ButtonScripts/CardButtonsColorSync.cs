using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardButtonsColorSync : MonoBehaviour
{
    public Button CardButton;
    public Image[] CardImages;

    // 通常の色
    private Color normalColor;

    // 選択時の色
    private Color highlightedColor;

    // 決定時の色
    private Color pressedColor;

    // 無効時の色
    private Color disabledColor;

    private bool IsHighlighted()
    {
        return EventSystem.current.currentSelectedGameObject == CardButton.gameObject ||
               EventSystem.current.IsPointerOverGameObject() &&
               EventSystem.current.currentSelectedGameObject == null &&
               RectTransformUtility.RectangleContainsScreenPoint(
                CardButton.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main);
    }
    
    void Start()
    {
        ColorBlock colors = CardButton.colors;
        normalColor = colors.normalColor;
        highlightedColor = colors.highlightedColor;
        pressedColor = colors.pressedColor;
        disabledColor = colors.disabledColor;
    }


    void Update()
    {
        
    }
}
