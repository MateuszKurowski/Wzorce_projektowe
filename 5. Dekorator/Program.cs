using System;
using System.Collections.Generic;

namespace _5._Dekorator
{
    public interface IExercise
    {
        void JustDoIt();
        void AddEquipment(string equipmentName);
    }

    public class Exercise : IExercise
    {
        public List<string> _requiredEquipment = new();

        public List<string> RequiredEquipment { get => _requiredEquipment; }

        public void AddEquipment(string equipmentName) => RequiredEquipment.Add(equipmentName);

        public void JustDoIt()
        {
            Console.WriteLine("I need to pack:");
            RequiredEquipment.Reverse();
            RequiredEquipment.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Starting exercise");
        }
    }

    public abstract class ExerciseEquipmentDecorator : IExercise
    {
        IExercise _exercise;

        public ExerciseEquipmentDecorator(IExercise exercise)
        {
            _exercise = exercise;
        }

        public virtual void JustDoIt() => _exercise.JustDoIt();

        public void AddEquipment(string equipmentName) => _exercise.AddEquipment(equipmentName);
    }

    public class RunningEquipment : ExerciseEquipmentDecorator
    {
        public RunningEquipment(IExercise exercise) : base(exercise)
        {
            exercise.AddEquipment("shoes");
        }

        public override void JustDoIt()
        {
            Console.WriteLine("I'm about to run");
            base.JustDoIt();
        }
    }

    public class SwimmingPoolEquipment : ExerciseEquipmentDecorator
    {
        public SwimmingPoolEquipment(IExercise exercise) : base(exercise)
        {
            exercise.AddEquipment("flip flops");
        }

        public override void JustDoIt()
        {
            Console.WriteLine("I'm about to swim");
            base.JustDoIt();
        }
    }

    public class GolfEquipment : ExerciseEquipmentDecorator
    {
        public GolfEquipment(IExercise exercise) : base(exercise)
        {
            exercise.AddEquipment("golf club");
            exercise.AddEquipment("balls");
        }

        public override void JustDoIt()
        {
            Console.WriteLine("I'm about to play golf");
            base.JustDoIt();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var swimming = new SwimmingPoolEquipment(new Exercise());
            swimming.JustDoIt();
            Console.WriteLine();

            var runningAndSwimming = new RunningEquipment(new SwimmingPoolEquipment(new Exercise()));
            runningAndSwimming.JustDoIt();
            Console.WriteLine();

            var swimmingAndPlayGolf = new SwimmingPoolEquipment(new GolfEquipment(new Exercise()));
            swimmingAndPlayGolf.JustDoIt();
        }
    }

}