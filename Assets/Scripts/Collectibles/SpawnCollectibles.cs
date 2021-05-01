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
    private Timer timerComponent;
    private int spawnTimerInstance;
    private int selectedCollectibleIndex;
    private GameObject selectedCollectibleGameObject;

    private void Awake() { timerComponent = GetComponent<Timer>(); }

    private void OnEnable()
    {
        spawnTimerInstance = timerComponent.createTimerInstanceAndGetIndex(Random.Range(minIntervalSpawn, maxIntervalSpawn), startCollectibleCreation);
        timerComponent.startTimer(spawnTimerInstance);
    }
    
    private void OnDisable() { timerComponent.stopTimer(spawnTimerInstance); }

    private void startCollectibleCreation()
    {
        selectedCollectibleIndex = Random.Range(0, collectiblesTypes.Length);

        if(collectiblesGroupsParents[selectedCollectibleIndex].transform.childCount > 0)
        {
            if(!isChildAvailable())
            {
                selectedCollectibleGameObject = Instantiate(collectiblesTypes[selectedCollectibleIndex] , collectiblesGroupsParents[selectedCollectibleIndex].transform);
            }
            else
            {
                selectedCollectibleGameObject.SetActive(true);
            }
        }
        else
        {
            selectedCollectibleGameObject = Instantiate(collectiblesTypes[selectedCollectibleIndex] , collectiblesGroupsParents[selectedCollectibleIndex].transform);
        }

        selectedCollectibleGameObject.transform.position = findLocationForCollectible();
    }

    private bool isChildAvailable()
    {
        for (int i = 0; i < collectiblesGroupsParents[selectedCollectibleIndex].transform.childCount; i++)
        {
            if(!collectiblesGroupsParents[selectedCollectibleIndex].transform.GetChild(i).gameObject.activeInHierarchy)
            {
                selectedCollectibleGameObject = collectiblesGroupsParents[selectedCollectibleIndex].transform.GetChild(i).gameObject;
                return true;
            }
        }
        return false;
    }

    private Vector3 findLocationForCollectible()
    {
        return new Vector3( Random.Range(ground.position.x - ((ground.localScale.x / 2) - 1), ground.position.x + ((ground.localScale.x / 2) - 1))
                            , 0.2f
                            , Random.Range(ground.position.z - ((ground.localScale.y / 2) - 1), ground.position.z + ((ground.localScale.y / 2) - 1)));
    }
}
