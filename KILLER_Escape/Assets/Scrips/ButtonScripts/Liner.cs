using UnityEngine;
using System;

public class Liner : MonoBehaviour
{

	[SerializeField, Range(0, 10)]
	float time = 1;

	[SerializeField]
	Vector3	endPosition;

    [NonSerialized]
    public bool startLiner = false;


	private float startTime;
	private Vector3 startPosition;

	void OnEnable ()
	{
		if (time <= 0) {
			transform.position = endPosition;
			enabled = false;
			return;
		}
		startPosition = transform.position;
	}
	
	void Update ()
	{
        if(startLiner)
        {
            if(startTime == 0)
            {
                startTime = Time.timeSinceLevelLoad;
            }
            var diff = Time.timeSinceLevelLoad - startTime;
            if (diff > time) {
                transform.position = endPosition;
                enabled = false;
            }

            var rate = diff / time;
            
            transform.position = Vector3.Lerp (startPosition, endPosition, rate);
        }
    }

	void OnDrawGizmosSelected ()
	{
#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
		Gizmos.DrawSphere (endPosition, 0.1f);
		Gizmos.DrawSphere (startPosition, 0.1f);

		Gizmos.DrawLine (startPosition, endPosition);
	}
}