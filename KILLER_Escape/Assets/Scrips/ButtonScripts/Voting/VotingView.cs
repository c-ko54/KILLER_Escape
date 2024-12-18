using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class VotingView : MonoBehaviour
{
    [SerializeField] private List<Button> playerButtons;
    [SerializeField] private Button skipButton;

    public IReadOnlyReactiveProperty<float> Sensitivity => _sensitivity;
    private readonly FloatReactiveProperty _sensitivity = new FloatReactiveProperty(1.0f);
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < playerButtons.Count; i++)
        {
            int index = i; // ローカル変数にインデックスを保存
            playerButtons[i].onClick.AddListener(() => OnPlayerButtonClick(index));
        }
        skipButton.onClick.AddListener(() => OnSkipButtonClick());
    }

    private void OnPlayerButtonClick(int index)
    {
        Debug.Log("Button " + index + " was clicked!");
        // 何番目のボタンがクリックされたかを取得

    }

    private void OnSkipButtonClick()
    {
        Debug.Log("Skip button was clicked!");
        // スキップボタンがクリックされたときの処理
    }
}
