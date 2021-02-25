using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxSpawner : MonoBehaviour
{

    public Collider[] pickUpSphere;
    public float collectionRadius = 0.2f;
    public bool found;
    private bool building;
    public GameObject itemBox;


    // Start is called before the first frame update
    void Start()
    {
        found = false;
    }

    // Update is called once per frame
    void Update()
    {
        pickUpSphere = Physics.OverlapSphere(this.transform.position, collectionRadius);

        
        if(pickUpSphere.Length == 0)
        {
            found = false;
        }

        foreach (Collider collider in pickUpSphere)
        {
            Debug.Log("collider found");
            if (collider.gameObject.tag == "powerup")
            {
                Debug.Log("found an item box");
                found = true;
                break;
            }
        }
        
        if (!found && !building)
        {
            StartCoroutine(Spawnbox());
            building = true;
           
        }
    }

    IEnumerator Spawnbox()
    {
        yield return new WaitForSeconds(2);
        Instantiate(itemBox, this.transform.position, new Quaternion(0, 0, 0, 0));
        building = false;
    }
}
