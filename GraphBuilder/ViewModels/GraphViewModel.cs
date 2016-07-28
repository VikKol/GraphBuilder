using System.Collections.Generic;
using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class NodeViewModel : PropertyChangedBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Key { get; set; }
        public int Value { get; set; }
        public List<EdgeViewModel> Connections { get; set; } = new List<EdgeViewModel>();
    }

    class EdgeViewModel : PropertyChangedBase
    {
        public NodeViewModel V { get; set; }
        public NodeViewModel U { get; set; }
        public int Weight { get; set; }
    }

    class GraphViewModel : PropertyChangedBase
    {
        public BindableCollection<NodeViewModel> Nodes { get; set; } = new BindableCollection<NodeViewModel>();
        public BindableCollection<EdgeViewModel> Edges { get; set; } = new BindableCollection<EdgeViewModel>();
    }
}
