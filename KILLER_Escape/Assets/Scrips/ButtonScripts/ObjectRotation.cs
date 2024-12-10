using System;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject CardImage;
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float rotAngle;

    [NonSerialized]
    public bool startRotation = false;

    private float variation;
    private float rot;

    void Start()
    {
        variation = Mathf.Abs(rotAngle) / speed * Mathf.Sign(rotAngle);
    }

    void Update()
    {
        if (startRotation)
        {
            CardImage.transform.Rotate (0, 0, variation * Time.deltaTime);
            rot += variation * Time.deltaTime;
            if (Mathf.Abs(rot) >= Mathf.Abs(rotAngle)) 
            {
                startRotation = false;
                CardImage.transform.localRotation = Quaternion.Euler (0, 0, 0);
            }
        }
    }
}
