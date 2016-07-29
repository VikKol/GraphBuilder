using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class GraphViewModel : PropertyChangedBase
    {
        public BindableCollection<NodeViewModel> Nodes { get; } = new BindableCollection<NodeViewModel>();
        public BindableCollection<EdgeViewModel> Edges { get; } = new BindableCollection<EdgeViewModel>();
    }
}
