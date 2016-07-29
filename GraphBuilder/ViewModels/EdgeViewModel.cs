using System;
using System.Windows.Media;
using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class EdgeViewModel : PropertyChangedBase
    {
        private int weight = 1;
        private Brush color = Brushes.Black;
        public int Weight
        {
            get { return weight; }
            set { weight = value; NotifyOfPropertyChange(() => Weight); }
        }
        public Brush Color
        {
            get { return color; }
            set { color = value; NotifyOfPropertyChange(() => Color); }
        }

        public EdgeViewModel(NodeViewModel u, NodeViewModel v)
        {
            U = u; V = v;
            U.PropertyChanged += NotifyChanges;
            V.PropertyChanged += NotifyChanges;
        }

        public NodeViewModel V { get; set; }
        public NodeViewModel U { get; set; }

        public int PinX => Math.Min(U.X, V.X);
        public int PinY => Math.Min(U.Y, V.Y);
        public int SrcX => U.X - PinX + NodeViewModel.NodeRadius;
        public int SrcY => U.Y - PinY + NodeViewModel.NodeRadius;
        public int DstX => V.X - PinX + NodeViewModel.NodeRadius;
        public int DstY => V.Y - PinY + NodeViewModel.NodeRadius;

        private void NotifyChanges(object sender, object args)
        {
            NotifyOfPropertyChange(() => PinX);
            NotifyOfPropertyChange(() => PinY);
            NotifyOfPropertyChange(() => SrcX);
            NotifyOfPropertyChange(() => SrcY);
            NotifyOfPropertyChange(() => DstX);
            NotifyOfPropertyChange(() => DstY);
        }
    }
}