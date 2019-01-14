using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueId : MonoBehaviour {

	public string Id;

	void Start () {
		Id = System.Guid.NewGuid().ToString();
	}
}
