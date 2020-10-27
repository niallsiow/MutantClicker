using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button clickButton;
    public Button autoClickerButton;


    public Text textBox;

    private float counter = 0;
    private int autoClickers = 0;


    float timeBetweenAutoClicks = 1f;
    float timeSinceAutoClicks = 0f;


    float timeBetweenAutoClickUpdates = 0.1f;
    float timeSinceAutoClickUpdates = 0f;


    float test = 12.5f;

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
        textBox.text = "Sacrifices: " + Mathf.RoundToInt(counter).ToString();


        // smoothly updates the value of counter
        if(Time.time > timeSinceAutoClickUpdates)
        {
            timeSinceAutoClickUpdates = Time.time + timeBetweenAutoClickUpdates;
            counter = counter + (1 * ((float)autoClickers / 10f));
        }
        

        Debug.Log(counter);
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
