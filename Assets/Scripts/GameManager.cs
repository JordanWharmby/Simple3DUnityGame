using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    public static GameManager GM;

    //Game State
    public enum GameStae {
        Play,
        Idle,
        Reset
    }
    public GameStae CurrentState;

    private void Awake() {
        //Sing ton pattern
        if (GM == null) GM = this;
        else if (GM != this) Destroy(gameObject);
        DontDestroyOnLoad(this);
        //sets the state
        CurrentState = GameStae.Play;
    }

    // Update is called once per frame
    void Update() {
        switch (CurrentState) {
            case GameStae.Play:
                //Sets the player to be able to move
                FindObjectOfType<Player>().CanMove = true;
                //Traps can spawn
                ObsticalManager.OC.CanSpawn = true;
                //Idle State
                CurrentState = GameStae.Idle;
                break;
                //Idle state
            case GameStae.Idle:
                break;
            case GameStae.Reset:
                //resets the player
                FindObjectOfType<Player>().ResetPlayer();
                //resets the trap manager
                ObsticalManager.OC.Reset();
                //sets the state to play again
                CurrentState = GameStae.Play;
                break;
            default:
                break;
        }
    }
}
