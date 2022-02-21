using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateFeedback : MonoBehaviour
{
    public void Rate()
    {
        Application.OpenURL("market://details?id=.......(Play Store package name).........");
    }

    public void Feedback()
    {
        Application.OpenURL("mailto:casualgamesdev@gmail.com ");
    }
}
