using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassSummon_Card : MonoBehaviour
{
    private GameObject unit_child;
    private GameObject unit_parent;

    // Start is called before the first frame update
    void Start()
    {
        unit_parent = GameObject.Find("Unit_generation_location");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SummonZone_p1")
        {
            if(Input.GetMouseButtonUp(0))
            {
                unit_child = Unit_manager.Instantiate_unit(Unit_manager.unit_list[Random.Range(0, 4)], this.transform.position, 1);

                unit_child.transform.position = unit_parent.transform.position;

                Destroy(this.gameObject);
            }
        }
    }
}
