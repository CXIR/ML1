using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryInteractionScript : MonoBehaviour
{
    public Transform[] _plan;
    public Transform[] _red;

    public IntPtr _w;

    // Start is called before the first frame update
    void Start()
    {
        _w = new IntPtr();

        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();

        foreach (Transform sphere in _red)
        {
            inputs.Add(sphere.position.x);
            inputs.Add(sphere.position.z);
            outputs.Add(sphere.position.y);
        }

       _w = LibraryWraper.Initialize(2);

        double[] i = inputs.ToArray();
        double[] o = inputs.ToArray();

        LibraryWraper.Train(_w, i, 2, _red.Length, o, 0.001, 100);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform sphere in _plan)
        {
            List<double> localPositions = new List<double>()
            {
                sphere.position.x,
                sphere.position.z
            };
            int predict = LibraryWraper.Predict(_w, localPositions.ToArray(), 2);

            Vector3 item = new Vector3(sphere.position.x, sphere.position.y, sphere.position.z)
            {
                y = (predict == -1) ? -1 : 1
            };

            sphere.position = item;
        }
    }
}
