using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SnapCatch.Annotations;

namespace SnapCatch.Logic.Tools
{
    /// <summary>
    /// Represents group of SnapCatchTools
    /// </summary>
    public class ToolsGroup : INotifyPropertyChanged
    {
        private string _groupName;
        private bool _groupActive;

        /// <summary>
        /// Group resource key
        /// </summary>
        private string _groupNameKey { get; set; }

        /// <summary>
        /// Tools content
        /// </summary>
        public ToolBase[] Tools { get; set; }

        private ToolBase SelectedTool { get; set; }

        /// <summary>
        /// Tool state changed anonimous delegate
        /// </summary>
        private Action<ToolsGroup, ToolBase> _toolSelected;

        public ToolsGroup(string groupNameKey, IEnumerable<ToolBase> tools, Action<ToolsGroup, ToolBase> toolSelected)
        {
            _toolSelected = toolSelected;
            Tools = tools.ToArray();
            _groupNameKey = groupNameKey;
            foreach (var toolBase in Tools)
            {
                toolBase.ToolSelected += ToolBaseOnToolSelected;
            }
        }

        public void ResetSelections()
        {
            foreach (var toolBase in Tools)
            {
                if (toolBase != SelectedTool)
                {
                    toolBase.IsSelected = false;
                }
            }
        }

        /// <summary>
        /// Some of the tool inside current group instance is active
        /// </summary>
        public bool GroupActive
        {
            get { return _groupActive; }
            set
            {
                _groupActive = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// InvokeTool selected in group
        /// </summary>
        /// <param name="tool"></param>
        private void ToolBaseOnToolSelected(ToolBase tool)
        {
            GroupActive = tool.IsSelected;
            SelectedTool = tool;
            _toolSelected?.Invoke(this, tool);
        }

        /// <summary>
        /// Group name resource key
        /// </summary>
        public string GroupKey { get { return _groupNameKey; } }

        /// <summary>
        /// Tool group name
        /// </summary>
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
