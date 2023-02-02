using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //point noktalar�n� eklicez
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
        //Time.deltaTime : �zetle Time.deltaTime komutlar�m�z� bilgisayar�m�z h�zl� �al��t�k�a daha d���k de�erle vermemizi,
        //bilgisayar�m�z yava� �al��t�k�a daha y�ksek de�erle vermemizi sa�layarak ortalama olarak ayn� de�erde �al��mas�n� sa�lar.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
