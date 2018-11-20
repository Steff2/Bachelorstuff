using UnityEngine;
using System.Collections;


/// <summary>
/// Class for convenience
/// <summary>
public class ActiveStateToggler : MonoBehaviour {

	public void ToggleActive () {
		gameObject.SetActive (!gameObject.activeSelf);
	}
}
