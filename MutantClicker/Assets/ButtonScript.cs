using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => ButtonClicked(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("button clicked");
    }
}
