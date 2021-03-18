using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class AutoPlacementOfObject : MonoBehaviour
{
    public GameObject arCamera;

    [SerializeField]
    public GameObject[] smallDinoArray;

    [SerializeField]
    public GameObject[] bigDinoArray;

    [SerializeField]
    public GameObject[] allDinoArray;

    private GameObject smallDino1;
    private GameObject smallDino2;
    private GameObject smallDino3;
    private GameObject smallDino4;
    private GameObject smallDino5;

    private GameObject dino1;
    private GameObject dino2;

    private GameObject bigDino1;
    private GameObject bigDino2;
    private GameObject bigDino3;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    [SerializeField]
    private Camera Camera;

    //[SerializeField]
    //private GameObject placedPrefab;

    private Vector2 touchPosition = default;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private PlacementObject lastSelectedObject;
    //private GameObject placedObject;

    /*private GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }*/

    private void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    lastSelectedObject = hitObject.transform.GetComponent<PlacementObject>();
                    if (lastSelectedObject != null)
                    {
                        ChangeSelectedObject(lastSelectedObject);
                    }
                }
                else
                {
                    lastSelectedObject = null;
                    if (lastSelectedObject == null)
                    {
                        PlacementObject[] allObjects = FindObjectsOfType<PlacementObject>();
                        foreach (PlacementObject placementObject in allObjects)
                        {
                            placementObject.Selected = false;
                        }
                    }
                }
            }
        }
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && smallDino2 == null)
        {
            ARPlane arPlane = args.added[0];
            Vector3 cameraPosition = arCamera.transform.position;
            Vector3 planePosition = arPlane.transform.position;

            //place on plane pos
            //smallDino1 = Instantiate(smallDinoArray[Random.Range(0, smallDinoArray.Length)], planePosition, Quaternion.Euler(0, Random.Range(0, 360), 0));

            //front small dinos
            // 2 ~ 3 meters away, random x  
            Vector3 objectPosition1 = new Vector3(planePosition.x + Random.Range(-2f, 2f), planePosition.y, cameraPosition.z + Random.Range(2f, 3f));
            smallDino2 = Instantiate(smallDinoArray[Random.Range(0, smallDinoArray.Length)], objectPosition1, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 4 ~ 5 meters
            Vector3 objectPosition2 = new Vector3(planePosition.x + Random.Range(-4f, 4f), planePosition.y, cameraPosition.z + Random.Range(4f, 5f));
            smallDino3 = Instantiate(smallDinoArray[Random.Range(0, smallDinoArray.Length)], objectPosition2, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 6 ~ 7 meters
            Vector3 objectPosition3 = new Vector3(planePosition.x + Random.Range(-6f, 6f), planePosition.y, cameraPosition.z + Random.Range(6f, 7f));
            smallDino4 = Instantiate(smallDinoArray[Random.Range(0, smallDinoArray.Length)], objectPosition3, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 8 ~ 9 meter
            Vector3 objectPosition4 = new Vector3(planePosition.x + Random.Range(-8f, 8f), planePosition.y, cameraPosition.z + Random.Range(8f, 9f));
            smallDino5 = Instantiate(smallDinoArray[Random.Range(0, smallDinoArray.Length)], objectPosition4, Quaternion.Euler(0, Random.Range(0, 360), 0));
            
            // 10 ~ 35
            Vector3 objectPosition5 = new Vector3(planePosition.x + Random.Range(-10f, 10f), planePosition.y, cameraPosition.z + Random.Range(10f, 15f));
            dino1 = Instantiate(allDinoArray[Random.Range(0, allDinoArray.Length)], objectPosition5, Quaternion.Euler(0, Random.Range(0, 360), 0));

            Vector3 objectPosition6 = new Vector3(planePosition.x + Random.Range(-20f, 20f), planePosition.y, cameraPosition.z + Random.Range(30f, 35f));
            dino2 = Instantiate(allDinoArray[Random.Range(0, allDinoArray.Length)], objectPosition6, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 50 ~ 25
            Vector3 objectPosition7 = new Vector3(planePosition.x + Random.Range(-30f, -30f), planePosition.y, cameraPosition.z + Random.Range(50f, 55f));
            bigDino1 = Instantiate(bigDinoArray[Random.Range(0, bigDinoArray.Length)], objectPosition7, Quaternion.Euler(0, Random.Range(0, 360), 0));

            Vector3 objectPosition8 = new Vector3(planePosition.x + Random.Range(-40f, 40f), planePosition.y, cameraPosition.z + Random.Range(70f, 75f));
            bigDino2 = Instantiate(bigDinoArray[Random.Range(0, bigDinoArray.Length)], objectPosition8, Quaternion.Euler(0, Random.Range(0, 360), 0));

            Vector3 objectPosition9 = new Vector3(planePosition.x + Random.Range(-50f, 50f), planePosition.y, cameraPosition.z + Random.Range(90f, 95f));
            bigDino3 = Instantiate(bigDinoArray[Random.Range(0, bigDinoArray.Length)], objectPosition9, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }

    void ChangeSelectedObject(PlacementObject selected)
    {
        PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
        foreach (PlacementObject placementObject in allOtherObjects)
        {
            if (placementObject != lastSelectedObject)
            {
                placementObject.Selected = false;
            }
            else
            {
                placementObject.Selected = true;
            }
        }
    }
}
