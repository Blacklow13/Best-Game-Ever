using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0f, 1f)]
    public float value ;

    public Transform Red;

    public Transform Blue;

    public Material Cube_;

    public Material Cube2;

    public Material cube3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(Red.transform.position, Blue.transform.position, value);
        transform.localScale = Vector3.Lerp(Red.localScale, Blue.localScale, value);
        cube3.color = Color.Lerp(Cube_.color, Cube2.color, value);
    }
}
