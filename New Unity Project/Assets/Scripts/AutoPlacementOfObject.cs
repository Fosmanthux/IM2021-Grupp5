using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class AutoPlacementOfObject : MonoBehaviour
{
    public GameObject arCamera;

    [SerializeField]
    public GameObject[] objectArray;

    private GameObject placedObject1;
    private GameObject placedObject2;
    private GameObject placedObject3;
    private GameObject placedObject4;
    private GameObject placedObject5;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    [SerializeField]
    private Camera Camera;

    [SerializeField]
    private GameObject placedPrefab;

    private Vector2 touchPosition = default;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private PlacementObject lastSelectedObject;
    private GameObject placedObject;

    private GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

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

                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if (lastSelectedObject == null)
                    {
                        //lastSelectedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation).GetComponent<PlacementObject>();
                    }
                }
            }
        }
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject1 == null)
        {
            ARPlane arPlane = args.added[0];
            Vector3 cameraPosition = arCamera.transform.position;
            Vector3 planePosition = arPlane.transform.position;

            //place on plane pos
            placedObject1 = Instantiate(objectArray[Random.Range(0, objectArray.Length)], planePosition, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 2 ~ 3 meters away, random x (-2~2) 
            Vector3 objectPosition1 = new Vector3(planePosition.x + Random.Range(-2f, 2f), planePosition.y, cameraPosition.z + Random.Range(2f, 3f));
            placedObject2 = Instantiate(objectArray[Random.Range(0, objectArray.Length)], objectPosition1, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 4 ~ 5 meters
            Vector3 objectPosition2 = new Vector3(planePosition.x + Random.Range(-2f, 2f), planePosition.y, cameraPosition.z + Random.Range(4f, 5f));
            placedObject3 = Instantiate(objectArray[Random.Range(0, objectArray.Length)], objectPosition2, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 6 ~ 7 meters
            Vector3 objectPosition3 = new Vector3(planePosition.x + Random.Range(-2f, 2f), planePosition.y, cameraPosition.z + Random.Range(6f, 7f));
            placedObject4 = Instantiate(objectArray[Random.Range(0, objectArray.Length)], objectPosition3, Quaternion.Euler(0, Random.Range(0, 360), 0));

            // 8 ~ 9 meter
            Vector3 objectPosition4 = new Vector3(planePosition.x + Random.Range(-2f, 2f), planePosition.y, cameraPosition.z + Random.Range(8f, 9f));
            placedObject5 = Instantiate(objectArray[Random.Range(0, objectArray.Length)], objectPosition4, Quaternion.Euler(0, Random.Range(0, 360), 0));
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
