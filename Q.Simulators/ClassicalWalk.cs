using Q.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q.Simulators
{
    public class ClassicalWalk
    {
        public void Simulate(IGraph graph, int walkers, int steps)
        {
            var locations = Enumerable.Repeat(0, walkers).ToList();

            for (var step = 0; step < steps; ++step)
            {
                for (var walker = 0; walker < walkers; ++walker) {
                    locations[walker] = graph.NextNode(locations[walker]);
                    Console.Write($"{locations[walker]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
