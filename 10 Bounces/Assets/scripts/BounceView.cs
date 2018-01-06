using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Contains all views related to the app
public class BounceView : BounceElement {

    // Reference to the ball and counting text
    public BallView ball;
    public Text countText;

    public void SetCountText()
    {
        countText.text = "Bounces: " + App.model.GetBounces().ToString();
    }
    
}
