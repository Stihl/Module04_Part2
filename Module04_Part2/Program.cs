using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Alexander Hamilton Gregg 2/17/19 
 * Module04_Homework
 */

namespace Module04_Part2
{
    //Declares an enumeration of directions
    enum Direction
    {
        Left,
        Right,
        Forward,
        Back
    }

    //Creating a delegate
    delegate int Function(int x);

    class Program
    {
        static void Main(string[] args)
        {
            //reference parameter example and class example
            #region
            int x = 4, y = 2;
            Console.WriteLine($"x is {x}, y is {y}");

            //Passes x and y by reference to the static Swap method to swap their values
            RefExample.Swap(ref x,ref y);
            Console.WriteLine($"x is now {x}, y is now {y}");
            #endregion

            //static and instance members and second class example;
            #region
            Entity en;
            Entity en1;
            en = new Entity();

            //Call of an instance method
            Console.WriteLine(en.GetSerialNo().ToString());

            //Call of a static method  -- Applies to class in the broad sense
            Entity.SetNextSerialNo(2331);
            Console.WriteLine("Next serial number was set to: 2331");

            //Create an instance and call an instance method after the static method has modified the static field
            en1 = new Entity();
            Console.WriteLine(en1.GetSerialNo().ToString());
            #endregion

            //Boxing Example
            #region

            int someInt = -465;
            object o = someInt; //Boxing  -- generic object type
            int j = (int)o;     //Unboxing
            #endregion

            //Use of yield statement in the Range IEnumerator
            #region
            foreach (int i in Range(-10, 10))
            {
                Console.WriteLine(i);
            }
            #endregion

            //Creating a direction enumeration from the direction enumeration left
            #region
            Direction left = Direction.Left;
            
            //Passing enumerations
            FaceDirection(left);
            FaceDirection(Direction.Forward);
            FaceDirection(Direction.Back);
            #endregion

            //Using a Delegate
            #region
            PrintAnInt(j, Math.Abs);
            #endregion

            Console.ReadKey();

        }

        //Using a delegate
        static void PrintAnInt(int x, Function f)
        {
            int absolute = f(x);
            Console.WriteLine($"The Absolute Value of {x} is {absolute}");
        }

        //Selects a direction to turn a character based on an enumeration.
        static void FaceDirection(Direction color)
        {
            switch (color)
            {
                case Direction.Left:
                    Console.WriteLine("Turn character left");
                    break;
                case Direction.Right:
                    Console.WriteLine("Turn character right");
                    break;
                case Direction.Forward:
                    Console.WriteLine("Face character forward");
                    break;
                case Direction.Back:
                    Console.WriteLine("Turn character around");
                    break;
                default:
                    Console.WriteLine("Sorry, 2D game here, not 3D.");
                    break;
            }
        }

        //An iteratable enumerator of type int named range
        static System.Collections.Generic.IEnumerable<int> Range(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                yield return i;
            }
            yield break;
        }
    }
    //Passing by reference and first class/object example
    class RefExample
    {
        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }

    //static and second class example
    class Entity
    {
        static int nextSerialNo;
        int serialNo;
        public Entity()
        {
            serialNo = nextSerialNo++;
        }
        public int GetSerialNo()
        {
            return serialNo;
        }
        public static int GetNextSerialNo()
        {
            return nextSerialNo;
        }
        public static void SetNextSerialNo(int value)
        {
            nextSerialNo = value;
        }
    }
}
