using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class OnboardingPlaneSetup : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public Material planeMat;
    public GameObject planePrefab;

    void Awake()
    {
        planePrefab.GetComponent<Renderer>().material = planeMat;

        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<Renderer>().material = planeMat;
        }
    }
}
