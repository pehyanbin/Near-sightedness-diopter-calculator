using System;

namespace MySpace
{
    class CalNearsightedness
    {
        public double focal_length;
        public double diopter_value;
        public double refractive_error;


        public virtual double getInput()
        {
            Console.WriteLine("How much distance your vision starts blur ? ( Maximum distance for clear vision ) In cm");
            focal_length = Convert.ToDouble(Console.ReadLine());
            focal_length = focal_length / 100;
            return focal_length;
        }

        public virtual double calculateDiopter(double focal_length)
        {
            diopter_value = 1 / focal_length;
            return diopter_value;
        }

        public virtual double calculateOutput(double diopter_value)
        {
            refractive_error = diopter_value * 100;
            return refractive_error;
        }

        public virtual void DisplayResult(double focal_length, double diopter_value, double refractive_error)
        {
            Console.WriteLine($"\n\nFocal Length : {focal_length}m  ({focal_length*=100}cm)\nDiopter value : {diopter_value}\nRefractive error : {refractive_error}°\n\n");
        }
    }

    class ReverseCalFocalLength : CalNearsightedness
    {
        public override double getInput()
        {
            Console.WriteLine("How much is your short-sigtedness degree ? ");
            refractive_error = Convert.ToDouble(Console.ReadLine());
            return refractive_error;
        }

        public override double calculateDiopter(double refractive_error)
        {
            diopter_value =refractive_error / 100;
            return diopter_value;
        }

        public override double calculateOutput(double diopter_value)
        {
            focal_length = 1 / diopter_value;
            focal_length *= 100; //conversion from meters to centimeters
            return focal_length;
        }

        public override void DisplayResult(double refractive_error, double diopter_value, double focal_length)
        {
            Console.WriteLine($"\n\nRefractive error : {refractive_error}º\nDiopter value : {diopter_value}\nFocal Length : {focal_length}cm\n\n");
        }
    }

    class ProgramFunctions
    {
        public void Function1()
        {
            CalNearsightedness shortsight_index = new CalNearsightedness();

            double cal1_f;
            cal1_f = shortsight_index.getInput();

            double cal2_d;
            cal2_d = shortsight_index.calculateDiopter(cal1_f);

            double cal3_re;
            cal3_re = shortsight_index.calculateOutput(cal2_d);

            shortsight_index.DisplayResult(cal1_f, cal2_d, cal3_re);
        }


        public void Function2()
        {
            ReverseCalFocalLength focal_distance = new ReverseCalFocalLength();

            double cal1_re;
            cal1_re = focal_distance.getInput();

            double cal2_d;
            cal2_d = focal_distance.calculateDiopter(cal1_re);

            double cal3_f;
            cal3_f = focal_distance.calculateOutput(cal2_d);

            focal_distance.DisplayResult(cal1_re, cal2_d, cal3_f);
        }
    }

    class Program
    {
        public static void function_to_run()
        {
            while (true)
            {
                Console.WriteLine("Choose your function to run: \nA. Calculate Short-sightedness index\nB. Calculate focal length\nX. Exit program\n");
                string choice;
                choice = Console.ReadLine();


                if (choice == null)
                {
                    Console.WriteLine("Choice cannot be null");
                    continue;
                }
                else if (choice == "A" || choice == "a")
                {
                    ProgramFunctions functionRun = new ProgramFunctions();
                    functionRun.Function1();
                }
                else if (choice == "B" || choice == "b")
                {
                    ProgramFunctions functionRun = new ProgramFunctions();
                    functionRun.Function2();
                }
                else
                {
                    Console.WriteLine("End of Program.\nBye bye.");
                    break;
                }
            }




        }

        public static void Main(string[] args)
        {
            function_to_run();




        }
    }
}