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

    // A,Dキーまたはマウスカーソルでカードボタンが選択状態かどうかを判断
    private bool IsHighlighted()
    {
        return EventSystem.current.currentSelectedGameObject == CardButton.gameObject ||
               EventSystem.current.IsPointerOverGameObject() &&
               //EventSystem.current.currentSelectedGameObject == null && 本来はこれを入れないとマウス/キーボード操作を分けられないが、利便性のため無力化
               RectTransformUtility.RectangleContainsScreenPoint(
                CardButton.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main);
    }
    
    // ボタンを押している状態かどうかを判断
    private bool IsPressed()
    {
        return Input.GetMouseButton(0) && IsHighlighted();
    }

    // カードイメージの色更新
    private void UpdateCardImagesColor(Color color)
    {
        foreach(var cardImage in CardImages)
        {
            cardImage.color = color;
        }
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
        if(!CardButton.interactable)
        {
            // ボタンが無効状態
            UpdateCardImagesColor(disabledColor);
        }
        else if(IsPressed())
        {
            // ボタンが押された状態
            UpdateCardImagesColor(pressedColor);
        }
        else if(IsHighlighted())
        {
            // ボタンが選択状態
            UpdateCardImagesColor(highlightedColor);
        }
        else
        {
            // 通常状態
            UpdateCardImagesColor(normalColor);
        }
    }
}
