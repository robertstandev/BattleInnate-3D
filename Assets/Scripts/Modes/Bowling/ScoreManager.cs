using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IOnTriggerAction
{
	[SerializeField]private Text textComponent;
    [SerializeField]private GameObject[] bowlingPins;
	private int score;
	private Vector3 rotationInEuler;

	public void activateTriggerEvent(GameObject triggeredObject)
	{
		textComponent.text = "Waiting for pins physics...";
		Invoke("checkPinsAndDisplayScore", 4f);
	}

	private void checkPinsAndDisplayScore()
	{
		score = 0;
		checkPinsRotations();
		checkFallenPins();
		textComponent.text = "Score: " + score;
	}
	private void checkPinsRotations()
	{
		for (int i = 0 ; i < bowlingPins.Length ; i++)
		{
			rotationInEuler = bowlingPins[i].transform.rotation.eulerAngles;
			if (Mathf.Abs(rotationInEuler.x) > 10f || Mathf.Abs(rotationInEuler.z) > 10f)
			{
				bowlingPins[i].SetActive(false);
			}
			rotationInEuler = Vector3.zero;
		}
	}

	private void checkFallenPins()
	{
		for (int i = 0 ; i < bowlingPins.Length ; i++)
		{
			if(!bowlingPins[i].activeInHierarchy)
			{
				score += 1;
			}
		}
	}

	public int getScore() { return this.score; }
}