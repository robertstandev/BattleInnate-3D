using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    [SerializeField]private GameObject[] collectiblesTypes;
    [SerializeField]private GameObject[] collectiblesGroupsParents;
    [SerializeField]private float minIntervalSpawn = 10f;
    [SerializeField]private float maxIntervalSpawn = 30f;
    [SerializeField]private Transform ground;
    private int selectedCollectibleIndex;
    private GameObject selectedCollectibleGameObject;

    private void OnEnable()
    {
        InvokeRepeating("startCollectibleCreation", 10f, Random.Range(this.minIntervalSpawn, this.maxIntervalSpawn));
    }

    private void OnDisable() { CancelInvoke(); }

    private void startCollectibleCreation()
    {
        this.selectedCollectibleIndex = Random.Range(0, this.collectiblesTypes.Length);

        if(this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform.childCount > 0)
        {
            if(!isChildAvailable())
            {
                this.selectedCollectibleGameObject = Instantiate(this.collectiblesTypes[this.selectedCollectibleIndex] , this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform);
            }
            else
            {
                this.selectedCollectibleGameObject.SetActive(true);
            }
        }
        else
        {
            this.selectedCollectibleGameObject = Instantiate(this.collectiblesTypes[this.selectedCollectibleIndex] , this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform);
        }

        this.selectedCollectibleGameObject.transform.position = findLocationForCollectible();
    }

    private bool isChildAvailable()
    {
        for (int i = 0; i < this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform.childCount; i++)
        {
            if(!this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform.GetChild(i).gameObject.activeInHierarchy)
            {
                this.selectedCollectibleGameObject = this.collectiblesGroupsParents[this.selectedCollectibleIndex].transform.GetChild(i).gameObject;
                return true;
            }
        }
        return false;
    }

    private Vector3 findLocationForCollectible()
    {
        return new Vector3( Random.Range(this.ground.position.x - ((this.ground.localScale.x / 2) - 1), this.ground.position.x + ((this.ground.localScale.x / 2) - 1))
                            , 0.2f
                            , Random.Range(this.ground.position.z - ((this.ground.localScale.y / 2) - 1), this.ground.position.z + ((this.ground.localScale.y / 2) - 1)));
    }
}