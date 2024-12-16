using UnityEngine;
using UnityEngine.UI;

public class CardButtonClickListener : MonoBehaviour
{
    private Button cardButton;

    [SerializeField]
    private GameObject[] CardImage;
    [SerializeField]
    private GameObject[] CardBackImage;
    [SerializeField]
    private Liner[] liner;
    [SerializeField]
    private ObjectRotation[] rotations;


    void onButtonClick()
    {
        for (int i = 0; i < CardImage.Length; i++)
        {
            liner[i].startLiner = true;
            rotations[i].startRotation = true;
            if(CardBackImage[i].activeSelf == true)
            {
                CardBackImage[i].SetActive(false);
            }
        }
    }

    void Start()
    {
        cardButton = GetComponent<Button>();
        cardButton.onClick.AddListener(onButtonClick);
    }
}
