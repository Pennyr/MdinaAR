using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsToggle : MonoBehaviour {

    public GameObject Menu;

    public void ToggleMenu()
    {
        Debug.Log("Toggled" + Menu.activeSelf+" => "+ !Menu.activeSelf);
        
        Menu.SetActive(!Menu.activeSelf);
        
    }
}
