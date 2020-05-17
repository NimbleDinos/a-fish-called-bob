using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFish : MonoBehaviour
{
	public int price;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered");
		if (other.gameObject.tag == "Seller")
		{
			TotalMoney.total += price;
			Debug.Log(TotalMoney.total);
			Destroy(gameObject);
		}
	}
}
