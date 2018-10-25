using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy_4 will start offscreen and hten pick a random point on screen to move to.
/// once it has arrived, it will pick another randompoint and continue until
/// player has shot it down
/// </summary>
public class Enemy_4 : Enemy 
{
    private Vector3 p0, p1;
    private float timeStart;
    private float duration = 4;
	// Use this for initialization
	void Start () 
    {
        p0 = p1 = pos;

        InitMovement();
	}
    void InitMovement()
    {
        p0 = p1;

        float widMinRad = bndCheck.camWidth = bndCheck.radius;
        float hgtMinRad = bndCheck.camHeight - bndCheck.radius;
        p1.x = Random.Range(-widMinRad, widMinRad);
        p1.y = Random.Range(-hgtMinRad, hgtMinRad);

        timeStart = Time.time;
    }

    public override void Move()
    {
        float u = (Time.time - timeStart) / duration;

        if (u>=1)
        {
            InitMovement();
            u = 0;
        }
        u = 1 - Mathf.Pow(1 - u, 2);
        pos = (1 - u) * p0 + u * p1;
    }
}
