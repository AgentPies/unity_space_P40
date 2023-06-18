using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthSlider : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;

    public void ChangeWidth(float newWidth)
    {
        // Changes the width of the room
        WFC.roomsInRow = (int)newWidth;
    }

    // Start is called before the first frame update
    void Start()
    {
        WFC.roomsInRow = 2;
        slider.onValueChanged.AddListener(ChangeWidth);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WFC.roomsInRow);
    }
}
