using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls the app workflow
public class BounceController : BounceElement {

    /* Alternative, perhaps messier inmplementation of the notification system minimized here
     * 
	// Handles the 'ball hitting ground' event
    public void OnBallGroundHit()
    {
        App.model.bounces++;
        Debug.Log("Bounce " + App.model.bounces);

        if(App.model.bounces >= App.model.winCondition)
        {
            App.view.ball.enabled = false;
            // Stops the ball from bouncing
            App.view.ball.GetComponent<Rigidbody>().isKinematic = true;
            OnGameComplete();
        }
    }

    // Handles the win condition
    public void OnGameComplete()
    {
        Debug.Log("Victory!");
    } */
    // Notification system to control the game as changes occur
    public void OnNotification(string eventPath, Object target, params object[] data)
    {
        switch(eventPath)
        {
            case BounceNotification.BallHitGround:
                int curBounces = App.model.GetBounces();

                App.model.SetBounces(curBounces + 1);
                App.view.SetCountText();
                Debug.Log("Bounces " + curBounces);

                if(App.model.GetBounces() >= App.model.winCondition)
                {
                    App.view.ball.enabled = false;
                    // Stops the ball
                    App.view.ball.GetComponent<Rigidbody>().isKinematic = true;

                    // Notifies itself and any other existing controllers interested in this event
                    App.Notify(BounceNotification.GameComplete, this);
                }
                break;

            case BounceNotification.GameComplete:
                Debug.Log("Victory!");
                App.view.countText.text += " - Victory!";
                break;
        }
    }

}
