using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using GraphBuilder.Models;

namespace GraphBuilder.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {
        private int nodeCounter = 0;
        private bool blockNew = false;
        private NodeCapture nodeCapture;
        private NodeViewModel tmpSrcNode = null;

        public GraphViewModel Graph { get; } = new GraphViewModel();
        public ExportPanelViewModel ExportPanel { get; } = new ExportPanelViewModel();

        public void AddNode(IInputElement source, object node, MouseButtonEventArgs args)
        {
            if (blockNew || !(source is Canvas)) return;

            Graph.Nodes.Add(new NodeViewModel
            {
                Key = ++nodeCounter,
                X = (int)args.GetPosition(source).X - NodeViewModel.NodeRadius,
                Y = (int)args.GetPosition(source).Y - NodeViewModel.NodeRadius,
            });
        }

        public void ConnectSourceNode(IInputElement source, NodeViewModel node, MouseButtonEventArgs args)
        {
            tmpSrcNode = node;
            Mouse.OverrideCursor = Cursors.Cross;
        }

        public void ConnectTargetNode(Grid source, NodeViewModel node, MouseButtonEventArgs args)
        {
            if (tmpSrcNode != null && node != null && tmpSrcNode != node)
            {
                var edge = new EdgeViewModel(tmpSrcNode, node);
                Graph.Edges.Add(edge);
                tmpSrcNode.Connections.Add(edge);
                node.Connections.Add(edge);
            }
            tmpSrcNode = null;
            Mouse.OverrideCursor = null;
        }

        public void CaptureNode(IInputElement source, NodeViewModel node, MouseButtonEventArgs args)
        {
            blockNew = true;
            nodeCapture.Node = node;
            nodeCapture.Source = source;
            nodeCapture.State = NodeCaptureState.Captured;

            args.Handled = true;
            Mouse.OverrideCursor = Cursors.Hand;
        }

        public void ReleaseNode(MouseButtonEventArgs args)
        {
            blockNew = false;
            nodeCapture.Node = null;
            nodeCapture.Source = null;
            nodeCapture.State = NodeCaptureState.Default;

            args.Handled = true;
            Mouse.OverrideCursor = null;
        }

        public void MoveNode(MouseEventArgs args)
        {
            if (nodeCapture.State == NodeCaptureState.Captured && args.LeftButton == MouseButtonState.Pressed)
            {
                nodeCapture.Node.X += (int)args.GetPosition(nodeCapture.Source).X - NodeViewModel.NodeRadius;
                nodeCapture.Node.Y += (int)args.GetPosition(nodeCapture.Source).Y - NodeViewModel.NodeRadius;

                args.Handled = true;
            }
        }

        public void ExportAdjacencyList() => ExportPanel.ExportAdjacencyList(Graph);
    }
}