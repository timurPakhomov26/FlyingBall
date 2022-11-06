using System.Collections;
using UnityEngine;


public class CameraFlow : MonoBehaviour
{
    [SerializeField] private float _speedOfflow;
    [SerializeField] private Transform _cameraCenter;
    private Conditions _condition;

    public void StartFollow()
    {
      StartCoroutine(FindCameraCentr());     
    }

    private void LateUpdate()
    {
      if(_cameraCenter != null)
         transform.position = Vector3.Lerp(transform.position,_cameraCenter.position,Time.deltaTime*_speedOfflow);         
    }

    private IEnumerator FindCameraCentr()
    {
       if(_cameraCenter == null && UiController.Condition == Conditions.Game) 
          yield return null;

        yield return new WaitForEndOfFrame();
        _cameraCenter = FindObjectOfType<Player>().transform;
    }
}
