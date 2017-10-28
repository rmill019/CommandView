using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Swap : MonoBehaviour 
{

	public GameObject room;

	public GameObject camera;

	public GameObject zoomOut;

	public static Vector3 camDefault;

	public float zoomDuration = 0.5f;


	void Start()
	{

		//Sets the default cam location

		camDefault = camera.transform.position;

		// Disables button 

		zoomOut.SetActive (false);

	}

	void OnMouseDown()
	{

		// Calls the smooth Zoom Coroutine

		StartCoroutine(Zoom());

		// Enables the button

		zoomOut.SetActive (true);

	}

	public void Return()
	{

		// Resets camera to default location

		//camera.transform.position = camDefault;

		// Calls the smooth Zoom Out Coroutine

		StartCoroutine (Zoom_Out());

		// Disables the button once again

		zoomOut.SetActive (false);

	}

	IEnumerator Zoom()
	{

		// Slowly changes the camera to an FOV of 19

		float deltaT = 0f;

		while (deltaT < zoomDuration) 
		{

			deltaT += Time.deltaTime;

			//Adjust this value to change speed of FOV change 

			yield return new WaitForSeconds (0.02f);

			Camera.main.fieldOfView = Mathf.Lerp (110, 19, deltaT / zoomDuration);

			Vector3 pos = camera.transform.position;

			pos.x = room.transform.position.x;

			pos.y = room.transform.position.y;

			pos.z = -20.5f;

			camera.transform.position = Vector3.Lerp(camera.transform.position, pos, deltaT / zoomDuration);

			//camera.transform.position.x = Mathf.Lerp (transform.position.x, room.transform.position.x, deltaT / zoomDuration);


		}

	}

	IEnumerator Zoom_Out()
	{

		// Slowly changes the camera to an FOV of 110

		float deltaT = 0f;

		while (deltaT < zoomDuration) 
		{

			deltaT += Time.deltaTime;

			//Adjust this value to change speed of FOV change 

			yield return new WaitForSeconds (0.02f);

			Camera.main.fieldOfView = Mathf.Lerp (19, 110, deltaT / zoomDuration);

			Vector3 pos = camDefault;

			camera.transform.position = Vector3.Lerp(camera.transform.position, camDefault, deltaT / zoomDuration);


		}

	}

}
