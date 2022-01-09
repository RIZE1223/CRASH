using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strategy_test1 : MonoBehaviour
{
    public GameObject unitGenerationLocation;

    private void Awake()
    {
        unitGenerationLocation = GameObject.Find("Unit_generation_location");
    }
    void Start()
    {
        foreach (Transform n in unitGenerationLocation.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
        Destroy(this.gameObject);
    }

}
