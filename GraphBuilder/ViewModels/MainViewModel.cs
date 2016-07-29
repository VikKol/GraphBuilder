using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;

namespace GraphBuilder.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {
        private int nodeCounter = 0;
        private bool blockNew = false;
        private NodeViewModel tmpSrcNode = null;

        public GraphViewModel Graph { set; get; } = new GraphViewModel();

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
            node.IsCaptured = true;
            args.Handled = true;
            Mouse.OverrideCursor = Cursors.Hand;
        }

        public void ReleaseNode(IInputElement source, NodeViewModel node, MouseButtonEventArgs args)
        {
            blockNew = false;
            node.IsCaptured = false;
            args.Handled = true;
            Mouse.OverrideCursor = null;
        }

        public void MoveNode(IInputElement source, NodeViewModel node, MouseEventArgs args)
        {
            if (node.IsCaptured && args.LeftButton == MouseButtonState.Pressed)
            {
                node.X += (int)args.GetPosition(source).X - NodeViewModel.NodeRadius;
                node.Y += (int)args.GetPosition(source).Y - NodeViewModel.NodeRadius;

                args.Handled = true;
            }
        }
    }
}
