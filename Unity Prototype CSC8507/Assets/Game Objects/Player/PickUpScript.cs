using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Collider[] pickUpSphere;
    public float collectionRadius = 0.2f;
    public List<GameObject> stack;
    public GameObject dropOffZone;

    private int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickUpSphere = Physics.OverlapSphere(this.transform.position, collectionRadius,layerMask);
        if (Input.GetKeyDown("e")){
            if(pickUpSphere.Length > 0)
            {
                AddItemToStack(pickUpSphere[0].gameObject);
            }
            if (this.GetComponent<PlayerController>().canDropOff)
            {
                if(stack.Count > 0)
                {

                    var Block = stack[stack.Count - 1];
                    dropOffZone.GetComponent<TeamController>().score += Block.GetComponent<PickUpData>().value;
                    stack.RemoveAt(stack.Count - 1);
                    Destroy(Block);
                    this.GetComponent<TowerScript>().ResolveTower();
                }
            }    
        }

        this.gameObject.GetComponent<PlayerController>().speedLimit = 8;

        for (int i = 0; i < stack.Count; i++)
        {
            
            this.gameObject.GetComponent<PlayerController>().speedLimit = this.gameObject.GetComponent<PlayerController>().speedLimit * 0.75f;
        }

        
        
    }

    void AddItemToStack(GameObject item)
    {
        item.layer = 9;
        stack.Add(item);
        this.GetComponent<TowerScript>().ResolveTower();
        

    }
}
