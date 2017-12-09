using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SnapCatch.Annotations;

namespace SnapCatch.Logic.Tools
{
    /// <summary>
    /// Loading tools and format tool containers with groups
    /// </summary>
    public class ToolsManager : INotifyPropertyChanged
    {
        /// <summary>
        /// Load tools background worker
        /// </summary>
        private BackgroundWorker _loadtoolsWork;

        /// <summary>
        /// Tool grouped by groups
        /// </summary>
        private ToolsGroup[] _toolGroups;

        private ToolsGroup _currentActiveGroup;

        /// <summary>
        /// Current tool groups
        /// </summary>
        public ToolsGroup[] ToolGroups
        {
            get { return _toolGroups; }
            set
            {
                _toolGroups = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Selected tool
        /// </summary>
        public ToolBase ActiveTool { get; set; }

        /// <summary>
        /// Instance of layer manager
        /// </summary>
        private LayersManager _layersManager;

        /// <summary>
        /// Instance of viewport manager
        /// </summary>
        private ViewportManager _viewportManager;

        public ToolsManager(LayersManager layersManager, ViewportManager viewPortManager)
        {
            _layersManager = layersManager;
            _viewportManager = viewPortManager;
            _loadtoolsWork = new BackgroundWorker();
        }

        public void InitInstance()
        {
            _loadtoolsWork.DoWork += LoadtoolsWorkOnDoWork;
            _loadtoolsWork.RunWorkerCompleted += LoadtoolsWorkOnRunWorkerCompleted;
            _loadtoolsWork.RunWorkerAsync();
        }

        private void ToolSelected(ToolsGroup grp, ToolBase tool)
        {
            if (tool.IsSelected)
            {
                if (_currentActiveGroup != null)
                {
                    _currentActiveGroup.ResetSelections();
                }

                ActiveTool = tool;
                _currentActiveGroup = grp;
            }
        }

        private void LoadtoolsWorkOnDoWork(object sender, DoWorkEventArgs e)
        {
            var toolsData = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract
                            && t.IsSubclassOf(typeof(ToolBase))
                            && t.GetCustomAttributes(typeof(SnapCatchToolAttribute)).Any()).ToArray();

            e.Result = toolsData;
        }

        private void LoadtoolsWorkOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var toolTypes = (Type[])e.Result;
            var dict = new Dictionary<string, List<ToolBase>>();
            foreach (var type in toolTypes)
            {
                var instance = (ToolBase)Activator.CreateInstance(type, _viewportManager, _layersManager);
                var attr = (SnapCatchToolAttribute)type.GetCustomAttribute(typeof(SnapCatchToolAttribute));
                instance.InitTool(attr.OrderIndex);
                List<ToolBase> tools;
                if (dict.TryGetValue(instance.ToolGroupKey, out tools))
                {
                    tools.InsertInOrder(instance);
                }
                else
                {
                    tools = new List<ToolBase>() { instance };
                    dict.Add(instance.ToolGroupKey, tools);
                }
            }

            ToolGroups = dict.Select(d => new ToolsGroup(d.Key, d.Value, ToolSelected)).ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
