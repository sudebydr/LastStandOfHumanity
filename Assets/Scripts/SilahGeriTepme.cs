using UnityEngine;

public class SilahGeriTepme : MonoBehaviour
{
  public Transform geriTepmePositionTransform;
  public Transform geriTepmeRotationTransform;
  
  public float yavaşlamaSuresiPosition;
  public float yavaşlamaSuresiRotation;
  
  public float geriTepme1;
  public float geriTepme2;
  public float geriTepme3;
  public float geriTepme4;
  
  public Vector3 geriTepmeRotation;
  public Vector3 geriTepmeKickBack;

  public Vector3 geriTepmeRotationHedef;
  public Vector3 geriTepmeKickBackHedef;
  
  public Vector3 güncelGeriTepme1;
  public Vector3 güncelGeriTepme2;
  public Vector3 güncelGeriTepme3;
  public Vector3 güncelGeriTepme4;


  public Vector3 rotationOutput;

  public bool hedef;


  void FixedUpdate()
  {
    güncelGeriTepme1 = Vector3.Lerp(güncelGeriTepme1, Vector3.zero, geriTepme1 * Time.deltaTime);
    güncelGeriTepme2 = Vector3.Lerp(güncelGeriTepme2, güncelGeriTepme1, geriTepme2 * Time.deltaTime);
    güncelGeriTepme3 = Vector3.Lerp(güncelGeriTepme3, Vector3.zero, geriTepme3 * Time.deltaTime);
    güncelGeriTepme4 = Vector3.Lerp(güncelGeriTepme4, güncelGeriTepme3, geriTepme4 * Time.deltaTime);

    geriTepmePositionTransform.localPosition = Vector3.Slerp(geriTepmePositionTransform.localPosition, güncelGeriTepme3, yavaşlamaSuresiPosition * Time.fixedDeltaTime);
    rotationOutput = Vector3.Slerp(rotationOutput, güncelGeriTepme1, yavaşlamaSuresiRotation * Time.fixedDeltaTime);
    geriTepmeRotationTransform.localRotation = Quaternion.Euler(rotationOutput);
  }
  public void Fire()
  {
    if (hedef == true)
    {
      güncelGeriTepme1 += new Vector3(geriTepmeRotationHedef.x, Random.Range(-geriTepmeRotationHedef.y, geriTepmeRotationHedef.y), Random.Range(-geriTepmeKickBackHedef.z, geriTepmeKickBackHedef.z));
      güncelGeriTepme3 += new Vector3(Random.Range(-geriTepmeKickBackHedef.x, geriTepmeKickBackHedef.x), Random.Range(-geriTepmeKickBackHedef.y, geriTepmeKickBackHedef.y), geriTepmeKickBackHedef.z);
    }
    if (hedef == false)
    {
      güncelGeriTepme1 += new Vector3(geriTepmeRotation.x, Random.Range(-geriTepmeRotation.y, geriTepmeRotation.y), Random.Range(-geriTepmeRotation.z, geriTepmeRotation.z));
      güncelGeriTepme3 += new Vector3(Random.Range(-geriTepmeKickBackHedef.x, geriTepmeKickBackHedef.x), Random.Range(-geriTepmeKickBackHedef.y, geriTepmeKickBackHedef.y), geriTepmeKickBackHedef.z);
    }

  } 
}
