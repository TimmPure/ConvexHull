using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plane : MonoBehaviour {

    public GameObject pointPrefab;
    public List<GameObject> set;

    public int numberOfPoints = 15;
    public float screenSize;
    public float padding = 0.75f;

    public GameObject leftmost;

	private void Start () {
        screenSize = Camera.main.orthographicSize - padding;
        CreateSet();
	}

    private void CreateSet() {
        set = new List<GameObject>();

        for (int i = 0; i < numberOfPoints; i++) {
            set.Add(Instantiate(pointPrefab, new Vector3(Random.Range(-screenSize, screenSize), Random.Range(-screenSize, screenSize), 0f), Quaternion.identity, this.transform));
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GiftWrap();
        }
    }

    private void GiftWrap() {
        FindLeftmostPoint();
    }

    private void FindLeftmostPoint() {
        leftmost = set[0];

        foreach (GameObject point in set){
            if (point.transform.position.x < leftmost.transform.position.x) {
                leftmost = point;
             }
        }

        leftmost.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
