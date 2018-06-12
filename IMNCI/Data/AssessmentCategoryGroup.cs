using System;

using System.Collections.ObjectModel;
using System.ComponentModel;
using IMNCI.Models;

namespace IMNCI.Data
{
    public class AssessmentCategoryGroup : ObservableCollection<Assessment>, INotifyPropertyChanged
    {
        private bool _expanded;

        public string Category { get; set; }

        public string Title { get; set; }

        public bool Expanded
        {
            get { return _expanded; }

            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    //OnPropertyChanged(Expanded);
                    //OnPropertyChanged(StateIcon);
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public string StateIcon
        {
            get { return Expanded ? "expanded.png" : "collapsed.png"; }
        }

        public AssessmentCategoryGroup(string category, bool expanded = true){
            Category = category;
            Expanded = expanded;
        }
    }
}
