using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArena : MonoBehaviour
{
    [SerializeField]private Transform healthCollectiblesGroup;
    [SerializeField]private Transform ground;
    private Movement movementComponent;
    private Health healthComponent;
    private Vector2 movementData;
    private GameObject player;
    private GameObject currentTarget;
    private Rigidbody rb;

    private void Awake()
    {
        this.movementComponent = GetComponent<Movement>();
        this.healthComponent = GetComponent<Health>();
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.rb = GetComponent<Rigidbody>();
    }

   private void FixedUpdate()
   {
       moveToTarget(doDecision());
   }

    private Vector3 doDecision()
    {
        this.currentTarget = target();
        if(!isAvailable(this.currentTarget))
        {
            return this.player.transform.position;
        }
        else
        {
            return this.currentTarget.transform.position; 
        }
    }

    private void moveToTarget(Vector3 locationToGo)
    {
        this.movementData.x = locationToGo.x > transform.position.x ? 1f : locationToGo.x < transform.position.x ? -1f : 0f;
        this.movementData.y = locationToGo.z > transform.position.z ? 1f : locationToGo.z < transform.position.z ? -1f : 0f;  

        this.movementComponent.changeMovementData(this.movementData);
        this.movementComponent.moveCharacter(this.rb);
    }

   private GameObject target()
   {
        if (this.healthComponent.getCurrentHealth() == 100)
        {
           return this.player;
        }
        else
        {
           return returnHealthCollectiblesAvailable();
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

   private GameObject returnHealthCollectiblesAvailable()
   {
       for (int i = 0 ; i < this.healthCollectiblesGroup.childCount ; i++)
       {
           if(isAvailable(this.healthCollectiblesGroup.GetChild(i).gameObject))
           {
               return this.healthCollectiblesGroup.GetChild(i).gameObject;
           }
       }
       return null;
   }
}
