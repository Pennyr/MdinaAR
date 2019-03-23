using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddlesToggle : MonoBehaviour {

    public GameObject Menu;

    public void ToggleMenu()
    {
        Debug.Log("Toggled" + Menu.activeSelf + " => " + !Menu.activeSelf);

        Menu.SetActive(!Menu.activeSelf);

    }
}
