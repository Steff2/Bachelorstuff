using UnityEngine;

public class EntrypointPosition : MonoBehaviour {

    public GameObject entryPoint1;
    public GameObject entryPoint2;
    public GameObject entryPoint3;
    public GameObject entryPoint4;
    public GameObject entryPoint5;

    public GameObject needle1;
    public GameObject needle2;
    public GameObject needle3;
    public GameObject needle4;
    public GameObject needle5;

    public GameObject OP_Plan1;
    public GameObject OP_Plan2;
    public GameObject OP_Plan3;
    public GameObject OP_Plan4;
    public GameObject OP_Plan5;

    Vector3 first_point_vector;
    Vector3 second_point_vector;
    Vector3 third_point_vector;
    Vector3 fourth_point_vector;
    Vector3 fifth_point_vector;

    Renderer ren;
    Material[] mat;

    public GameObject tumorPoint;

    int position_counter;

    // Use this for initialization
    void Start () {

        GameObject.Find("ScriptManager").GetComponent<Needle_Movement>().enabled = false;
        position_counter = 1;

        first_point_vector = entryPoint1.transform.position - tumorPoint.transform.position;
        second_point_vector = entryPoint2.transform.position - tumorPoint.transform.position;
        third_point_vector = entryPoint3.transform.position - tumorPoint.transform.position;
        fourth_point_vector = entryPoint4.transform.position - tumorPoint.transform.position;
        fifth_point_vector = entryPoint5.transform.position - tumorPoint.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                position_counter--;

                if (position_counter == 0)
                {
                    position_counter = 5;
                }

                if (position_counter == 1)
                {
                    gameObject.transform.position = entryPoint1.transform.position - 60 * first_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 2)
                {
                    gameObject.transform.position = entryPoint2.transform.position - 60 * second_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 3)
                {
                    gameObject.transform.position = entryPoint3.transform.position - 10 * third_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 4)
                {
                    gameObject.transform.position = entryPoint4.transform.position - 10 * fourth_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 5)
                {
                    gameObject.transform.position = entryPoint5.transform.position - 60 * fifth_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                position_counter++;
            
                if (position_counter == 6)
                {
                    position_counter = 1;
                }

                if (position_counter == 1)
                {
                    gameObject.transform.position = entryPoint1.transform.position - 60 * first_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 2)
                {
                    gameObject.transform.position = entryPoint2.transform.position - 60 * second_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 3)
                {
                    gameObject.transform.position = entryPoint3.transform.position - 10 * third_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

                if (position_counter == 4)
                {
                    gameObject.transform.position = entryPoint4.transform.position - 10 * fourth_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }

            if (position_counter == 5)
                {
                    gameObject.transform.position = entryPoint5.transform.position - 60 * fifth_point_vector.normalized;
                    gameObject.transform.LookAt(tumorPoint.transform.position);
                    gameObject.transform.Rotate(-90, 0, 0);
                }
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(position_counter == 1)
                {
                    ren = needle1.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan1.SetActive(true);
                }

                if (position_counter == 2)
                {
                    ren = needle2.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan2.SetActive(true);
                }

                if (position_counter == 3)
                {
                    ren = needle3.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan3.SetActive(true);
                }

                if (position_counter == 4)
                {
                    ren = needle4.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan4.SetActive(true);
                }

                if (position_counter == 5)
                {
                    ren = needle5.GetComponent<Renderer>();
                    mat = ren.materials;
                    mat[0].color = Color.yellow;
                    OP_Plan5.SetActive(true);
                }

            gameObject.transform.position = new Vector3(-25, -20, -570);
            Quaternion desiredRotation = Quaternion.Euler(90, 90, 0);
            gameObject.transform.rotation = desiredRotation;

            GameObject.Find("ScriptManager").GetComponent<Needle_Movement>().enabled = true;
            gameObject.GetComponent<EntrypointPosition>().enabled = false;
            }

    }
}
