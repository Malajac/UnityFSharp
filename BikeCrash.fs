namespace FSharp
open UnityEngine
open System.Linq 

type BikeCrash() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable isRidingBike = false

    member this.OnCollisionEnter2D(colinfo : Collision2D) = 

        let isNotGround = 
            match LayerMask.LayerToName(colinfo.collider.gameObject.layer) with 
            | "Ground" -> false
            | "Sand" -> false
            | _ -> true
        
        let isNotBike = 
            match colinfo.gameObject.tag with
            | "Bike" -> false
            | _ -> true

        let doProcessing = isNotGround && isNotBike

        if doProcessing
        then 
            let mutable isBikeHit = false
            for cp in colinfo.contacts do
                if cp.otherCollider.gameObject.tag = "Bike" then isBikeHit <- true

            let isBossHit = colinfo.contacts.Any( fun(c) -> c.collider.tag = "Boss")

            if isRidingBike
            then 
                isRidingBike <- false                                
                this.BroadcastMessage("OnBikeCrash", SendMessageOptions.DontRequireReceiver)
                if isBossHit 
                then
                    GameObject.FindGameObjectsWithTag("Boss").ToList().ForEach(
                         fun(go) -> go.BroadcastMessage("OnBikeCrashBoss", SendMessageOptions.DontRequireReceiver))


    member this.OnBikeMount() =
        isRidingBike <- true

