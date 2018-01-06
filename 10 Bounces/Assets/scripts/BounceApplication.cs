using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all elements in this application
public class BounceElement : MonoBehaviour
{
    // Gives access to the application and all instances
    public BounceApplication App
    {
        get
        {
            return GameObject.FindObjectOfType<BounceApplication>();
        }
    }
}

// 10 Bounces Entry Point
public class BounceApplication : MonoBehaviour {

    // Reference to the root instance of the MVC
    public BounceModel model;
    public BounceView view;
    public BounceController controller;

	// Use this for initialization
	void Start () {
        model.SetBounces(0);
        view.SetCountText();
	}
	
    // Iterates through all Controllers and delegates notification data
    // This method can easily be found because every class is "BounceElement", so it has an "App" instance
    public void Notify(string eventPath, Object target, params object[] data)
    {
        BounceController[] controllerList = GetAllControllers();

        foreach(BounceController c in controllerList)
        {
            c.OnNotification(eventPath, target, data);
        }
    }

    // Retrieves all scene controllers
    public BounceController[] GetAllControllers()
    {
        // Can be modified as more controllers are created and added, using convenient implementation here
        BounceController[] allControllers = {controller};
        return allControllers;
    }
}
