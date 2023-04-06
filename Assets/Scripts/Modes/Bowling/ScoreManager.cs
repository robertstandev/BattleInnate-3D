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
		this.textComponent.text = "Waiting for pins physics...";
		Invoke("checkPinsAndDisplayScore", 4f);
	}

	private void checkPinsAndDisplayScore()
	{
		this.score = 0;
		checkPinsRotations();
		checkFallenPins();
		this.textComponent.text = "Score: " + this.score;
	}
	private void checkPinsRotations()
	{
		for (int i = 0 ; i < this.bowlingPins.Length ; i++)
		{
			this.rotationInEuler = this.bowlingPins[i].transform.rotation.eulerAngles;
			if (Mathf.Abs(this.rotationInEuler.x) > 10f || Mathf.Abs(this.rotationInEuler.z) > 10f)
			{
				this.bowlingPins[i].SetActive(false);
			}
			this.rotationInEuler = Vector3.zero;
		}
	}

	private void checkFallenPins()
	{
		for (int i = 0 ; i < this.bowlingPins.Length ; i++)
		{
			if(!this.bowlingPins[i].activeInHierarchy)
			{
				this.score += 1;
			}
		}
	}

	public int getScore() { return this.score; }
}