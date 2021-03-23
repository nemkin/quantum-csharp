using Q.Graphs;
using Q.Simulators;
using System;
using System.Collections.Generic;

namespace Q.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new CircleGraph(1000, new List<int> { -1, 0, 1 }, 0.1);
            var simulator = new ClassicalWalk();

            simulator.Simulate(graph, 100, 1000);
        }
    }
}
