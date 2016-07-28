using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {
        private int nodeCounter = 0;

        public GraphViewModel Graph { set; get; } = new GraphViewModel();

        public void AddNode(IInputElement el, MouseButtonEventArgs args)
        {
            Graph.Nodes.Add(new NodeViewModel
            {
                Key = ++nodeCounter,
                X = (int)args.GetPosition(el).X,
                Y = (int)args.GetPosition(el).Y,
            });
        }

        public void AddEdge(IInputElement el, MouseButtonEventArgs args)
        {

        }
    }
}
