using UnityEngine;

public class GunSway : MonoBehaviour
{
    [SerializeField] private float _smooth;
    [SerializeField] private float _swayMultiplier;

    private void Update()
    {
        CalculateGunSway();
    }

    private Quaternion CalculateAnlgeAxis(float mouseX, float mouseY)
    {
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.right);
        Quaternion targetRotation = rotationX * rotationY;
        return targetRotation;
    }

    private void CalculateGunSway()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _swayMultiplier;
        var targetRotation = CalculateAnlgeAxis(mouseX, mouseY);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);
    }
}
