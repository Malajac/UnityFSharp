namespace FSharp
open UnityEngine
 
type BossBeat() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable isBossBeat = false

    [<SerializeField>]
    let bossNo: int = 0
    
    member this.OnBikeCrash() =
        Debug.Log("Bike Crashed")

    member this.OnBikeCrashBoss() =
        isBossBeat <- true
        Debug.Log("Boss " + bossNo.ToString() + " beat")