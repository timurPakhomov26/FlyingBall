using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private float _maxCreateLenght = 20f;
    private float _minCreateLenght = 10f;
   

  private void OnEnable()
   {
     PlayerCreator.CreateEnemy += CreateEnemyes;
   }

  private void OnDisable() 
   {
     PlayerCreator.CreateEnemy -= CreateEnemyes;  
   }
   
    
   private void Update()
    {
        var randomLenght = Random.Range(_maxCreateLenght,_minCreateLenght);  
    }

    private void  CreateEnemyes()
    {
      var player = FindObjectOfType<Player>().transform;
      var randomYPosition = Random.Range(1,8);
      var spawnPoint = new Vector3(player.transform.position.x,randomYPosition,
          player.transform.position.z + 18f);
          
      var newEnemy = Instantiate(_enemyPrefab,spawnPoint, Quaternion.identity);
      Destroy(newEnemy,9f);
       
    }
}
