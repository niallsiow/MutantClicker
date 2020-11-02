using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button clickButton;
    public Button clickerButton;
    public Button clickyClickerButton;


    public Text textBox;

    private float counter = 0;
    private int clickers = 0;
    private int clickyClickers;


    float timeBetweenAutoClicks = 1f;
    float timeSinceAutoClicks = 0f;


    float timeBetweenAutoClickUpdates = 0.1f;
    float timeSinceAutoClickUpdates = 0f;


    float test = 12.5f;

    int clickersCost = 10;
    int clickyClickersCost = 100;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Sacrifices: " + counter.ToString();

        clickButton.onClick.AddListener(() => ButtonClicked(1));

        clickerButton.onClick.AddListener(() => ClickerButtonClicked());

        clickyClickerButton.onClick.AddListener(() => ClickyClickerButtonClicked());
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Clicks: " + Mathf.RoundToInt(counter).ToString();


        // smoothly updates the value of counter
        if(Time.time > timeSinceAutoClickUpdates)
        {
            timeSinceAutoClickUpdates = Time.time + timeBetweenAutoClickUpdates;
            counter = counter + (1 * ((float)clickers / 10f));
            counter = counter + (10 * ((float)clickyClickers / 10f));
        }
        

        Debug.Log(counter);
    }

    void ButtonClicked(int buttonNo)
    {
        counter++;
    }

    void ClickerButtonClicked()
    {
        if(counter >= clickersCost)
        {
            clickers++;
            counter = counter - 10;

            setNewClickerCost(ref clickersCost, 1, clickerButton, 1);
        }
    }

    void ClickyClickerButtonClicked()
    {
        if(counter >= clickyClickersCost)
        {
            clickyClickers++;
            counter = counter - 100;

            setNewClickerCost(ref clickyClickersCost, 10, clickyClickerButton, 10);
        }
    }

    //Pass current clicker cost as a reference, provide modifier to add on and button reference. Set value accordingly and change text.
    //Currently to change text the rate also has to come through as a parameter. Might try and find a workaround.
    bool setNewClickerCost(ref int cost, int modifier, Button button, int rate)
    {
        cost = cost + modifier;

        button.GetComponentInChildren<Text>().text = "Buy " + button.name + " (Cost = " + cost + " clicks)\n (" + rate + " click/s)";
        return true;
    }

}
