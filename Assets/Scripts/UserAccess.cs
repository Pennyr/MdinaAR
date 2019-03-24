using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserAccess : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;

    public Button submitButton;

    public void VerifyInput()
    {
        submitButton.interactable = (userNameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
