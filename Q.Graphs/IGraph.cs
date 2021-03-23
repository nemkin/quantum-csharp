using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Graphs
{
    public interface IGraph
    {
        int NextNode(int fromNode);
    }
}
