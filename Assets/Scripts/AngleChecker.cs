using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleChecker : MonoBehaviour {

    private PlayerController player;
    private float angle;
    private Vector2 A, B, C;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public float checkAngle()
    {
        A = new Vector2(transform.position.x, transform.position.y);
        B = new Vector2(player.transform.position.x, player.transform.position.y);
        C = B - A;

        angle = Mathf.Atan2(C.y, C.x) * Mathf.Rad2Deg;
        angle = Mathf.Round(angle / 30) * 30;

        return angle;
    }

}
