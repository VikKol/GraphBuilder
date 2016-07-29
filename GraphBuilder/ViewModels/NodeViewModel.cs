using System.Collections.Generic;
using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class NodeViewModel : PropertyChangedBase
    {
        public const int NodeRadius = 20;
        public int NodeDiameter { get; } = NodeRadius * 2;

        private int x;
        private int y;
        public int X
        {
            get { return x; }
            set { x = value; NotifyOfPropertyChange(() => X); }
        }
        public int Y
        {
            get { return y; }
            set { y = value; NotifyOfPropertyChange(() => Y); }
        }

        public bool IsCaptured { get; set; }

        public int Key { get; set; }
        public int Value { get; set; }
        public List<EdgeViewModel> Connections { get; } = new List<EdgeViewModel>();
    }
}