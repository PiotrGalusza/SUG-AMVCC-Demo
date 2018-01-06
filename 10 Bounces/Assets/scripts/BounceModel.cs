using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains all data related to the app
public class BounceModel : BounceElement {

    // Data
    private int bounces;
    public int winCondition;
    
    public void SetBounces(int newBounces)
    {
        bounces = newBounces;
    }

    public int GetBounces()
    {
        return bounces;
    }
}
