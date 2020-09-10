using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalManager : MonoBehaviour {
    //Static Veritable
    public static ObsticalManager OC;
    //List of traps
    public List<GameObject> TrapList = new List<GameObject>();
    //trap prefab
    public GameObject Trap;
    //if it can spawn
    public bool CanSpawn = false;
    //Spawn rate
    public float SpawnRate;
    private float delta = 0;
    private void Awake() {
        //Singleton
        if (OC == null) OC = this;
        else if (OC != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    //Updates
    private void Update() {
        //countdown
        delta += Time.deltaTime;
        //if it is time to spawn an trap
        if (delta >= SpawnRate) {
            //if traps can not spawn
            if (!CanSpawn) return;
            //Adds a new trap
            TrapList.Add(Instantiate(Trap, new Vector3(0, 0, 50), Quaternion.identity, transform));
            //resets the timer
            delta = 0;
        }
    }
    //Resets all of the variables
    public void Reset() {
        //disables spawning
        CanSpawn = false;
        //resets the delta time
        delta = 0;
        //removes all of the traps
        while(TrapList.Count > 0) TrapList[0].GetComponent<ObsticalCreator>().RemoveTrap();
    }
}
