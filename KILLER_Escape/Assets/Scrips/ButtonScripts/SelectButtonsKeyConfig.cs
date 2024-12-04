using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButtonsKeyConfig : MonoBehaviour
{
    public Button[] buttons;// 操作対象のボタンを設定
    private int currentButtonsIndex = 0;// 現在選択中のボタンのインデックス

    private void SelectButton(int index)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    void Start()
    {
        if (buttons.Length > 0)
        {
            SelectButton(currentButtonsIndex);
        }
    }

    void Update()
    {
        // Aキーで左のボタンに移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentButtonsIndex = (currentButtonsIndex - 1 + buttons.Length) % buttons.Length;
            SelectButton(currentButtonsIndex);
        }

        // Dキーで右のボタンに移動
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentButtonsIndex = (currentButtonsIndex + 1) % buttons.Length;
            SelectButton(currentButtonsIndex);
        }

        // スペースキーでボタンをクリック
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttons[currentButtonsIndex].onClick.Invoke();
        }
    }
}
