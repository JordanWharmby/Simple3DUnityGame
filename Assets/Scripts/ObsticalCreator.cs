using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalCreator : MonoBehaviour {
    //trap Prefab
    public GameObject Obstical;
    //List of 
    public Transform[] positions;
    //speed
    public float Speed;
    //End point
    public Vector3 EndPoint;

    private void Awake() {
        //selects a random position to not have an trap
        int miss = Mathf.RoundToInt(Random.Range(0, positions.Length));
        //creates the spikes
        for (int i = 0; i < positions.Length; i++) if (i != miss) Instantiate(Obstical, positions[i].position, Quaternion.identity, transform);
    }

    private void Update() {
        //Moves the trap
        transform.position = Vector3.MoveTowards(transform.position, EndPoint, Speed * Time.deltaTime);
        //if it needs deleting
        if (transform.position.z < EndPoint.z + 1) RemoveTrap();
    }
    //Removes the object from the game
    public void RemoveTrap() {
        //removes the object from the list
        ObsticalManager.OC.TrapList.Remove(gameObject);
        //Destroys the object
        Destroy(gameObject);
    }
}
