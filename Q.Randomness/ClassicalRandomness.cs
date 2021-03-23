using System;
using System.Collections.Generic;
using System.Linq;

namespace Q.Randomness
{
    public class ClassicalRandomness
    {
        public static bool RandomBool(double probability)
        {
            if (1 < probability) throw new Exception("Probability larger than 1.");
            var generator = new Random();
            var number = generator.NextDouble();
            return (number < probability);
        }

        public static T RandomChoice<T>(IEnumerable<T> options)
        {
            var list = options.ToList();
            if (list.Count == 0) throw new Exception("No options.");

            var generator = new Random();
            var number = generator.Next(list.Count);

            return list[number];
        }
    }
}
