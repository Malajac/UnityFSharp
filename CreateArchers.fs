namespace FSharp
open UnityEngine
 
type CreateArchers() = 
    inherit MonoBehaviour()

    [<SerializeField>]    
    let archer : GameObject = null;
    [<SerializeField>]    
    let mutable gun : GameObject = null;

    
    member this.Start() = 
        Debug.Log("Start")
        this.Invoke("SpawnEnemy", 5.0f)

    member this.SpawnEnemy() =
        let heroTransform = GameObject.Find("Hero").gameObject.transform
        let heroPosition = heroTransform.position
        let enemyPosition = new Vector3(heroPosition.x - 1.0f, heroPosition.y, heroPosition.z)
        let gunPosition = new Vector3(heroPosition.x + 0.5f, heroPosition.y, heroPosition.z)

        let enemy = GameObject.Instantiate(archer, enemyPosition, Quaternion.identity)
        let gun = GameObject.Instantiate(gun, gunPosition, Quaternion.identity)
        ()