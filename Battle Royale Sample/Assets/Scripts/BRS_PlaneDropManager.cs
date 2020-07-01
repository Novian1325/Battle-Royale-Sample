using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Security.Cryptography;
using UnityEngine;
using UnityEditor;

public class BRS_PlaneDropManager : MonoBehaviour
{

	[Header("Map Settings")]
	public int MapSize = 8;
	public int StepSize;
	[Range(1, 9)]
	public int DropZoneRange = 8;
	[Header("Plane Settings")]
	public GameObject BRS_PlaneSpawn;
	public float BRS_PlaneAltitude;
	public float BRS_PlaneAirspeed = 100f;

	private Vector3[] PD_L;
	private Vector3[] PD_R;
	public GameObject PlaneStart;
	public GameObject PlaneStop;
	private int startFlightIndex;
	private int endFlightIndex;
	public bool VerifiedPath = false;
	public GameObject ADZ;
	private GameObject Player;
	private GameObject DropSpot;
	private GameObject PlaneCamera;
	private bool hasDropped;

	void Start()
	{
		hasDropped = false;
		Player = GameObject.FindGameObjectWithTag("Player");
		Player.SetActive(false);

		//Debug.Break();
		PD_L = new Vector3[9];
		PD_R = new Vector3[9];

		var setupPosition = new Vector3(-MapSize, BRS_PlaneAltitude, MapSize);

		for (int i = 0; i < PD_L.Length; i++)
		{
			PD_L[i] = setupPosition;
			setupPosition = new Vector3(-MapSize, BRS_PlaneAltitude, (setupPosition.z - StepSize));
		}
		//Debug.Log(setupPosition);
		setupPosition = new Vector3(MapSize, BRS_PlaneAltitude, MapSize);

		for (int i = 0; i < PD_R.Length; i++)
		{
			PD_R[i] = setupPosition;
			setupPosition = new Vector3(MapSize, BRS_PlaneAltitude, (setupPosition.z - StepSize));
		}

		//Find the cylinder for flight check
		//GameObject ADZ = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		//ADZ.name = "AcceptableDropZone";
		ADZ.transform.position = Vector3.zero;
		//This value will be calculated in the future based on user preferences
		ADZ.transform.localScale = new Vector3(MapSize, MapSize, MapSize);


		//Get an acceptable flight path
		SetupFlightPath();
	}

	private void SetupFlightPath()
	{
		// Let's find a path that is certainly THROUGH the cylinder
		//Debug.Log("Start");
		VerifiedPath = false;
		int numberOfAttempts = 0;
		Vector3 startFlight;
		Vector3 endFlight;

		do
		{
			//Debug.Log("Planing optimal Route");
			//Pick a Random startpoint
			startFlightIndex = Random.Range(0, PD_L.Length);
			startFlight = PD_L[startFlightIndex];

			//Pick a Random endpoint
			endFlightIndex = Random.Range(0, PD_R.Length);
			endFlight = PD_R[endFlightIndex];

			PlaneStart.transform.position = startFlight;
			PlaneStop.transform.position = endFlight;
			PlaneStart.transform.LookAt(PlaneStop.transform);

			RaycastHit objectHit;
			if (Physics.Raycast(PlaneStart.transform.position, PlaneStart.transform.forward, out objectHit, 8000))
			{
				//Debug.Break();

				//Debug.Log("Trying " + numberOfAttempts++ + " times");
				if (objectHit.collider.gameObject.name == "AcceptableDropZone")
				{
					VerifiedPath = true;
					//Debug.Log("Optimal Route Calculated");
					GameObject.Destroy(objectHit.collider.gameObject);
					numberOfAttempts = 10;
					Destroy(PlaneStart);
					Destroy(PlaneStop);
					SpawnPlane();
				}
				numberOfAttempts++;
			}
		} while (VerifiedPath != true && numberOfAttempts < 10);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp("space") && !hasDropped)
        {
			DropSpot = GameObject.Find("Drop Spot");
			DropSpot.transform.parent = null;
			PlaneCamera = GameObject.Find("Plane Camera");
			
			//Debug.Log(DropSpot.transform.position);
            Player.transform.position = DropSpot.transform.position;
			//Debug.Break();
			Player.SetActive(true);
			Destroy(PlaneCamera);
			Destroy(DropSpot);
			hasDropped = true;
        }
		//else
        //{

        //}
	}

	void LateUpdate()
	{
		if (VerifiedPath)
		{
			//Debug.Break();
			//SpawnPlane();
		}
	}

	void SpawnPlane()
	{
		PlaneStart.transform.LookAt(PD_R[endFlightIndex]);
		Instantiate(BRS_PlaneSpawn, PlaneStart.transform.position, PlaneStart.transform.rotation);
		//Debug.Break();
		//VerifiedPath = false;
	}
}