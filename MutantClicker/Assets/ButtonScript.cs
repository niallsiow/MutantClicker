using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button clickButton;
    public Button autoClickerButton;


    public Text textBox;

    private int counter = 0;
    private int autoClickers = 0;


    float timeBetweenAutoClicks = 1f;
    float timeSinceAutoClicks = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Sacrifices: " + counter.ToString();

        clickButton.onClick.AddListener(() => ButtonClicked(1));

        autoClickerButton.onClick.AddListener(() => AutoClickerButtonClicked());
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Sacrifices: " + counter.ToString();

        if(Time.time > timeSinceAutoClicks)
        {
            timeSinceAutoClicks = Time.time + timeBetweenAutoClicks;
            counter = counter + (1 * autoClickers);
        }
    }

    void ButtonClicked(int buttonNo)
    {
        counter++;
    }

    void AutoClickerButtonClicked()
    {
        if(counter > 10)
        {
            autoClickers++;
            counter = counter - 10;
        }
    }
}
