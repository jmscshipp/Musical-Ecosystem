using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilGuyEating : MonoBehaviour
{
    organismEating nearestOrganism;
    float nearestDist;
    lilGuyMovement movement;
    bool isSleeping;
    float sleepCounter;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<lilGuyMovement>();

        // temporaryily assign dummy food
        nearestOrganism = GameObject.FindGameObjectWithTag("organism").GetComponent<organismEating>();
        nearestDist = Vector2.Distance(transform.position, nearestOrganism.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        List<organismEating> organisms = organismManager.Instance.GetActiveOrganisms();

        if (isSleeping) 
        {
            sleepCounter = sleepCounter - Time.deltaTime;
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
            if (sleepCounter <= 0)
            {
                WakeUp();
            }
        }

        if (organisms.Count == 0)
            return;

        if (nearestOrganism == null)
            ResetNearestOrganism();

        foreach (organismEating organism in organisms)
        {
            float tempDistance = Vector2.Distance(transform.position, organism.transform.position);
            if (tempDistance < nearestDist)
            {
                nearestOrganism = organism;
                nearestDist = tempDistance;
            }
        }

        GetComponent<lilGuyMovement>().SetGoalPos(nearestOrganism.transform.position);

        if (nearestDist <= 0.3f)
            EatOrganism(nearestOrganism);
    }

    void ResetNearestOrganism()
    {
        List<organismEating> organisms = organismManager.Instance.GetActiveOrganisms();
        if (organisms.Count == 0)
        {
            nearestOrganism = null;
            nearestDist = Mathf.Infinity;
        }
        else
        {
            nearestOrganism = organismManager.Instance.GetActiveOrganisms()[0];
            nearestDist = 10;
        }
    }

    void FallAsleep()
    {
        isSleeping = true;
        GetComponent<lilGuyMovement>().moveSpeed = 0;
        sleepCounter = 2;
    }
    void WakeUp()
    {
        isSleeping = false;
        GetComponent<lilGuyMovement>().moveSpeed = 1;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void EatOrganism(organismEating organismToEat)
    {
        organismManager.Instance.GetActiveOrganisms().Remove(organismToEat);
        organismManager.Instance.OrganismEatenNotice(); // to update text display
        Destroy(organismToEat.gameObject);
        ResetNearestOrganism();
        FallAsleep();
    }
}

