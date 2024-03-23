using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public List<Transform> Points;

    // Start is called before the first frame update
    void Start()
    {
        MeaningPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MeaningPosition();
    }

    private void MeaningPosition()
    {
        transform.position = Vector3.Lerp(Points[0].position, Points[1].position, 0.5f);
    }
}
