using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> tileOptions; // Agora é uma lista no Inspector
    public GameObject StartTile;

    private float Index = 0;

    private void Start()
    {
        GameObject StartPlane1 = Instantiate(StartTile, transform);
        StartPlane1.transform.position = new Vector3(7, 0, 0);
        GameObject StartPlane2 = Instantiate(StartTile, transform);
        StartPlane2.transform.position = new Vector3(-1, 0, 0);
        GameObject StartPlane3 = Instantiate(StartTile, transform);
        StartPlane3.transform.position = new Vector3(-9, 0, 0);
        GameObject StartPlane4 = Instantiate(StartTile, transform);
        StartPlane4.transform.position = new Vector3(-17, 0, 0);
        GameObject StartPlane5 = Instantiate(StartTile, transform);
        StartPlane5.transform.position = new Vector3(-25, 0, 0);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);

        if (transform.position.x >= Index && tileOptions.Count > 0)
        {
            GameObject TempTile1 = Instantiate(tileOptions[Random.Range(0, tileOptions.Count)], transform);
            TempTile1.transform.position = new Vector3(-16, 0, 0);

            GameObject TempTile2 = Instantiate(tileOptions[Random.Range(0, tileOptions.Count)], transform);
            TempTile2.transform.position = new Vector3(-24, 0, 0);

            Index += 15.95f;
        }
    }
}
