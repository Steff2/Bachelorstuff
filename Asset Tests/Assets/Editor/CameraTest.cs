using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/*namespace Test
{
    public class Initiating_Tests
    {

        [Test]
        public void Right_Text_Turned_On()
        {
            // Use the Assert class to test conditions.
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator Camera_Test()
        {
            Camera cam1 = new Camera();
            Camera cam2 = new Camera();
            // Use the Assert class to test conditions.
            // yield to skip a frame
            var cameraSwitcher = new GameObject().AddComponent<CameraSwitch>();
            cameraSwitcher.cam1 = cam1;
            cameraSwitcher.cam2 = cam2;
            bool ExpectedBool = cameraSwitcher.cam1.enabled;
            bool ExpectedBool2 = cameraSwitcher.cam2.enabled;

            Assert.AreEqual(ExpectedBool, false);
            Assert.AreEqual(ExpectedBool2, false);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Needle_Positioning()
        {
            RaycastHit hit;
            var Needle_Class = new GameObject().AddComponent<NeedlePlacement>();
            var Marker = Needle_Class.Marker;
            var Tumor = Needle_Class.Tumor;
            var Needle = Needle_Class.Needle;
            var Needle_Position = new GameObject().transform;

            if (Physics.Raycast(Marker.transform.position, Marker.transform.forward, out hit))
            {
                var Direction = Tumor.transform.position - hit.point;
                Needle_Position.position = hit.point - Direction.normalized * 50;
                Needle_Position.LookAt(Tumor.transform);
                Assert.AreEqual(Needle_Position, Needle_Class.EntryDirection);
            }

            Assert.IsNotNull(hit);

            yield return null;
        }
    }
}
*/