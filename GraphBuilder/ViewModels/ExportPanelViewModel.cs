using Caliburn.Micro;
using System.Text;

namespace GraphBuilder.ViewModels
{
    class ExportPanelViewModel : PropertyChangedBase 
    {
        private string _content = string.Empty;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyOfPropertyChange(nameof(Content));
            }
        }

        public bool ExportWeight { get; set; }

        public void ExportAdjacencyList(GraphViewModel graph)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Nodes: {graph.Nodes.Count}, Edges: {graph.Edges.Count}");

            foreach (var edge in graph.Edges)
            {
                if (ExportWeight)
                {
                    sb.AppendLine($"{edge.U.Key} {edge.V.Key} {edge.Weight}");
                }
                else
                {
                    sb.AppendLine($"{edge.U.Key} {edge.V.Key}");
                }
            }

            Content = sb.ToString();
        }
    }
}