using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godControl : MonoBehaviour
{
    Vector3 mousePos;
    public GameObject organismPrefab;

    // Update is called once per frame
    void Update()
    {
        CheckMouseInput();
    }

    void CheckMouseInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0.0f;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            SpawnOrganism();
    }

    void SpawnOrganism()
    {
        Instantiate(organismPrefab, mousePos, Quaternion.identity);
    }
}
