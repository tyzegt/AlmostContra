using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallCannon : MonoBehaviour {

    private AngleChecker angler;

    void Start()
    {
        angler = GetComponent<AngleChecker>();
    }

	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angler.checkAngle());
	}
}
