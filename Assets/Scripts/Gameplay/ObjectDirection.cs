using UnityEngine;

public class ObjectDirection
{
    private const float _thresHold = 0.001f;
    
    public void FaceDirection(Transform transform, float value)
    {
        Vector3 transformScale = transform.localScale;

        if (value < -_thresHold)
        {
            transformScale.x = -Mathf.Abs(transformScale.x);
        }
        else if (value > _thresHold)
        {
            transformScale.x = Mathf.Abs(transformScale.x);
        }

        transform.localScale = transformScale;
    }
}

