using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plane : MonoBehaviour {

    public GameObject pointPrefab;
    public List<GameObject> set;

    public int numberOfPoints = 15;
    public float screenSize;
    public float padding = 0.75f;


	// Use this for initialization
	void Start () {
        screenSize = Camera.main.orthographicSize - padding;
        CreateSet();
	}

    private void CreateSet() {
        set = new List<GameObject>();

        for (int i = 0; i < numberOfPoints; i++) {
            Instantiate(pointPrefab, new Vector3(Random.Range(-screenSize, screenSize), Random.Range(-screenSize, screenSize), 0f), Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
