using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    // The object whose rotation we want to match.
    public Transform target;

    // Angular speed in degrees per sec.
    float speed;

    private void Start()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    void Update()
    {
        Vector3 myLocation = transform.position;
        Vector3 targetLocation = target.position;
        targetLocation.z = myLocation.z; // ensure there is no 3D rotation by aligning Z position

        // vector from this object towards the target location
        Vector3 vectorToTarget = targetLocation - myLocation;
        // rotate that vector by 90 degrees around the Z axis
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;

        // get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
        // (resulting in the X axis facing the target)
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        // changed this from a lerp to a RotateTowards because you were supplying a "speed" not an interpolation value
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
}
