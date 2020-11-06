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


    // potential idea for organising this is to either 1.  attach a generic script to each clicker button to handle this stuff or 2. make an array of stuff to do comparisons or something

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

            clickerButton.GetComponentInChildren<BuyButtonScript>().setNewClickerCost(ref clickersCost, 1);
        }
    }

    void ClickyClickerButtonClicked()
    {
        if(counter >= clickyClickersCost)
        {
            clickyClickers++;
            counter = counter - 100;

            clickyClickerButton.GetComponentInChildren<BuyButtonScript>().setNewClickerCost(ref clickyClickersCost, 10);
        }
    }

}
