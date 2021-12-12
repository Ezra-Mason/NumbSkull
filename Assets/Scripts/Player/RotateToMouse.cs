using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            target = hit.point;
            Debug.DrawLine(ray.origin, target, Color.cyan);
        }
        Vector3 lookDir = (target - transform.position).normalized;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);
    }
}
