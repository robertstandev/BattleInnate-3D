using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArena : MonoBehaviour
{
    [SerializeField]private Transform healthGroup;
    [SerializeField]private Transform ground;
    private Movement movementComponent;
    private Health healthComponent;
    private Vector2 movementData;
    private GameObject player;
    private GameObject currentTarget;
    private Rigidbody rb;

    private void Awake()
    {
        movementComponent = GetComponent<Movement>();
        healthComponent = GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

   private void FixedUpdate() {
       moveToTarget(doDecision());
   }

    private Vector3 doDecision()
    {
        currentTarget = target();
        if(!isAvailable(currentTarget))
        {
            return findLocation();
        }
        else
        {
            return currentTarget.transform.position; 
        }
    }

    private void moveToTarget(Vector3 locationToGo)
    {
        movementData.x = locationToGo.x > transform.position.x ? 1.0f : locationToGo.x < transform.position.x ? -1.0f : 0.0f;
        movementData.y = locationToGo.z > transform.position.z ? 1.0f : locationToGo.z < transform.position.x ? -1.0f : 0.0f;  

        movementComponent.changeMovementData(movementData);
        movementComponent.moveCharacter(rb);
    }

    private Vector3 findLocation()
    {
        return new Vector3( Random.Range(ground.position.x - ((ground.localScale.x / 2) - 1), ground.position.x + ((ground.localScale.x / 2) - 1))
                            , 0.5f
                            , Random.Range(ground.position.z - ((ground.localScale.y / 2) - 1), ground.position.z + ((ground.localScale.y / 2) - 1)));
    }

   private GameObject target()
   {
        if (healthComponent.getCurrentHealth() > 20)
        {
           return player;
        }
        else
        {
           return returnHealthAvailable();
        }
   }

   private bool isAvailable(GameObject gameObjectToCheck)
   {
       if(gameObjectToCheck != null && gameObjectToCheck.activeInHierarchy)
       {
           return true;
       }
        return false;
   }

   private GameObject returnHealthAvailable()
   {
       for (int i = 0 ; i < healthGroup.childCount ; i++)
       {
           if(isAvailable(healthGroup.GetChild(i).gameObject))
           {
               return healthGroup.GetChild(i).gameObject;
           }
       }
       return null;
   }
}