using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
	Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
}
