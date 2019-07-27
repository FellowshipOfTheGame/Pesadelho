using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){

    	Vector3 desiredPosition 	= new Vector3(target.position.x + offset.x, target.position.y + offset.y, -1);
    	Vector3 smoothedPosition 	= Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    	transform.position = smoothedPosition;
        
    }
}
