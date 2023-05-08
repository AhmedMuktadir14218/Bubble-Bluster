using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration; ///acceleration describes how much the Player's speed increases over time.
    public float maxSpeed; ///maxSpeed is the “speed limit”.

    private Rigidbody rigidBody; ///rigidBody will hold a reference to the Rigidbody component that’s attached to the Player GameObject.
    private KeyCode[] inputKeys; ///inputKeys is an array of keycodes that will be used to detect input.
    private Vector3[] directionsForKeys; ///directionsForKeys holds an array of Vector3 variables, which will hold directional data.

    // Start is called before the first frame update
    void Start(){
    
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // 1
    void FixedUpdate () {
        for (int i = 0; i < inputKeys.Length; i++){
            var key = inputKeys[i];

            // 2
            if(Input.GetKey(key)) {
            // 3
            Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
            movePlayer(movement);
            }
        }
    }


    void movePlayer(Vector3 movement) {
        if(rigidBody.velocity.magnitude * acceleration > maxSpeed){
            rigidBody.AddForce(movement * -1);
        } 
        else{
            rigidBody.AddForce(movement);
        }
    }



}
