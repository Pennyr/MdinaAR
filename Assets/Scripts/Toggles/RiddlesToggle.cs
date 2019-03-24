using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddlesToggle : MonoBehaviour {

    public GameObject Menu;

    public void ShowMenu()
    {
        Debug.Log("Toggled");

        Menu.SetActive(true);

    }

    public void HideMenu()
    {
        Debug.Log("Toggled");

        Menu.SetActive(false);

    }
}
