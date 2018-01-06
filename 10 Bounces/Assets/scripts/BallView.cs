using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Describes the Player Ball view and its features
public class BallView : BounceElement {

    // Callback called upon collision, physics will do the work
    private void OnCollisionEnter()
    {
        // App.controller.OnBallGroundHit();
        App.Notify(BounceNotification.BallHitGround, this);
    }
}
