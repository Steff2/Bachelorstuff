using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Movement_Positioning_Test {

	[UnityTest]
	public IEnumerator Movement_Positioning() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        GameObject Needle = new GameObject();
        GameObject Seed = new GameObject();

        if (Input.GetMouseButton(0))
        {
            Needle.transform.localPosition += Needle.transform.forward;
            Assert.AreEqual(Needle.transform.forward, Needle.transform.localPosition);
        }

        if (Input.GetMouseButton(1))
        {
            Needle.transform.localPosition -= Needle.transform.forward;
            Assert.AreEqual(-Needle.transform.forward, Needle.transform.localPosition);
        }

        yield return null;
	}
}
