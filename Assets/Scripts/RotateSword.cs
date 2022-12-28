using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSword : MonoBehaviour
{
    public void Rotate()
    {
        float l_Rotation = this.gameObject.GetComponent<RectTransform>().eulerAngles.z + 45.0f;
        SetRotation(l_Rotation);
    }

    public void SetRotation(float Angle)
    {
        this.gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, Angle);

        if (this.gameObject.GetComponent<RectTransform>().eulerAngles.z == 360.0f || this.gameObject.GetComponent<RectTransform>().eulerAngles.z < 0.0f)
            this.gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

    }

    public bool CheckRotation(float Angle)
    {
        return this.gameObject.GetComponent<RectTransform>().eulerAngles.z <= Angle + 1.0f && this.gameObject.GetComponent<RectTransform>().eulerAngles.z >= Angle - 1.0f;
    }
}
