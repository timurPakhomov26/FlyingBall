using UnityEngine;


public class PlayerCreator : MonoBehaviour
{
   public delegate void MovingHandler();
   public static event MovingHandler CreateEnemy;
   public const float TimeForAdditional = 7f;
  
   [SerializeField] private GameObject _playerPrefab;
   [SerializeField] private float _horizontalSpeed = 3f;
   [SerializeField] private float _verticalSpeedAdditional = 0.5f;
   [SerializeField] private float _verticalSpeed = 2f;
   [SerializeField] private float _minCreateLenght = 10f, _maxCreateLenght = 20f;     
   [SerializeField] Transform _spawn;
   private static Transform _player;
   private float _time;
   private Vector3 _startPosition;
   private Transform _currentPosition;

    private void Update() 
    {           
       VerticalSpeedIncrease();
       Move();
       MeasureTheTraveled();
    }
    
    public void Create()
    {
      _player = Instantiate(_playerPrefab.transform,transform.position, Quaternion.identity);
    }

   public void SetSpeed(float speed)
    {
       _horizontalSpeed = speed;       
    }

   private void Move()
    {   
       if(_player == null) 
           return;
           
         var upDirection = Input.GetKey(KeyCode.W) ?  1f : -1f; 
         _player.GetComponent<Rigidbody>().velocity = new Vector3(0, upDirection * _verticalSpeed , _horizontalSpeed);          
    }

    private void VerticalSpeedIncrease()
    {
       _time += Time.deltaTime;

       if(_time >= TimeForAdditional)
       {
         _time = 0;
          _verticalSpeed += _verticalSpeedAdditional;
       }       
    }
    private void MeasureTheTraveled()
    {
      if(_player == null)
        return; 

       _startPosition = transform.position;
       var randomDistance = Random.Range(_minCreateLenght,_maxCreateLenght);

       if(Vector3.Distance(_startPosition,_player.transform.position) >= randomDistance) 
       {
           CreateEnemy?.Invoke();   
          transform.position = _player.position;
         _startPosition = transform.position;
       }          
    }
}
