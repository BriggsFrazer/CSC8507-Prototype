using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TowerScript : MonoBehaviour
{
    // Start is called before the first frame update

    ConstraintSource source;
    // Update is called once per frame
    public void ResolveTower()
    {
        int counter = 0;
        Transform newTransform;
        foreach (GameObject item in this.GetComponent<PickUpScript>().stack)
        {
            
            Debug.Log(source);
            if (item.GetComponent<ParentConstraint>() == null)
            {



                item.AddComponent<ParentConstraint>();

                if (counter == 0)
                {
                   

                   newTransform = this.transform;


                    

                }

                else {
                    newTransform = this.GetComponent<PickUpScript>().stack[counter-1].transform;
                }
                source.sourceTransform = newTransform;
                source.weight = (float)(1);
                item.GetComponent<ParentConstraint>().AddSource(source);
                Vector3 offset;

                offset = counter == 0 ? new Vector3 (0,0.49f,0): new Vector3 (0,0.21f,0);
                item.GetComponent<ParentConstraint>().SetTranslationOffset(0, offset);

                item.GetComponent<ParentConstraint>().constraintActive = true;
                
            }
            counter++;
        }
    }
}
