using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static string ProcessText(string textin)
    {
       

        string[] valueList = textin.Split(' ');

        int[] numbList = new int[valueList.Length];

        double average = 0;
        double letterList = 0;
       
        if (textin != null)
            {
            

            for (int i = 0; i < valueList.Length; i++){
                numbList[i] = valueList[i].Length;
            }

            for(int i = 0;i < valueList.Length; i++){
                letterList = numbList[i];
            }

            average = letterList/valueList.Length;
            
            
            /*
             string value = textin;
        double number;
            try
            {

                number = double.Parse(textin);
                textin = number.ToString();
                return "The Number is: " + textin;
            }
            catch
            {
                return ("The words are: " + textin);
            }*/
        }
        return average.ToString();
        //return the word string if the the user enters a string 
        //return the word number if the user enters a number
    }  
}

/*
 * public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello, world!");
            
            //Here we are having Unity define our variables for us whether that is an int or bool or string
            var meaningOfLife = 42;
            var smallPi = 3.14;
            var bigPi = 3.14159265359;
            var vaporWare = "Half Life 3";
            const bool likesPizza = true;
            
            //Writing and editing arrays which we will be using later
            string[] writers = {"Brian", "Anthony", "Sean", "Eric"};
            string[] editors = new string[5];
            Console.WriteLine(writers[1]);
            writers[0] = "Ray";
            
            //learning to set variables based on bools
            if(likesPizza == false) {
                Console.WriteLine("You monster!");
            }
            
            bool isMonster = (likesPizza ==true) ? false : true;
            
            //using loops cuz they are cool
            for (int i = 0; i < 10; i++){
                Console.WriteLine("C# Rocks!");
    
            }
            //for loop droping the names of the writers based on the writers array earlier
            for(int i=0; i< writers.Length; i++){
                string writer = writers[i];
                Console.WriteLine(writer);
            }
            //this for each loop is useful for printing arrays
            foreach (string writer in writers){
            Console.WriteLine(writer);
            }
            
            //variable scope is important because it limits what things can be accessed when
            if (meaningOfLife == 42){
             bool inScope = true;   
            }
            
            
            //this is us calling a structure and defineing a point in space
            Point2D myPoint = new Point2D();
            myPoint.X = 10;
            myPoint.Y = 20;
            Point2D anotherPoint = new Point2D();
            anotherPoint.X = 5;
            anotherPoint.Y = 15;
            myPoint.AddPoint(anotherPoint);
            Console.WriteLine(myPoint.X);
            Console.WriteLine(myPoint.Y);
            
            
            Point2D yetAnotherPoint = myPoint;
            yetAnotherPoint.X = 100;
            
            Console.WriteLine(myPoint.X);
            Console.WriteLine(yetAnotherPoint.X);
            
            //calling the class
            Point2DRef pointRef = new Point2DRef();
            pointRef.X = 20;
            Point2DRef anotherRef = pointRef;
            anotherRef.X = 25;
            
            Console.WriteLine(pointRef.X);
            Console.WriteLine(anotherRef.X);
            
            // we will set the Point to null so garbage collection can be called and remove the data
            
            pointRef = null;
            
            anotherRef.X = 125;
            Console.WriteLine(anotherRef.X);
            anotherRef = null;
            
            RenFairePerson person = new RenFairePerson();
            person.Name = "Igor the Ratcatcher";
            baase.SayHello();
            person.SayHello();
        }
    }
    //this is a structure it uses short term computer memory
    struct Point2D{
        public int X;
        public int Y;
        public void AddPoint(Point2D anotherPoint){
            this.X = this.X + anotherPoint.X;
            this.Y = this.Y + anotherPoint.Y;
        }
    }
    // this is a class and uses long term memory
    class Point2DRef{
        public int Y;
        public int X;
        
        public void AddPoint(Point2DRef anotherPoint){
            this.X = this.X + anotherPoint.X;
            this.Y = this.Y + anotherPoint.Y;
        }
    }
    
    //learning inheritance
    class Person{
        public string Name;
        public virtual void SayHello(){
            Console>WriteLine("Hello");
        }
    }
    
    class RenFairePerson : Person{
        public override void SayHello(){
            Console.Write("Huzzah!");
        }
    }
*/


/*instantiating a prefabe for a weapon prjectile
https://docs.unity3d.com/ScriptReference/Object.Instantiate.html Source
    
public Shot projectile;
void Update()
{
    if(Input.GetButtonDown("Space"))
    {
        Shot clone = (Shot)Instantiate(projectime, transform.position, transform.rotation);
}


Generic Instantiate
public SHot shot
void Start()
    {
        Shot shotCopy = Instantiate<Shot>(shot);
    }
 */

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum botStates{
    Search,
    Attack,
    Food,
    Water

}
public class BotController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private botStates bot_State;
    public float run_Speed = 4f;
    public float healDist = 10f;
    public float attackDist = 15f;
    private float current_Dist;
    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_for_This_Time = 5f;
    private float patrol_Timer;
    public float attackTime = 2f;
    public float attack_Timer;

    private Transform target;
    GameObject closestFood = null;
    GameObject closestWater = null;
    public int bFammo = 0;
    public int bWammo = 0;
    public bool Ally = false;
    public int maxHealth = 100;
    public int currentHealth = 100;

    void Awake(){
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        bot_State = botStates.Water;         
    }

    // Update is called once per frame
    void Update()
    {
        if (bot_State == botStates.Food){
            FMode();
        } else if (bot_State == botStates.Water){
            WMode();
        } else if (bot_State == botStates.Attack){
            AMode();
        } else if (bot_State == botStates.Search){
            SMode();
        }
        if (bWammo <= 10){
            bot_State = botStates.Water;
        } else if ( bFammo <= 10){
            bot_State = botStates.Food;
        } else if ( bWammo >= 50 || bFammo >= 100){
            bot_State = botStates.Search;
        }
        if(currentHealth >= maxHealth){
            currentHealth = maxHealth;
        } else if (currentHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    void FMode(){
       MoveToClosestFood(); 
    }

    void WMode(){
        MoveToClosestHandle();
    }

    void AMode(){
        navAgent.isStopped = true;
    }

    void SMode(){
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;

        patrol_Timer += Time.deltaTime;

        if (patrol_Timer > patrol_for_This_Time){
            SetNewRandomDestination();
            patrol_Timer = 0f;
        }

        if(navAgent.velocity.sqrMagnitude > 0){

        }
        if(Vector3.Distance(transform.position, target.position) <= attackDist){
            bot_State = botStates.Attack;
        }
    }

    void SetNewRandomDestination(){
        float rand_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere *rand_Radius;
        randDir += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }

    void MoveToClosestFood(){
        FindClosestFood();
        navAgent.SetDestination(closestFood.transform.position);

    }
    void MoveToClosestHandle(){
        FindClosestWater();
        navAgent.SetDestination(closestWater.transform.position);
    }

    public GameObject FindClosestFood()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Food");
        
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestFood = go;
                distance = curDistance;
            }
        }
        return closestFood;
    }
public GameObject FindClosestWater()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Handle");
        
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestWater = go;
                distance = curDistance;
            }
        }
        return closestWater;
    }
    public void reloadFood(){
        if (bFammo < 100)
        {
            bFammo += 100;
            if(bFammo > 100){
                bFammo = 100;
            }
        }
    }
    public void reloadWater(){
        if (bWammo < 50)
        {
            bWammo += 50;
            Debug.Log(bWammo);
            if(bWammo > 50){
                bWammo = 50;
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if(Ally == true){
            if(col.gameObject.name == "Projectile1"){
                Destroy(col.gameObject);
            } else if(col.gameObject.name == "Projectile2"){
                currentHealth += 25;
                Destroy(col.gameObject);
            }
        }else if(Ally == false){
            if(col.gameObject.name == "Projectile1"){
                currentHealth -= 25;
                Destroy(col.gameObject);
            } else if(col.gameObject.name == "Projectile2"){
                Destroy(col.gameObject);
            }
        }
    }
}
*/
