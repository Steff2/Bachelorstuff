using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverCollisionScript : MonoBehaviour {

    public GameObject GameOver;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("BloodVessel"))
        {
            GameOver.GetComponent<Text>().enabled = true;
            StartCoroutine(Example());
            AppHelper.Quit();
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(4);
    }
}
