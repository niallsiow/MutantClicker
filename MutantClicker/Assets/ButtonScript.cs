using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public Text textBox;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Sacrifices: " + counter.ToString();

        button.onClick.AddListener(() => ButtonClicked(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked(int buttonNo)
    {
        counter++;
        textBox.text = "Sacrifices: " + counter.ToString();
    }
}
