using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad5.Core;
using Zad5.Model;

namespace Zad5.ViewModel
{
	public class KategorieViewModel : ViewModelBase
	{
		private readonly SklepContext sklepContext;

        public ObservableCollection<ProduktKategoria> KategorieCollection { 
			get { return KategorieCollection; } 
			set
			{
				KategorieCollection = value;
				OnPropertyChanged(nameof(KategorieCollection));
			}
		}

        public KategorieViewModel()
        {
            sklepContext = App.GetShopContext();
			KategorieCollection = new ObservableCollection<ProduktKategoria>();

			
			
		}
    }
}
