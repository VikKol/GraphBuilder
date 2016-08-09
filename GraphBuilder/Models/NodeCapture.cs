using System.Windows;
using GraphBuilder.ViewModels;

namespace GraphBuilder.Models
{
    struct NodeCapture
    {
        public NodeViewModel Node;
        public IInputElement Source;
        public NodeCaptureState State;
    }

    enum NodeCaptureState
    {
        Default,
        Captured
    }
}
