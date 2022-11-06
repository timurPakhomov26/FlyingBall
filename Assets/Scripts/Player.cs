using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
   public static float HorizontalSpeed = 2f;
   [SerializeField] private float _verticalSpeedAdditional = 0.5f;
   [SerializeField] private float _verticalSpeed = 2f;

   private Rigidbody _rigidbody;
   private const float TimeForAdditional = 7f;
   private float _time;
   

    private void OnCollisionEnter(Collision other) 
    {
       if(other.gameObject.CompareTag("Enemy"))
       {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          UiController.Condition = Conditions.EndGame;
       }  
    }
 }
  

