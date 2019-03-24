using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserAccess : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public InputField rePasswordField;
    public TextMeshProUGUI userMessage;


    public Button submitButton;

    public void VerifyInput()
    {
        submitButton.interactable = (userNameField.text.Length >= 8 && passwordField.text.Length >= 8 && rePasswordField.text.Length >= 8);
    }

    public void OnSubmitLogin()
    {
        string json = ObjSerDes.serialize((new ObjPlayer(SystemInfo.deviceUniqueIdentifier, userNameField.text, passwordField.text)));
  
        int response = ObjSerDes.getUserAccessResponse(json);// Request server Login
        if (response == 1)
        {
            // Incorrect password
            LoginError("Your Password is Incorrect");
        }
        else if (response == 0)
        {
            // Succesful login
            LoginError("Login is Sucessful!!");

        }
        else
        {
            LoginError("Connection Lost");
        }
    }

    public void OnSubmitRegister()
    {
        if(string.Compare(passwordField.text, rePasswordField.text) == 0 )
        {
            string json = ObjSerDes.serialize((new ObjPlayer(SystemInfo.deviceUniqueIdentifier, userNameField.text, passwordField.text)));

            int response = ObjSerDes.getUserAccessResponse();// Request server Register
            if (response == 2) 
            {

                // Incorrect password
                RegisterError("Your Password is Incorrect");
            }
            else if (response == 1)
            {
                // User Exists
                RegisterError("User Already Exists");
            }
            else if(response == 0)
            {
                // Succesful Registration
                RegisterError("Registration Is Succesful!!");
            }
            else
            {
                RegisterError("Connection Lost");
            }
        }
        else
        {
            // Passwords Do not Match
            RegisterError("Password must match!!");
        }
    }


    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

    public void RegisterError(string msg)
    {
        userMessage.gameObject.GetComponent<Text>().text = msg;
        Delay();

        userMessage.gameObject.GetComponent<Text>().text = "";

        passwordField.text = "";
        rePasswordField.text = "";
    }

    public void LoginError(string msg)
    {
        userMessage.gameObject.GetComponent<Text>().text = msg;
        Delay();

        userMessage.gameObject.GetComponent<Text>().text = "";

        passwordField.text = "";
    }
}
