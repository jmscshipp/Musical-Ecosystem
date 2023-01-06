using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class godControl : MonoBehaviour
{
    Vector3 mousePos;
    public GameObject organismPrefab;
    private int organismCount;
    public Text organismCountText;

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
        {
            SpawnOrganism();
            organismCount++;
            organismCountText.text = organismCount.ToString();
        }
    }

    void SpawnOrganism()
    {
        Instantiate(organismPrefab, mousePos, Quaternion.identity);
    }
}
