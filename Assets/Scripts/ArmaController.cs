using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour
{
    [SerializeField]
    BoxCollider swordCollider;

	void Start()
	{
		DesactivarArmas();
	}
	
	private void DesactivarArmas()
	{
		swordCollider.enabled = false;
	}
	
	private void ActivarArmas()
	{
		swordCollider.enabled = true;
	}
	
}
