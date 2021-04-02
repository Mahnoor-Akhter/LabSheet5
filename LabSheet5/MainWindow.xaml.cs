using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabSheet5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{ Model1Container db();
		public MainWindow()
		{
			InitializeComponent();
		}
		//Runs on window Load
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Model1Container db = new Model1Container();

			var query = from a in db.Albums
						select a;

			lbxAlbum.ItemsSource = query.ToList();
		
		
		}

		private void lbxAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//dertermine what is selected
			Albums selecteAlbum = lbxAlbum.SelectedItem as Albums;

			if(selecteAlbum != null)
			{
				//query for by that album

				var query = from b in db.Bands
							where b.AlbumId == selecteAlbum.Id
							select b.Title;

				//display
				lbxBand.ItemsSource = query.ToList();

							
			}

		}
	}

	internal class Model1Container
	{
	}
}
