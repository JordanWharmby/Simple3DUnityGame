using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3[] Positions;
    private int currentPosition = 1;
    //if the player can move
    public bool CanMove = false;

    // Start is called before the first frame update
    void Start() {
        //Sets the player position
        currentPosition = 1;
        transform.position = Positions[currentPosition];
        //Sets can move
        CanMove = false;
    }
    // Update is called once per frame
    void Update() {
        if (!CanMove) return;
        if (Input.GetKeyDown(KeyCode.A)) SetNewPosition(-1);
        if (Input.GetKeyDown(KeyCode.D)) SetNewPosition(1);
    }
    public void SetNewPosition(int i) {
        //if it can move
        if (currentPosition + i < 0 || currentPosition + i > 2) return;
        //changes the current position
        else currentPosition += i;
        //sets the Position
        transform.position = Positions[currentPosition];
    }
    //Resets the player
    public void ResetPlayer() {
        //Sets the player position
        currentPosition = 1;
        transform.position = Positions[currentPosition];
        //Sets can move
        CanMove = false;
    }
    //if the player hits a trap
    private void OnCollisionEnter(Collision collision) {
        GameManager.GM.CurrentState = GameManager.GameStae.Reset;
    }
}
