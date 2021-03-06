﻿using System.Collections.Generic;

namespace Dock.Model
{
    public abstract class DockBase : DockableBase, IDock
    {
        internal INavigateAdapter _navigateAdapter;

        public IList<IDockable>? VisibleDockables { get; set; }

        public IList<IDockable>? HiddenDockables { get; set; }

        public IList<IDockable>? PinnedDockables { get; set; }

        public IDockable? ActiveDockable { get; set; }

        public IDockable? DefaultDockable { get; set; }

        public IDockable? FocusedDockable { get; set; }

        public double Proportion { get; set; } = double.NaN;

        public bool IsActive { get; set; }

        public bool IsCollapsable { get; set; } = true;

        public bool CanGoBack => _navigateAdapter?.CanGoBack ?? false;

        public bool CanGoForward => _navigateAdapter?.CanGoForward ?? false;

        public DockBase()
        {
            _navigateAdapter = new NavigateAdapter(this);
        }

        public virtual void GoBack()
        {
            _navigateAdapter?.GoBack();
        }

        public virtual void GoForward()
        {
            _navigateAdapter?.GoForward();
        }

        public virtual void Navigate(object root)
        {
            _navigateAdapter?.Navigate(root, true);
        }

        public virtual void Close()
        {
            _navigateAdapter?.Close();
        }
    }
}
