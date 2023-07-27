using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class organismManager : MonoBehaviour
{
    private List<organismEating> activeOrganisms = new List<organismEating>();

    int organismEaten = 0;
    public Text organismEatenText;

    public static organismManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public List<organismEating> GetActiveOrganisms()
    {
        return activeOrganisms;
    }

    // called by organism when it eats a food
    public void OrganismEatenNotice()
    {
        organismEaten++;
        organismEatenText.text = organismEaten.ToString();
    }
    
    public void AddOrganism(organismEating organism)
    {
        activeOrganisms.Add(organism);
    }

    public void RemoveOrganism(organismEating organism)
    {
        activeOrganisms.Remove(organism);
    }
}
