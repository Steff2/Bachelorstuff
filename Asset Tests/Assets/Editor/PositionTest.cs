using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PositionTest
{

    [UnityTest]
    public IEnumerator Phase1Testing()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool Phase1 = false;
        bool Phase2 = false;

        Text Test_Planning_Text = new GameObject().AddComponent<Text>();
        Text Test_Marking_Text = new GameObject().AddComponent<Text>();
        Text Test_Placement_Text = new GameObject().AddComponent<Text>();

        GameObject needle = new GameObject();
        GameObject Marker = new GameObject();

        Test_Planning_Text.enabled = false;
        Test_Marking_Text.enabled = false;
        Test_Placement_Text.enabled = false;
        Phase1 = true;

        Assert.False(Test_Planning_Text.enabled);
        Assert.False(Test_Marking_Text.enabled);
        Assert.False(Test_Placement_Text.enabled);
        Assert.True(Phase1);

        Camera Cam = new GameObject().AddComponent<Camera>();
        var Fixpoint = new GameObject();

        Fixpoint.transform.position = new Vector3(100, 100, 100);
        Cam.transform.position = Fixpoint.transform.position;

        Assert.AreEqual(Fixpoint.transform.position, Cam.transform.position);

        Cam.transform.localPosition = new Vector3(0, 0, -200f);

        Assert.AreEqual(new Vector3(0, 0, -200), Cam.transform.localPosition);

        needle.SetActive(false);

        Phase2 = true;
        Test_Planning_Text.enabled = true;

        Assert.True(Test_Planning_Text.enabled);
        Assert.True(Phase2);

        yield return null;
    }
    [UnityTest]
    public IEnumerator Phase2Testing()
    {
        bool Phase3 = false;

        Text Test_Marking_Text = new GameObject().AddComponent<Text>();
        Text Test_Planning_Text = new GameObject().AddComponent<Text>();

        GameObject Marker = new GameObject();
        GameObject CameraSkinPoint = new GameObject();

        Assert.True(Test_Marking_Text.enabled);

        CameraSkinPoint.transform.position = new Vector3(30, 120, 7);

        Marker.transform.position = CameraSkinPoint.transform.position;

        Assert.AreEqual(CameraSkinPoint.transform.position, Marker.transform.position);

        Phase3 = true;

        Assert.True(Phase3);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Phase3 = true;
            Test_Planning_Text.enabled = false;

            Assert.True(Phase3);
            Assert.False(Test_Planning_Text.enabled);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator Phase3Testing()
    {
        bool Phase4 = false;

        Camera Cam = new GameObject().AddComponent<Camera>();

        Cam.enabled = false;

        Assert.False(Cam.enabled);

        Phase4 = true;

        Assert.True(Phase4);

        yield return null;
    }
    [UnityTest]
    public IEnumerator Phase4Testing()
    {
        bool Phase5 = false;

        GameObject Marker = new GameObject();
        Text Test_Marking_Text = new GameObject().AddComponent<Text>();

        if (Input.GetKey(KeyCode.A))
        {
            Marker.transform.localPosition += new Vector3(-1f, 0, 0);
            Assert.AreEqual(new Vector3(-1f, 0, 0), Marker.transform.localPosition);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Marker.transform.localPosition += new Vector3(0, 1f, 0);
            Assert.AreEqual(new Vector3(0f, 1f, 0), Marker.transform.localPosition);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Marker.transform.localPosition += new Vector3(1f, 0, 0);
            Assert.AreEqual(new Vector3(1f, 0, 0), Marker.transform.localPosition);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Marker.transform.localPosition += new Vector3(0, -1f, 0);
            Assert.AreEqual(new Vector3(0, -1f, 0), Marker.transform.localPosition);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Phase5 = true;

            Assert.True(Phase5);

            Test_Marking_Text.enabled = false;

            Assert.False(Test_Marking_Text.enabled);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator Phase5Testing()
    {
        GameObject Marker = new GameObject();
        GameObject needle = new GameObject();
        GameObject Cylinder = new GameObject();

        RaycastHit hit;

        Text Test_Placement_Text = new GameObject().AddComponent<Text>();

        Test_Placement_Text.enabled = false;
        bool Phase6 = false;

        Marker.transform.position = new Vector3(40, 50, 120);

        if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
        {
            var Normal_Hit_Vector = hit.normal.normalized;

            needle.transform.position = hit.point;

            Assert.AreEqual(Marker.transform.position, hit.point);

            needle.transform.LookAt(hit.point);

            if (Physics.Raycast(needle.transform.position, needle.transform.forward, out hit))
            {
                Assert.AreEqual(hit.point, Marker.transform.position);
            }


            Cylinder.transform.localPosition = new Vector3(0, 0, 60);

            Assert.AreEqual(new Vector3(0, 0, 60), Cylinder.transform.localPosition);

        }

        Test_Placement_Text.enabled = true;
        Phase6 = true;

        Assert.True(Phase6);
        Assert.True(Test_Placement_Text.enabled);

        yield return null;
    }

    [UnityTest]
    public IEnumerator Phase6Testing()
    {
        NeedleMovement ascript = new GameObject().AddComponent<NeedleMovement>();
        Text Test_Placement_Text = new GameObject().AddComponent<Text>();

        bool Phase7 = false;
        ascript.enabled = false;

        Assert.False(ascript.enabled);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Test_Placement_Text.enabled = false;
            Phase7 = true;
            ascript.enabled = true;

            Assert.False(Test_Placement_Text.enabled);
            Assert.True(Phase7);
            Assert.True(ascript.enabled);
        }


        yield return null;
    }
}
