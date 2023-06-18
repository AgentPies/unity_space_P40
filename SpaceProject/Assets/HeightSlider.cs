using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightSlider : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;

    public void ChangeHeight(float newHeight)
    {
        // Changes the width of the room
        WFC.roomsInColumn = (int)newHeight;
    }

    // Start is called before the first frame update
    void Start()
    {
        WFC.roomsInColumn = 2;
        slider.onValueChanged.AddListener(ChangeHeight);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WFC.roomsInRow);
    }
}
