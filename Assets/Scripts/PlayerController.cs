using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject objectPrefab;
    private bool slowMo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(objectPrefab, pos, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!slowMo)
            {
                Time.timeScale = 1.0f;
                slowMo = false;
            }
            else
            {
                Time.timeScale = 0.7f;
                slowMo = true;
            }
        }
    }

    
}
