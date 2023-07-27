using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class godControl : MonoBehaviour
{
    Vector3 mousePos;
    public GameObject organismPrefab;
    public GameObject lilGuyPrefab;
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
        }else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnLilguy();
            organismCount++;
            organismCountText.text = organismCount.ToString();
        }
    }

    void SpawnOrganism()
    {
        organismEating organism = Instantiate(organismPrefab, mousePos, Quaternion.identity).GetComponent<organismEating>();
        organismManager.Instance.AddOrganism(organism);
    }

    void SpawnLilguy()
    {
        lilGuyEating lilGuy = Instantiate(lilGuyPrefab, mousePos, Quaternion.identity).GetComponent<lilGuyEating>();
        // add to lilguy managaer here
    }
}
