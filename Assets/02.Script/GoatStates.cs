using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoatStates
{
    public class Patrol : State<Goat>
    {
        public Vector3 FirstLocation;
        public Vector3 SecondLocation;
        private bool isFirstGo = true;
        private float MovingDistance = 2.0f;
        
        public override void Enter(Goat entity)
        {
            Debug.Log("Patrol!");
            FirstLocation = entity.firstLocation;
            SecondLocation = entity.secondLocation;
            int x = UnityEngine.Random.Range(-45, 42);
            int z = UnityEngine.Random.Range(-44, 51);
            FirstLocation.x = x;
            FirstLocation.z = z;
            SecondLocation.x = x;
            SecondLocation.z = z;
            isFirstGo = true;
            state_name = "Patrol";
            entity.transform.LookAt(FirstLocation);
        }
        public override void Action(Goat entity)
        {
            if (isFirstGo)
            {
                entity.transform.Translate((FirstLocation - entity.transform.position) * Time.deltaTime * entity.speed, Space.World);
                if (MovingDistance > Vector3.Distance(entity.transform.position, FirstLocation))
                {
                    int x = UnityEngine.Random.Range(-45, 42);
                    int z = UnityEngine.Random.Range(-44, 51);
                    FirstLocation.x = x;
                    FirstLocation.z = z;
                    SecondLocation.x = x;
                    SecondLocation.z = z;
                    entity.transform.LookAt(SecondLocation);
                    isFirstGo = false;
                }
            }
            else
            {
                entity.transform.Translate((SecondLocation - entity.transform.position) * Time.deltaTime * entity.speed, Space.World);
                if (MovingDistance > Vector3.Distance(entity.transform.position, SecondLocation))
                {
                    int x = UnityEngine.Random.Range(-45, 42);
                    int z = UnityEngine.Random.Range(-44, 51);
                    FirstLocation.x = x;
                    FirstLocation.z = z;
                    SecondLocation.x = x;
                    SecondLocation.z = z;
                    entity.transform.LookAt(FirstLocation);
                    isFirstGo = true;
                }
            }
        }
        public override void Exit(Goat entity)
        {
        }
    }
    public class FindPlant : State<Goat>
    {
        public CPlant Plant;
        private float MovingDistance = 2.0f;

        public override void Enter(Goat entity)
        {
            Debug.Log("Find!");
            Plant = entity.target;
            entity.transform.LookAt(Plant.gameObject.transform);
            state_name = "Find";
        }
        public override void Action(Goat entity)
        {
            entity.transform.Translate((Plant.gameObject.transform.position - entity.transform.position) * Time.deltaTime * entity.speed,Space.World);
            if(MovingDistance > Vector3.Distance(entity.transform.position, Plant.transform.position))
            {
                EatPlant eat = new EatPlant();
                entity.ChangeState(eat);
            }
            if(!Plant.gameObject.activeSelf)
            {
                Patrol patrol = new Patrol();
                entity.ChangeState(patrol);
            }
        }
        public override void Exit(Goat entity)
        {
        }
    }
    public class EatPlant : State<Goat>
    {
        public CPlant Plant;

        public override void Enter(Goat entity)
        {
            Debug.Log("Eat!");
            Plant = entity.target;
            state_name = "Eat";
            entity.anim.SetTrigger("TriggerEat");
        }
        public override void Action(Goat entity)
        {
            if (entity.EatComplete)
            {
                Plant.Clean();
                Plant.gameObject.SetActive(false);
                entity.EatComplete = false;
            }
            if(!Plant.gameObject.activeSelf)
            {
                Patrol patrol = new Patrol();
                entity.ChangeState(patrol);
                entity.EatComplete = false;
            }
        }
        public override void Exit(Goat entity)
        {
        }
    }
}
