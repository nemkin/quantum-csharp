using Q.Randomness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q.Graphs
{
    public class CircleGraph : IGraph
    {
        public CircleGraph(int vertexCount, List<int> connectedNeighbourDistances, double randomEdgeProbability)
        {
            this.vertexCount = vertexCount;
            this.connectedNeighbourDistances = connectedNeighbourDistances.Select(dist => (dist + vertexCount) % vertexCount).ToList();
            this.randomEdgeProbability = randomEdgeProbability;
            this.randomEdges = new Dictionary<int, List<int>>();

            for(var v = 0; v < this.vertexCount; ++v)
            {
                randomEdges.Add(v, new List<int>());
                for(var n = 0; n < this.vertexCount; ++n)
                {
                    var isEdge = ClassicalRandomness.RandomBool(randomEdgeProbability);

                    if(isEdge)
                    {
                        randomEdges[v].Add(n);
                    }
                }
            }
        }

        public int NextNode(int fromNode)
        {
            var neighbours = this.connectedNeighbourDistances
                .Select(dist => (fromNode + dist) % this.vertexCount)
                .Concat(randomEdges[fromNode])
                .Distinct();
            var nextNode = ClassicalRandomness.RandomChoice(neighbours);
            return nextNode;
        }


        private int vertexCount;
        private List<int> connectedNeighbourDistances;
        private double randomEdgeProbability;

        private Dictionary<int, List<int>> randomEdges;
    }
}
