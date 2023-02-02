using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //point noktalarýný eklicez
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    [SerializeField]
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //Time.deltaTime : Özetle Time.deltaTime komutlarýmýzý bilgisayarýmýz hýzlý çalýþtýkça daha düþük deðerle vermemizi,
        //bilgisayarýmýz yavaþ çalýþtýkça daha yüksek deðerle vermemizi saðlayarak ortalama olarak ayný deðerde çalýþmasýný saðlar.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
